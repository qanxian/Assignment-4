// See https://aka.ms/new-console-template for more information
using System.Data;

namespace myAlarm
{
    public class Alarm
    {
        public class Clock
        {
            DateTime dateTime = DateTime.Now;

            public delegate void alarmHandle(object sender, DateTime args);
            public delegate void tickHandle(object sender, DateTime args);
            public event alarmHandle alarming;
            public event tickHandle ticking;
            public void alarm(object sender, DateTime time)     //响铃
            {
                Console.WriteLine("Set the time to: " + time);
            }
            public void tick(object sender, DateTime time)      //滴答
            {
                Console.WriteLine("The current time is: " + time);
            }
            public Clock()
            {
                alarming = alarming + alarm;
                ticking = ticking + tick;
            }
            public void Start()
            {
                while (true)
                {
                    DateTime now = DateTime.Now;
                    ticking(this, now);
                    if (now.ToString() == dateTime.ToString())      //在此刻响铃
                    {
                        alarming(this, dateTime);
                    }
                    Thread.Sleep(1000);
                }
            }
            public void SetAlarmTime(DateTime atime)
            {
                Console.WriteLine(atime);
                dateTime = atime;
            }
        }
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            DateTime atime = new DateTime();

            Random ran = new Random();
            int n = ran.Next(10);

            atime = DateTime.Now.AddSeconds(n);     //随机数响铃
            clock.SetAlarmTime(atime);
            clock.Start();
        }
    }
}
