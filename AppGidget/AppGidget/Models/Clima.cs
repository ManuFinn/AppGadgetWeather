using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace AppGidget.Models {

    public class Clima : INotifyPropertyChanged {

        private string main;
        private string description;
        private float temperature;

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

    }   

}