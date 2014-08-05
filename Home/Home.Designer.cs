namespace Home
{
    partial class Home
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonSW = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonLED4 = new System.Windows.Forms.RadioButton();
            this.radioButtonLED3 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxState = new System.Windows.Forms.TextBox();
            this.timerUI = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorkerListenClient = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonSW);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.radioButtonLED4);
            this.groupBox1.Controls.Add(this.radioButtonLED3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 119);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Home Devices";
            // 
            // radioButtonSW
            // 
            this.radioButtonSW.AutoCheck = false;
            this.radioButtonSW.AutoSize = true;
            this.radioButtonSW.Location = new System.Drawing.Point(71, 80);
            this.radioButtonSW.Name = "radioButtonSW";
            this.radioButtonSW.Size = new System.Drawing.Size(39, 17);
            this.radioButtonSW.TabIndex = 5;
            this.radioButtonSW.TabStop = true;
            this.radioButtonSW.Text = "Off";
            this.radioButtonSW.UseVisualStyleBackColor = true;
            this.radioButtonSW.Click += new System.EventHandler(this.radioButtonSW_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "SW Button";
            // 
            // radioButtonLED4
            // 
            this.radioButtonLED4.AutoCheck = false;
            this.radioButtonLED4.AutoSize = true;
            this.radioButtonLED4.Location = new System.Drawing.Point(71, 51);
            this.radioButtonLED4.Name = "radioButtonLED4";
            this.radioButtonLED4.Size = new System.Drawing.Size(39, 17);
            this.radioButtonLED4.TabIndex = 3;
            this.radioButtonLED4.TabStop = true;
            this.radioButtonLED4.Text = "Off";
            this.radioButtonLED4.UseVisualStyleBackColor = true;
            this.radioButtonLED4.Click += new System.EventHandler(this.radioButtonLED4_Click);
            // 
            // radioButtonLED3
            // 
            this.radioButtonLED3.AutoCheck = false;
            this.radioButtonLED3.AutoSize = true;
            this.radioButtonLED3.Location = new System.Drawing.Point(71, 22);
            this.radioButtonLED3.Name = "radioButtonLED3";
            this.radioButtonLED3.Size = new System.Drawing.Size(39, 17);
            this.radioButtonLED3.TabIndex = 2;
            this.radioButtonLED3.TabStop = true;
            this.radioButtonLED3.Text = "Off";
            this.radioButtonLED3.UseVisualStyleBackColor = true;
            this.radioButtonLED3.Click += new System.EventHandler(this.radioButtonLED3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "LED4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "LED3";
            // 
            // textBoxState
            // 
            this.textBoxState.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxState.Location = new System.Drawing.Point(12, 137);
            this.textBoxState.Name = "textBoxState";
            this.textBoxState.ReadOnly = true;
            this.textBoxState.Size = new System.Drawing.Size(260, 13);
            this.textBoxState.TabIndex = 1;
            this.textBoxState.Text = "Idle";
            // 
            // timerUI
            // 
            this.timerUI.Tick += new System.EventHandler(this.timerUI_Tick);
            // 
            // backgroundWorkerListenClient
            // 
            this.backgroundWorkerListenClient.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerListenClient_DoWork);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(284, 162);
            this.Controls.Add(this.textBoxState);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 200);
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "Home";
            this.Text = "Home Devices";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Home_closing);
            this.Load += new System.EventHandler(this.Home_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hotkey);
            this.KeyPreview = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonSW;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonLED4;
        private System.Windows.Forms.RadioButton radioButtonLED3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxState;
        private System.Windows.Forms.Timer timerUI;
        private System.ComponentModel.BackgroundWorker backgroundWorkerListenClient;

    }
}

