namespace _501_P2
{
    partial class uxAlarmView
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.setButton = new System.Windows.Forms.Button();
            this.uxTimeSelect = new System.Windows.Forms.DateTimePicker();
            this.statusCheckBox = new System.Windows.Forms.CheckBox();
            this.uxAlarmSound = new System.Windows.Forms.ComboBox();
            this.uxSnoozeTime = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.uxSnoozeTime)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(144, 310);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(167, 83);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // setButton
            // 
            this.setButton.Location = new System.Drawing.Point(477, 310);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(167, 83);
            this.setButton.TabIndex = 1;
            this.setButton.Text = "Set";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // uxTimeSelect
            // 
            this.uxTimeSelect.Location = new System.Drawing.Point(196, 103);
            this.uxTimeSelect.Name = "uxTimeSelect";
            this.uxTimeSelect.Size = new System.Drawing.Size(253, 22);
            this.uxTimeSelect.TabIndex = 2;
            // 
            // statusCheckBox
            // 
            this.statusCheckBox.AutoSize = true;
            this.statusCheckBox.Location = new System.Drawing.Point(528, 100);
            this.statusCheckBox.Name = "statusCheckBox";
            this.statusCheckBox.Size = new System.Drawing.Size(49, 21);
            this.statusCheckBox.TabIndex = 3;
            this.statusCheckBox.Text = "On";
            this.statusCheckBox.UseVisualStyleBackColor = true;
            // 
            // uxAlarmSound
            // 
            this.uxAlarmSound.FormattingEnabled = true;
            this.uxAlarmSound.Location = new System.Drawing.Point(199, 153);
            this.uxAlarmSound.Name = "uxAlarmSound";
            this.uxAlarmSound.Size = new System.Drawing.Size(174, 24);
            this.uxAlarmSound.TabIndex = 4;
            // 
            // uxSnoozeTime
            // 
            this.uxSnoozeTime.Location = new System.Drawing.Point(444, 154);
            this.uxSnoozeTime.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.uxSnoozeTime.Name = "uxSnoozeTime";
            this.uxSnoozeTime.Size = new System.Drawing.Size(84, 22);
            this.uxSnoozeTime.TabIndex = 5;
            // 
            // uxAlarmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uxSnoozeTime);
            this.Controls.Add(this.uxAlarmSound);
            this.Controls.Add(this.statusCheckBox);
            this.Controls.Add(this.uxTimeSelect);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "uxAlarmView";
            this.Text = "uxAlarmView";
            ((System.ComponentModel.ISupportInitialize)(this.uxSnoozeTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.DateTimePicker uxTimeSelect;
        private System.Windows.Forms.CheckBox statusCheckBox;
        private System.Windows.Forms.ComboBox uxAlarmSound;
        private System.Windows.Forms.NumericUpDown uxSnoozeTime;
    }
}