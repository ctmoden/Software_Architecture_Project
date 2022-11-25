using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _501_P2
{
    public class Model
    {
        /// <summary>
        /// List storing all alarms
        /// </summary>
        public BindingList<Alarm> AlarmList;
        public Model()
        {
            
            AlarmList = new BindingList<Alarm>();
            AlarmList.AllowNew = true;
            //now this is composition... earlier was association
        }
        /// <summary>
        /// Adds an alarm to the list
        /// </summary>
        /// <param name="t">Time of alarm</param>
        /// <param name="rt">DateTime format of alarm time</param>
        /// <param name="s">Alarm set status</param>
        public void AddAlarm(string t, DateTime rt, Alarm.AlarmStatus s, int snooze, string sound)
        {
            Alarm al = new Alarm
            {
                Time = t,
                RawTime = rt,
                Set = s,
                Snooze = snooze,
                Sound = (Alarm.AlarmSound)Enum.Parse(typeof(Alarm.AlarmSound), sound)
        };
            AlarmList.Add(al);
        }
        /// <summary>
        /// Edist and alarm already in the list
        /// </summary>
        /// <param name="t">Time of alarm</param>
        /// <param name="rt">DateTime format of time</param>
        /// <param name="s">Alarm Set status</param>
        /// <param name="i">index of alarm in list being modified </param>
        public void EditAlarm(string t, DateTime rt, Alarm.AlarmStatus s, int snooze, string sound, int i)
        {
            AlarmList[i].Time = t;
            AlarmList[i].RawTime = rt;
            AlarmList[i].Set = s;
            AlarmList[i].Snooze = snooze;
            AlarmList[i].Sound = (Alarm.AlarmSound)Enum.Parse(typeof(Alarm.AlarmSound),sound);

        }
    }
}
