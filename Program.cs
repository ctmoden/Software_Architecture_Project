using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _501_P2
{
    public delegate void SoundAlarm(Alarm al);
    public delegate void StatusCheck();
    public delegate void SetAlarm(string t, DateTime rt, Alarm.AlarmStatus s, int sn, string so, bool e, int i);
    public delegate void UpdateBindings();
    public delegate void UpdateTextFile();
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Model model = new Model();
            Controller controller = new Controller(model);
            View view = new View(controller);
            SoundAlarm soundAlarm = view.SoundAlarm;
            StatusCheck statusCheck = view.RunningStatusCheck;
            controller.SetDelegates(soundAlarm, statusCheck);//change to have two
            Application.Run(view);
        }
    }
}
