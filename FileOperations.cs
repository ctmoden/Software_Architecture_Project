using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;

namespace _501_P2
{
    /*
     * File reading and writing operatiosn for alarm file
     */
    public class FileOperations
    {
        private string FileName = @"..\..\AlarmList.txt";
        /// <summary>
        /// Populates alarm list
        /// </summary>
        /// <param name="model">reference to controller's model object</param>
        public void PopulateAlarmList(ref Model model)
        {
            if (File.Exists(FileName))
            {
                using (StreamReader sr = new StreamReader(FileName))
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
        }
        /// <summary>
        /// Updates text file with current model alarm list
        /// </summary>
        /// <param name="model">current model object from controller</param>
        public void UpdateTextFile(Model model)
        {
            if (File.Exists(FileName))
            {
                StreamWriter sr = new StreamWriter(FileName);
                foreach (Alarm al in model.AlarmList)
                {
                    sr.WriteLine(al.Time + "," + al.RawTime.ToString() + "," +
                        al.Set.ToString() + "," + al.Snooze.ToString() + "," + al.Sound.ToString());

                }
                sr.Close();
            }

        }
    }
}
