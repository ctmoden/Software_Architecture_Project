/*
 * Controls flow of data between gui and model class
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _501_P2
{
    public class Controller
    {
        /// <summary>
        /// View object
        /// </summary>
        
        private SoundAlarm soundAlarm;
        private StatusCheck statusCheck;
        public Model model;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="m"></param>
        public Controller(Model m)
        {
            model = m;
        } 
        /// <summary>
        /// Sets the view object used in the class
        /// </summary>
        /// <param name="v"></param>
        public void SetDelegates(SoundAlarm a, StatusCheck sc)
        {
            soundAlarm = a;
            statusCheck = sc;
        }
        /// <summary>
        /// Populates alarm list
        /// </summary>
        public void PopulateAlarmList()
        {
            FileOperations fo = new FileOperations();
            fo.PopulateAlarmList(ref model);
            /*
            //create new file reading object
            string alarmFile = @"..\..\AlarmList.txt";
            if (File.Exists(alarmFile))
            {
                using (StreamReader sr = new StreamReader(alarmFile))
                {
                    string alarmLine;
                    while ((alarmLine = sr.ReadLine()) != null && !(alarmLine.Equals("")))
                    {
                        string[] split = alarmLine.Split(',');
                        //add alarm sound
                        model.AddAlarm(split[0], DateTime.Parse(split[1]), 
                            (split[2].Equals("On") ? Alarm.AlarmStatus.On : Alarm.AlarmStatus.Off), Int32.Parse(split[3]), split[4]);                        
                    }
                    sr.Close();
                } 
            }
            */
            

        }//FIXME fix tabbing
        /// <summary>
        /// Tests alarms in list to determine if they have gone off
        /// </summary>
        public void TestAlarmStatus()
        {
            foreach(Alarm al in model.AlarmList)
            {
                DateTime currentTime = DateTime.Now;
                if (al.RawTime.ToString("0:hh:mm:ss:tt").Equals(currentTime.ToString("0:hh:mm:ss:tt"))
                    && al.Set == Alarm.AlarmStatus.On)
                {
                    soundAlarm(al);
                    statusCheck();
                }
            }
        }
        /// <summary>
        /// Logic for editing an alarm
        /// </summary>
        /// <param name="i">index in model alarm list of alarm to be modified</param>
        public void EditAlarm(int i, DateTime dt, Alarm.AlarmStatus s)
        {
            var editAlarm = new uxAlarmView(this, i, s, dt);
            editAlarm.Show();
        }
        /// <summary>
        /// Pops up Alarm View screen to add an alarm
        /// </summary>
        public void AddAlarm()
        {
            var addAlarm = new uxAlarmView(this);
            addAlarm.Show();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="time">time</param>
        /// <param name="rawTime">DateTime time</param>
        /// <param name="set">alarm status</param>
        /// <param name="snooze">snooze period</param>
        /// <param name="sound">alarm sound</param>
        /// <param name="edit">bool indicating if alarm is being edited or not</param>
        /// <param name="index">index of modification if editing</param>
        public void SetAlarm(string time, DateTime rawTime, Alarm.AlarmStatus set, int snooze, string sound, bool edit, int index)
        {
            if (edit) model.EditAlarm(time, rawTime, set, snooze, sound, index);
            else model.AddAlarm(time, rawTime, set, snooze, sound);
        }
        /// <summary>
        /// Turns an alarm off.  Accesses model Alarm list to do so
        /// </summary>
        /// <param name="index"></param>
        public void StopAlarm(int index)
        {
            model.AlarmList[index].Set = Alarm.AlarmStatus.Off;
        }
        /// <summary>
        /// updates model alarm list bindings as alarms are added/edited
        /// </summary>
        public void UpdateBindings()
        {
            model.AlarmList.ResetBindings();
        }
        /// <summary>
        /// Updates text file as alarms are edited and added
        /// </summary>
        public void UpdateTextFile()
        {
            FileOperations fo = new FileOperations();
            fo.UpdateTextFile(model);
            /*
            string alarmFile = @"..\..\AlarmList.txt";
            if (File.Exists(alarmFile))
            {
                StreamWriter sr = new StreamWriter(alarmFile);
                foreach (Alarm al in model.AlarmList)
                {
                    sr.WriteLine(al.Time + "," + al.RawTime.ToString() + "," + 
                        al.Set.ToString() + "," + al.Snooze.ToString() + "," + al.Sound.ToString());
                    
                }
                sr.Close();
            }
            */
        }
        /// <summary>
        /// checks status of currently selected alarm
        /// </summary>
        /// <param name="running">bool representing if alarm is running</param>
        /// <param name="goneOff">bool representing if alarm has gone off</param>
        /// <param name="index">index of selected alarm in model alarm list</param>
        public void RunningStatusCheck(out bool running, out bool goneOff, int index)
        {
            Alarm tempAlarm = model.AlarmList[index];
            DateTime currentTime = DateTime.Now;
            goneOff = currentTime > tempAlarm.RawTime && tempAlarm.Set == Alarm.AlarmStatus.On;
            running = currentTime < tempAlarm.RawTime && tempAlarm.Set == Alarm.AlarmStatus.On;
        }
        /// <summary>
        /// Updates stop and snooze buttons by determining if alarm has gone off
        /// </summary>
        /// <param name="goneOff"></param>
        /// <param name="index"></param>
        public void SnoozeAndStopStatus(out bool goneOff, int index)
        {
            DateTime currentTime = DateTime.Now;//out param
            goneOff = currentTime > model.AlarmList[index].RawTime;
        }
        /// <summary>
        /// User can make an alarm snooze
        /// </summary>
        /// <param name="index"></param>
        public void Snooze(int index)
        {
            DateTime newTime = DateTime.Now.AddSeconds(model.AlarmList[index].Snooze);
            model.AlarmList[index].RawTime = newTime;
        }
    }
}
