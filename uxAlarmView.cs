/*
 * Author: Christian Moden
 * uxAlarmView.cs
 * Runs operations for the edit/add alarm function of the alarm project
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _501_P2
{
    public partial class uxAlarmView : Form
    {
        private SetAlarm setAlarm;
        private UpdateBindings updateBindings;
        private UpdateTextFile updateTextFile;
        private int Index = -1;
        private bool Edit;
        Controller controller;
        
        /// <summary>
        /// constructor for editing an alarm
        /// </summary>
        /// <param name="c">controller</param>
        /// <param name="i">index of alarm in Model Alarm List</param>
        /// <param name="s">status</param>
        /// <param name="dt">alarm time</param>
        public uxAlarmView(Controller c, int i, Alarm.AlarmStatus s, DateTime dt)
        {
            InitializeComponent();
            SetSelectionOptions();
            //controller = c;
            SetUpData(c);
            Index = i;
            statusCheckBox.Checked = (s == Alarm.AlarmStatus.On) ? true : false;
            uxTimeSelect.Value = dt;
            Edit = true;
            uxSnoozeTime.Value = c.model.AlarmList[i].Snooze;
            uxAlarmSound.Text = c.model.AlarmList[i].Sound.ToString();
        }
        
        /// <summary>
        /// Constructor for adding an alarm
        /// </summary>
        /// <param name="c"></param>
        public uxAlarmView(Controller c)
        {
            InitializeComponent();
            SetSelectionOptions();
            /*
            controller = c;
            setAlarm = c.SetAlarm;
            updateBindings = c.UpdateBindings;
            updateTextFile = c.UpdateTextFile;
            */
            SetUpData(c);
        }
        /// <summary>
        /// Sets up delegates, controller object, and data sources
        /// </summary>
        /// <param name="c"></param>
        private void SetUpData(Controller c)
        {
            controller = c;
            setAlarm = c.SetAlarm;
            updateBindings = c.UpdateBindings;
            updateTextFile = c.UpdateTextFile;
            //FROM https://stackoverflow.com/questions/906899/binding-an-enum-to-a-winforms-combo-box-and-then-setting-it
            //Binds combo box to enum values and displays text for each value in the enum
            //options are listed as strings and can be parsed back into an enum value later
            uxAlarmSound.DataSource = Enum.GetNames(typeof(Alarm.AlarmSound));
        }
        /// <summary>
        /// hides the window if the user decides to cancel adding/editing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        /// <summary>
        /// keep in here
        /// Sets up time and on/off selection options in the GUI
        /// </summary>
        private void SetSelectionOptions()
        {
            uxTimeSelect.Format = DateTimePickerFormat.Custom;
            uxTimeSelect.CustomFormat = "hh:mm:ss:tt";//12 hour format
            uxTimeSelect.ShowUpDown = true;
        }
        private void setButton_Click(object sender, EventArgs e)
        {
            setAlarm(uxTimeSelect.Text, uxTimeSelect.Value, statusCheckBox.Checked ? Alarm.AlarmStatus.On : Alarm.AlarmStatus.Off,
                (int)uxSnoozeTime.Value, uxAlarmSound.Text, Edit, Index);//delegate
            //change method sig to accept alarm sound
            updateBindings();//delegate
            updateTextFile();//delegate
            this.Hide();
        }
    }
}
