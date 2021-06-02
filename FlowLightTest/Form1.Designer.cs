namespace FlowLightTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.panFreeLight = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panBusyLight = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panZoneLight = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnToggleMoniting = new System.Windows.Forms.Button();
            this.mainLoopTimer = new System.Windows.Forms.Timer(this.components);
            this.labMouseDistance = new System.Windows.Forms.Label();
            this.labMouseMileometer = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labKeyPressCount = new System.Windows.Forms.Label();
            this.leakTimer = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.labActivtyScore = new System.Windows.Forms.Label();
            this.panFreeLight.SuspendLayout();
            this.panBusyLight.SuspendLayout();
            this.panZoneLight.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(164, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Flow Light Concept Tester";
            // 
            // panFreeLight
            // 
            this.panFreeLight.Controls.Add(this.label2);
            this.panFreeLight.Location = new System.Drawing.Point(51, 123);
            this.panFreeLight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panFreeLight.Name = "panFreeLight";
            this.panFreeLight.Size = new System.Drawing.Size(90, 82);
            this.panFreeLight.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Free";
            // 
            // panBusyLight
            // 
            this.panBusyLight.Controls.Add(this.label3);
            this.panBusyLight.Location = new System.Drawing.Point(221, 123);
            this.panBusyLight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panBusyLight.Name = "panBusyLight";
            this.panBusyLight.Size = new System.Drawing.Size(90, 82);
            this.panBusyLight.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Busy";
            // 
            // panZoneLight
            // 
            this.panZoneLight.Controls.Add(this.label4);
            this.panZoneLight.Location = new System.Drawing.Point(387, 123);
            this.panZoneLight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panZoneLight.Name = "panZoneLight";
            this.panZoneLight.Size = new System.Drawing.Size(90, 82);
            this.panZoneLight.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 35);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "In the \'Zone\'";
            // 
            // btnToggleMoniting
            // 
            this.btnToggleMoniting.Location = new System.Drawing.Point(221, 228);
            this.btnToggleMoniting.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnToggleMoniting.Name = "btnToggleMoniting";
            this.btnToggleMoniting.Size = new System.Drawing.Size(90, 28);
            this.btnToggleMoniting.TabIndex = 4;
            this.btnToggleMoniting.Text = "Start Monitoring";
            this.btnToggleMoniting.UseVisualStyleBackColor = true;
            this.btnToggleMoniting.Click += new System.EventHandler(this.btnToggleMoniting_Click);
            // 
            // mainLoopTimer
            // 
            this.mainLoopTimer.Interval = 1100;
            this.mainLoopTimer.Tick += new System.EventHandler(this.mainLoopTimer_Tick);
            // 
            // labMouseDistance
            // 
            this.labMouseDistance.AutoSize = true;
            this.labMouseDistance.Location = new System.Drawing.Point(49, 66);
            this.labMouseDistance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labMouseDistance.Name = "labMouseDistance";
            this.labMouseDistance.Size = new System.Drawing.Size(120, 13);
            this.labMouseDistance.TabIndex = 5;
            this.labMouseDistance.Text = "Mouse distance moved:";
            // 
            // labMouseMileometer
            // 
            this.labMouseMileometer.AutoSize = true;
            this.labMouseMileometer.Location = new System.Drawing.Point(200, 66);
            this.labMouseMileometer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labMouseMileometer.Name = "labMouseMileometer";
            this.labMouseMileometer.Size = new System.Drawing.Size(13, 13);
            this.labMouseMileometer.TabIndex = 6;
            this.labMouseMileometer.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(331, 66);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Keys pressed:";
            // 
            // labKeyPressCount
            // 
            this.labKeyPressCount.AutoSize = true;
            this.labKeyPressCount.Location = new System.Drawing.Point(465, 66);
            this.labKeyPressCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labKeyPressCount.Name = "labKeyPressCount";
            this.labKeyPressCount.Size = new System.Drawing.Size(13, 13);
            this.labKeyPressCount.TabIndex = 8;
            this.labKeyPressCount.Text = "0";
            // 
            // leakTimer
            // 
            this.leakTimer.Interval = 1950;
            this.leakTimer.Tick += new System.EventHandler(this.leakTimer_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(147, 96);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Activity score \'bucket\':";
            // 
            // labActivtyScore
            // 
            this.labActivtyScore.AutoSize = true;
            this.labActivtyScore.Location = new System.Drawing.Point(304, 96);
            this.labActivtyScore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labActivtyScore.Name = "labActivtyScore";
            this.labActivtyScore.Size = new System.Drawing.Size(13, 13);
            this.labActivtyScore.TabIndex = 10;
            this.labActivtyScore.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 280);
            this.Controls.Add(this.labActivtyScore);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labKeyPressCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labMouseMileometer);
            this.Controls.Add(this.labMouseDistance);
            this.Controls.Add(this.btnToggleMoniting);
            this.Controls.Add(this.panZoneLight);
            this.Controls.Add(this.panBusyLight);
            this.Controls.Add(this.panFreeLight);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Flow Status Lights";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panFreeLight.ResumeLayout(false);
            this.panFreeLight.PerformLayout();
            this.panBusyLight.ResumeLayout(false);
            this.panBusyLight.PerformLayout();
            this.panZoneLight.ResumeLayout(false);
            this.panZoneLight.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panFreeLight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panBusyLight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panZoneLight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnToggleMoniting;
        private System.Windows.Forms.Timer mainLoopTimer;
        private System.Windows.Forms.Label labMouseDistance;
        private System.Windows.Forms.Label labMouseMileometer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labKeyPressCount;
        private System.Windows.Forms.Timer leakTimer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labActivtyScore;
    }
}

