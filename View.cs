/*
 * Author: Christian Moden
 * View.cs
 * Runs operations for the main view component of the alarm project
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
using System.IO;
using Timers = System.Timers;

namespace _501_P2
{
    public partial class View : Form
    {
        private Controller controller;
        //private Model model;
        //binding list to hold all alarm objects
        //public BindingList<Alarm> bindingList = new BindingList<Alarm>();
        public View(Controller c)//get rid of model reference
        {
            InitializeComponent();
            controller = c;
            //model = m;
            uxAlarmList.DataSource = controller.model.AlarmList;
            //DataSource = model.bindingList;
            //bindingList.AllowNew = true;
            uxAlarmList.DisplayMember = "Info";
            controller.PopulateAlarmList();
            //PopulateAlarmList();
            uxAlarmList.SelectedIndexChanged += SnoozeAndStopStatus;
            uxAlarmList.SelectedIndexChanged += RunningStatusListener;
            //FROM https://docs.microsoft.com/en-us/dotnet/api/system.timers.timer.synchronizingobject?view=netcore-3.1
            //create new timer with 1 sec interval to check alarm status
            Timers.Timer alarmTimer = new Timers.Timer(1000);
            //Elapsed property tied to event handler to check alarm status
            alarmTimer.Elapsed += TestAlarmStatus;
            //sync timer with list box holding all alarms
            alarmTimer.SynchronizingObject = this.uxAlarmList;
            //start timer
            alarmTimer.Start();

        }
        /// <summary>
        /// Checks current list of alarms to see if any 
        /// active alarms are set to go off.
        /// If the current time matches the alarm time, a message box will 
        /// show saying which alarm went off.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestAlarmStatus(object sender, EventArgs e)
        {
            uxAlarmList.Update();
            //push to controller, controller will have binding list
            controller.TestAlarmStatus();
           
            uxAlarmList.Refresh();
        }
        /// <summary>
        /// Enables and disables the snooze and stop buttons based on
        /// whether the selcted alarm has gone off or is currently running
        /// linked to the selected item changes listener
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SnoozeAndStopStatus(object sender, EventArgs e)
        {
            
            controller.UpdateBindings();

            if (uxAlarmList.SelectedItem != null && controller.model.AlarmList[uxAlarmList.SelectedIndex].Set == Alarm.AlarmStatus.On)
            {
                
                controller.SnoozeAndStopStatus(out bool goneOff, uxAlarmList.SelectedIndex);
                if (goneOff) EnableSnoozeAndStop();
                else DisableSnoozeAndStop();
            }
            else if (controller.model.AlarmList[uxAlarmList.SelectedIndex].Set == Alarm.AlarmStatus.Off)
                DisableSnoozeAndStop();
            else DisableSnoozeAndStop();
            controller.UpdateBindings();
            
        }
        /// <summary>
        /// Enables snooze and stop buttons
        /// </summary>
        private void EnableSnoozeAndStop()
        {
            snoozeButton.Enabled = true;
            stopButton.Enabled = true;
        } 
        /// <summary>
        /// Disables snooze and stop buttons
        /// </summary>
        private void DisableSnoozeAndStop()
        {
            snoozeButton.Enabled = false;
            stopButton.Enabled = false;
        }
        /// <summary>
        /// Displays in a label if an alarm is currently running.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunningStatusListener(object sender, EventArgs e)
        {
            //bindingList.ResetBindings();
            RunningStatusCheck();

        }
        /// <summary>
        /// Updates buttons in the case the user is at the currently selected alarm in  the binding list.
        /// Also called when an alarm goes off, otherwise GUI wll not update immediatly for currently slelected alarm
        /// that just went off
        /// </summary>
        
        public void RunningStatusCheck()
        {
            
            if (uxAlarmList.SelectedItem != null && controller.model.AlarmList[uxAlarmList.SelectedIndex].Set == Alarm.AlarmStatus.On)
            {
                
                statusLabel.Refresh();
                controller.RunningStatusCheck(out bool running, out bool goneOff, uxAlarmList.SelectedIndex);
                if (running)
                {
                    statusLabel.Text = "Running";
                    DisableSnoozeAndStop();
                } 
                else statusLabel.Text = "";                
                if (goneOff)
                {
                    statusLabel.Text = "Alarm went off";
                    EnableSnoozeAndStop();
                }
                else statusLabel.Text = "";
                statusLabel.Refresh();
            }
            else statusLabel.Text = "";
            controller.UpdateBindings();          
        }
        /// <summary>
        /// Button click for editing an alarm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxEditAlarm_Click(object sender, EventArgs e)
        {
            //bindingList.ResetBindings();
            if (uxAlarmList.SelectedItem != null)
            {
                int index = uxAlarmList.SelectedIndex;
                controller.EditAlarm(index, controller.model.AlarmList[index].RawTime, controller.model.AlarmList[index].Set);               
                uxAlarmList.Refresh();
            }
        }
        /// <summary>
        /// Adds an alarm to the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAddAlarm_Click(object sender, EventArgs e)
        {
            controller.AddAlarm();            
        }
        /// <summary>
        /// turns an alarm off that is currently going off
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopButton_Click(object sender, EventArgs e)
        {
            if (uxAlarmList.SelectedItem != null)
            {
                controller.StopAlarm(uxAlarmList.SelectedIndex);
                stopButton.Enabled = false;
                snoozeButton.Enabled = false;
                statusLabel.Text = "";
                controller.UpdateBindings();
            }
            
        }
        /// <summary>
        /// Snooze button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void snoozeButton_Click(object sender, EventArgs e)
        {       
            if (uxAlarmList.SelectedItem != null) controller.Snooze(uxAlarmList.SelectedIndex);           
        }
        /// <summary>
        /// Sounds alarm if it has gone off. MAKE THIS A DELEGATE.
        /// Only method in view used by controller
        /// </summary>
        /// <param name="al"></param>
        public void SoundAlarm(Alarm al)
        {
            MessageBox.Show($"{al.Time} alarm has gone off: Sound: {al.Sound}");
        }
    }
}
