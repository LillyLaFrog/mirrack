using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mirrack.Services
{
    internal class TimeService
    {
        public static event Action? DayChanged;
        public static event Action? HourChanged;
        public static event Action? MinChanged;
        public static event Action? SecondChanged;
        public static async void KeepTime()
        {
            //called once at startup
            //set time varibles as current time to reset at midnight
            DateTime time = DateTime.Now;
            int Mins = time.Minute;
            int Hours = time.Hour;
            int Seconds = time.Second;
            PeriodicTimer timer = new(TimeSpan.FromSeconds(1));
            while (await timer.WaitForNextTickAsync())
            {
                //increment seconds every second
                SecondChanged?.Invoke();
                Seconds++;
                if(Seconds == 60)
                {
                    //incement Mins by one, reset second flag
                    Seconds = 0;
                    MinChanged?.Invoke();
                    Mins++;
                    if (Mins == 60)
                    {
                        //increment hours by one, reset min flag
                        Mins = 0;
                        HourChanged?.Invoke();
                        Hours++;
                        if (Hours == 24)
                        {
                            //increment days by one, reset hour flag
                            Hours = 0;
                            DayChanged?.Invoke();
                        }
                    }
                }

            }
        }
    }
}
