using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace AppGidget.Models {

    public class Tiempo : INotifyPropertyChanged {

        private DateTime date;
        private DateTime time;
        private bool isday;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName]string propertyname = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        [JsonProperty("date")]
        public DateTime Date { get => date; set { date = value; NotifyPropertyChanged(); } }

        [JsonProperty("time")]
        public DateTime Time { get => time; set { time = value; NotifyPropertyChanged(); } }

        [JsonProperty("isday")]
        public bool IsDay { get => isday; set { isday = value; NotifyPropertyChanged(); } }

    }

}