using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace AppGidget.Models
{
    public class ClimaClase : INotifyPropertyChanged
    {
        
        // {"weather":{"main":"clouds","description":"broken clouds","temperature":18.19},
        // "datetime":{"date":"2021-12-06","time":"3:37 PM","isday":true}}

        private string main;
        private string description;
        private float temperature;
        private DateTime date;
        private DateTime time;
        private bool isday;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName]string propertyname = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        [JsonProperty("main")]
        public string Main { get => main; set { main = value; NotifyPropertyChanged(); } }

        [JsonProperty("description")]
        public string Description { get => description; set { description = value; NotifyPropertyChanged(); } }

        [JsonProperty("temperature")]
        public float Temperature { get => temperature; set { temperature = value; NotifyPropertyChanged(); } }

        [JsonProperty("date")]
        public DateTime Date { get => date; set { date = value; NotifyPropertyChanged(); } }

        [JsonProperty("time")]
        public DateTime Time { get => time; set { time = value; NotifyPropertyChanged(); } }

        [JsonProperty("isday")]
        public bool IsDay { get => isday; set { isday = value; NotifyPropertyChanged(); } }

    }
}
