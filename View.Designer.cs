namespace _501_P2
{
    partial class View
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
            System.Windows.Forms.Button uxEditAlarm;
            System.Windows.Forms.Button uxAddAlarm;
            this.uxAlarmList = new System.Windows.Forms.ListBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.snoozeButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            uxEditAlarm = new System.Windows.Forms.Button();
            uxAddAlarm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxEditAlarm
            // 
            uxEditAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            uxEditAlarm.Location = new System.Drawing.Point(66, 32);
            uxEditAlarm.Margin = new System.Windows.Forms.Padding(4);
            uxEditAlarm.Name = "uxEditAlarm";
            uxEditAlarm.Size = new System.Drawing.Size(147, 96);
            uxEditAlarm.TabIndex = 2;
            uxEditAlarm.Text = "Edit";
            uxEditAlarm.UseVisualStyleBackColor = true;
            uxEditAlarm.Click += new System.EventHandler(this.uxEditAlarm_Click);
            // 
            // uxAlarmList
            // 
            this.uxAlarmList.FormattingEnabled = true;
            this.uxAlarmList.ItemHeight = 16;
            this.uxAlarmList.Location = new System.Drawing.Point(243, 131);
            this.uxAlarmList.Margin = new System.Windows.Forms.Padding(4);
            this.uxAlarmList.Name = "uxAlarmList";
            this.uxAlarmList.Size = new System.Drawing.Size(311, 292);
            this.uxAlarmList.TabIndex = 3;
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(243, 529);
            this.stopButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(115, 78);
            this.stopButton.TabIndex = 5;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // snoozeButton
            // 
            this.snoozeButton.Enabled = false;
            this.snoozeButton.Location = new System.Drawing.Point(439, 529);
            this.snoozeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.snoozeButton.Name = "snoozeButton";
            this.snoozeButton.Size = new System.Drawing.Size(115, 78);
            this.snoozeButton.TabIndex = 6;
            this.snoozeButton.Text = "Snooze";
            this.snoozeButton.UseVisualStyleBackColor = true;
            this.snoozeButton.Click += new System.EventHandler(this.snoozeButton_Click);
            // 
            // uxAddAlarm
            // 
            uxAddAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            uxAddAlarm.Location = new System.Drawing.Point(602, 32);
            uxAddAlarm.Margin = new System.Windows.Forms.Padding(4);
            uxAddAlarm.Name = "uxAddAlarm";
            uxAddAlarm.Size = new System.Drawing.Size(147, 96);
            uxAddAlarm.TabIndex = 7;
            uxAddAlarm.Text = "+";
            uxAddAlarm.UseVisualStyleBackColor = true;
            uxAddAlarm.Click += new System.EventHandler(this.uxAddAlarm_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(367, 439);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            this.statusLabel.TabIndex = 8;
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 618);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(uxAddAlarm);
            this.Controls.Add(this.snoozeButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.uxAlarmList);
            this.Controls.Add(uxEditAlarm);
            this.Name = "View";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox uxAlarmList;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button snoozeButton;
        private System.Windows.Forms.Label statusLabel;
    }
}

