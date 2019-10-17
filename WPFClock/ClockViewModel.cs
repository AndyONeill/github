using System;
using System.ComponentModel;
using System.Timers;
using GalaSoft.MvvmLight;

namespace WPFClock
{
    public class ClockViewModel : ViewModelBase
    {
        private Timer timer = new Timer(1000);
        public ClockViewModel()
        {
            timer.Elapsed += new ElapsedEventHandler((sender, e) => 
            {
                RaisePropertyChanged("SecondsDegrees");
                RaisePropertyChanged("MinutesDegrees");
                RaisePropertyChanged("HoursDegrees");
                RaisePropertyChanged("DayOfMonth");
            }  );
            timer.Start();
        }

        public int SecondsDegrees
        {
            get
            {
                return DateTime.Now.Second * 6;
            }
        }

        public int MinutesDegrees
        {
            get
            {
                return DateTime.Now.Minute * 6;
            }
        }

        public int HoursDegrees
        {
            get
            {
                return DateTime.Now.Hour * 30 + (int)(DateTime.Now.Minute / 2);
            }
        }
        public int DayOfMonth
        {
            get
            {
                return DateTime.Now.Day;
            }
        }
    }
}

