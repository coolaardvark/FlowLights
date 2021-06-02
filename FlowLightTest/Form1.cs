using System;
using System.Windows.Forms;
using System.Diagnostics;
using Gma.System.MouseKeyHook;

namespace FlowLightTest
{
    public partial class Form1 : Form
    {
        ////IDEA A lot of this stuff should probably be moved in to classes
        // Maybe have a mouse and keyboard monitor class?

        private bool devModeActive;
        private int activtyScoreBucket;

        private int keysPressed;
        private int mouseDistanceMoved;
        private int totalKeysPressed;
        private int totalMouseDistanceMoved;

        private int lastMouseX;
        private int lastMouseY;

        private bool hookedin;
        private IKeyboardMouseEvents globalHook;

        private LightController light;

        private string flowState;

        public Form1()
        {
            InitializeComponent();

            devModeActive = false;
            activtyScoreBucket = 0;
            hookedin = false;

            light = new LightController();
        }

        #region Form event handlers
        private void btnToggleMoniting_Click(object sender, EventArgs e)
        {
            if (! mainLoopTimer.Enabled)
            {
                HookInEvents();
                mainLoopTimer.Enabled = true;
                leakTimer.Enabled = true;
                // This is what the button will do *next*, not what is doing now!
                btnToggleMoniting.Text = "Stop Monitoring";

                totalKeysPressed = 0;
                totalMouseDistanceMoved = 0;

                light.LightUp();

                flowState = "free";
            }
            else
            {
                // I'm reversing the order of what I do here, just in case the timer
                // gets called after I've unhooked events but before I stop the timer
                // its unlikely, but possible.
                mainLoopTimer.Enabled = false;
                leakTimer.Enabled = false;
                UnHookEvents();
                btnToggleMoniting.Text = "Start Monitoring";

                labMouseMileometer.Text = "0";
                labKeyPressCount.Text = "0";
                labActivtyScore.Text = "0";

                panFreeLight.BackColor = System.Drawing.Color.Gray;
                panBusyLight.BackColor = System.Drawing.Color.Gray;
                panZoneLight.BackColor = System.Drawing.Color.Gray;

                light.LightOff();

                flowState = "";
            }
        }

        private void mainLoopTimer_Tick(object sender, EventArgs e)
        {
            // Is the user currently working as a developer?
            int devProcesses = 0;
            foreach (Process proc in Process.GetProcesses())
            {
                string procName = proc.ProcessName.ToLower();
                // Currently hardwired to 1 app, but really this should go in
                // to a config file and allow for multiple apps
                if (procName == "devenv" || procName == "smss" || procName == "code")
                {
                    devProcesses++;
                }
            }

            if (devProcesses > 0)
            {
                devModeActive = true;
            }
            else
            {
                devModeActive = false;

                // Clear our activity score ready for the next time
                activtyScoreBucket = 0;
            }

            ////IDEA
            // Maybe this code should go in to a second higher fequency timer which is triggered
            // only when we are in developer mode?

            // We only want to bother with the flow lights if user is developing something
            if (devModeActive)
            {
                // cache our current state for later checking
                string currentState = flowState;

                // No idea if this is anything like right yet, needs testing
                activtyScoreBucket += (int)mouseDistanceMoved / 150;
                activtyScoreBucket += keysPressed * 2;

                totalMouseDistanceMoved += mouseDistanceMoved;
                totalKeysPressed += keysPressed;

                // Just for testing
                labMouseMileometer.Text = totalMouseDistanceMoved.ToString();
                labKeyPressCount.Text = totalKeysPressed.ToString();
                labActivtyScore.Text = activtyScoreBucket.ToString();

                // Set our 'flow state'.  Do this sperately since calling the state change function does 'cost'
                // a signifcant amount of IO time.
                if (activtyScoreBucket >= 100)
                {
                    flowState = "inflow";
                }
                else if (activtyScoreBucket < 100 && activtyScoreBucket > 50)
                {
                    flowState = "busy";
                }
                else
                {
                    flowState = "free";
                }

                if (flowState != currentState)
                {
                    if (flowState == "inflow")
                    {
                        panFreeLight.BackColor = System.Drawing.Color.Gray;
                        panBusyLight.BackColor = System.Drawing.Color.Gray;
                        panZoneLight.BackColor = System.Drawing.Color.Red;
                    }
                    else if (flowState == "busy")
                    {
                        panFreeLight.BackColor = System.Drawing.Color.Gray;
                        panBusyLight.BackColor = System.Drawing.Color.Yellow;
                        panZoneLight.BackColor = System.Drawing.Color.Gray;
                    }
                    else
                    {
                        panFreeLight.BackColor = System.Drawing.Color.Green;
                        panBusyLight.BackColor = System.Drawing.Color.Gray;
                        panZoneLight.BackColor = System.Drawing.Color.Gray;
                    }

                    //light.ChangeState(flowState);
                    light.StartAsyncMorph(flowState);
                }

                // Reset counts ready for next loop
                mouseDistanceMoved = 0;
                keysPressed = 0;
            }
        }

        private void leakTimer_Tick(object sender, EventArgs e)
        {
            // Slowly let the contents of the 'bucket' leak out

            ////IDEA maybe have different leak rates depending on tge state you are in?
            // When you are in the flow, have the leak rate lower, making it easier to stay
            // that way, but increase it when you are just busy, this might encourage you to
            // hit that flow state and stay there for longer?
            if (activtyScoreBucket > 10)
            {
                activtyScoreBucket -= 10;
            }
            else
            {
                activtyScoreBucket = 0;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Clean up, not sure if I need to stop the timers
            if (mainLoopTimer.Enabled == true)
            {
                mainLoopTimer.Enabled = false;
            }
            if (leakTimer.Enabled == true)
            {
                leakTimer.Enabled = false;
            }

            // I do need to remove the hooks for sure
            if (hookedin)
            {
                UnHookEvents();
            }

            light.Dispose();
            light = null;
        }
        #endregion

        #region MouseKeyHook stuff
        public void HookInEvents()
        {
            globalHook = Hook.GlobalEvents();

            globalHook.MouseDownExt += GlobalHook_MouseDownExt;
            globalHook.KeyPress += GlobalHook_KeyPress;
            globalHook.MouseMove += GlobalHook_MouseMove;
            globalHook.MouseWheel += GlobalHook_MouseWheel;

            // Reset our activity counters
            keysPressed = 0;
            mouseDistanceMoved = 0;
            lastMouseX = 0;
            lastMouseY = 0;

            hookedin = true;
        }

        public void UnHookEvents()
        {
            globalHook.MouseDownExt -= GlobalHook_MouseDownExt;
            globalHook.KeyPress -= GlobalHook_KeyPress;
            globalHook.MouseMove -= GlobalHook_MouseMove;
            globalHook.MouseWheel -= GlobalHook_MouseWheel;

            globalHook.Dispose();
            globalHook = null;

            hookedin = false;
        }

        private void GlobalHook_KeyPress(object sender, KeyPressEventArgs e)
        {
            keysPressed++;
        }

        private void GlobalHook_MouseDownExt(object sender, MouseEventExtArgs e)
        {
            // The mouse button is not techincally a key, but I'm recording it as such
            keysPressed++;
        }

        private void GlobalHook_MouseMove(object sender, MouseEventArgs e)
        {
            // Our first move would probably be a large jump since we default to 0, 0
            // on our x y coordinates, so just use a fixed smaller value instead
            if (lastMouseX == 0 && lastMouseY == 0)
            {
                // No need to add the distance here since we will be starting at 0
                mouseDistanceMoved = 100;
            }
            else
            {
                // Get rough estimate of mouse movement by assuming all movement
                // will be a perfect diagonal line from last x y to current x y
                int xMove = Math.Abs(lastMouseX - e.X);
                int yMove = Math.Abs(lastMouseY - e.Y);

                // Pythagoras theorem
                mouseDistanceMoved += (int)Math.Sqrt((xMove * xMove) + (yMove * yMove));
            }

            lastMouseX = e.X;
            lastMouseY = e.Y;
        }

        private void GlobalHook_MouseWheel(object sender, MouseEventArgs e)
        {
            // Not mouse movement, but nonetheless a very important activity
            // When using the mouse scroll wheel it is likely you are reading code,
            // something which really needs concentration, hence this is more highly
            // scored than actual mouse moment

            // minus here shows scrolling down, we just want the distant scrolled
            // direction is unimportant.
            mouseDistanceMoved += Math.Abs(e.Delta * 2);
        }
        #endregion
    }
}
