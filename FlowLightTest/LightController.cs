using System;
using System.Collections.Generic;
using System.Threading;
using BlinkStickDotNet;

namespace FlowLightTest
{
    class LightController : IDisposable
    {
        // A simple wrapper for the BlinkStick class
        private BlinkStick device = null;
        private Dictionary<string, string> state2Colour;

        // Async Morph support
        Thread morpher;

        private bool isAsyncMorphing = false;
        private byte targetR;
        private byte targetG;
        private byte targetB;
        int duration;
        int steps;

        // Used by helper to convert string encoded colours to their rgb byte values
        Dictionary<string, byte> hexLookup;

        public LightController()
        {
            device = BlinkStick.FindFirst();
            morpher = new Thread(MorphStep);

            if (device != null && device.OpenDevice())
            {
                // BlinkSticks stay on until they are told to switch off
                device.TurnOff();

                state2Colour = new Dictionary<string, string>();
                state2Colour.Add("free", "#00ff00");
                state2Colour.Add("busy", "#ffff00");
                state2Colour.Add("inflow", "#ff0000");

                hexLookup = new Dictionary<string,byte>();
                hexLookup.Add("a", 10);
                hexLookup.Add("b", 11);
                hexLookup.Add("c", 12);
                hexLookup.Add("d", 13);
                hexLookup.Add("e", 14);
                hexLookup.Add("f", 15);
            }
        }

        public void LightUp()
        {
            if (device != null && device.OpenDevice())
            {
                device.SetColor("#00ff00");
            }
        }

        public void LightOff()
        {
            if (device != null && device.OpenDevice())
            {
                device.TurnOff();
            }
        }

        public void ChangeState(string newState)
        {
            if (device != null && device.OpenDevice())
            {
                device.Morph(state2Colour[newState], 1000, 50);
            }
        }

        public void StartAsyncMorph(string targetState)
        {
            // If we are already running, stop then reset with the new values and restart
            if (isAsyncMorphing)
            {
                morpher.Interrupt();
                // This kills the old thread so we need to recreate it before we restart
            }

            // Create new thread to handle the morph in a non-blocking way (I hope)
            duration = 2000;
            steps = 35;

            string stateColour = state2Colour[targetState];
            stringColour2Bytes(stateColour, out targetR, out targetG, out targetB);

            morpher = new Thread(MorphStep);
            isAsyncMorphing = true;
            morpher.Start();
        }

        public void Dispose()
        {
            if (device != null)
            {
                device.TurnOff();
            }
        }

        private void MorphStep()
        {
            byte currentR = 0;
            byte currentG = 0;
            byte currentB = 0;
            int currentStep = 1;

            while (currentStep != steps)
            {
                try
                {
                    if (device.GetColor(out currentR, out currentG, out currentB))
                    {
                        device.SetColor(
                            (byte)(1.0 * currentR + (targetR - currentR) / 1.0 / steps * currentStep),
                            (byte)(1.0 * currentG + (targetG - currentG) / 1.0 / steps * currentStep),
                            (byte)(1.0 * currentB + (targetB - currentB) / 1.0 / steps * currentStep));

                        currentStep++;

                        Thread.Sleep(duration / steps);
                    }
                }
                catch
                {
                    // Any exception, including the ThreadInterruptedException we can generate to reset the morph,
                    // simply causes the loop, and hence the thread, to end
                    break;
                }
            }

            isAsyncMorphing = false;
        }

        #region utillity methods
        private void stringColour2Bytes(string colourStr, out byte r, out byte g, out byte b)
        {
            // take a hex colour string (i.e #50c100) and break it down in to it's rgb bytes
            byte[] colourBytes = { 0, 0, 0 };

            colourStr = colourStr.TrimStart('#');
            int arrayIndex = 0;
            for (int strIndex = 0; strIndex <= 4; strIndex += 2)
            {
                colourBytes[arrayIndex] = string2Byte(colourStr.Substring(strIndex, 2));
                arrayIndex++;
            }

            r = colourBytes[0];
            g = colourBytes[1];
            b = colourBytes[2];
        }

        private byte string2Byte(string input)
        {
            byte byteValue = 0;

            byte columnMultiplier = 1;
            byte columnValue = 0;
            for (int i = 0; i <= 1; i++)
            {
                string bit = input.Substring(i, 1);
                // <sigh> it seems that all athermatic done on bytes produces int's
                // I sort of get why, but it's a pain
                if (Byte.TryParse(bit, out columnValue))
                {
                    // 1 to 9 is easy to handle!
                    byteValue += (byte)(columnValue * columnMultiplier);
                }
                else
                {
                    // a to f requires a look up table
                    byteValue += (byte)(hexLookup[bit] * columnMultiplier);
                }

                columnMultiplier += 15;
            }

            return byteValue;
        }
        #endregion
    }
}
