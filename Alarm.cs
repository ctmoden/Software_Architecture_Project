/*
 * Author: Christian Moden
 * Alarm.cs
 * Class representing properties of alarm object
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _501_P2
{
    public class Alarm
    {//test push
        /// <summary>
        /// Alarm info as a string
        /// </summary>
        public string Info => this.ToString();
        //props needed: time, on/off, 
        /// <summary>
        /// Time alarm is set for in a string format
        /// fixme Need to have display time and actual time to elimate seconds off display
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// Holds raw time of alarm setting
        /// FIXME do I really need this?
        /// </summary>
        public DateTime RawTime { get; set; }
        /// <summary>
        /// Reflects is alarm is se to on or off
        /// </summary>
        public AlarmStatus Set { get; set; }

        //public DateTime FullTime { get; set; }
        /// <summary>
        /// Enum of alarm status options
        /// </summary>
        public enum AlarmStatus
        {
            Off,
            On
        }
        /// <summary>
        /// Amount of snooze time in seconds
        /// </summary>
        public int Snooze { get; set; }
        /// <summary>
        /// Available sounds for an alarm
        /// </summary>
        public enum AlarmSound
        {
            Radar,
            Beacon,
            Chimes,
            Circuit,
            Reflection
        }
        /// <summary>
        /// alarm sound
        /// </summary>
        public AlarmSound Sound { get; set; }
        /// <summary>
        /// Override to string method
        /// </summary>
        /// <returns>string listing alarm info in listbox control</returns>
        public override string ToString()
        {
            return Time + ", " + Set.ToString();
        }
    }
}
