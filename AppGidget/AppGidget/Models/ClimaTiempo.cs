using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace AppGidget.Models
{
    public class ClimaTiempo : INotifyPropertyChanged
    {
        
        // {"weather":{"main":"clouds","description":"broken clouds","temperature":18.19},
        // "datetime":{"date":"2021-12-06","time":"3:37 PM","isday":true}}

        private Clima clima;
        private Tiempo tiempo;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName]string propertyname = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        [JsonProperty("weather")]
        public Clima Clima { get => clima; set { clima = value; NotifyPropertyChanged(); } }

        [JsonProperty("datetime")]
        public Tiempo Tiempo { get => tiempo; set { tiempo = value; NotifyPropertyChanged(); } }

    }
}
