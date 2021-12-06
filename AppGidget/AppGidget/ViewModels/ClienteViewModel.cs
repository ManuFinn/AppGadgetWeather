using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.ComponentModel;
using AppGidget.Models;

namespace AppGidget.ViewModels
{
    public class ClienteViewModel
    {
        public string url { get; set; } = "http://192.168.1.72/info";

        public List<ClimaClase> Climas { get; set; } =
            new List<ClimaClase>();

        // {"weather":{"main":"clouds","description":"broken clouds","temperature":18.19},
        // "datetime":{"date":"2021-12-06","time":"3:37 PM","isday":true}}

        private string main, description;
        private int temperature;
        private DateTime date, time;
        private bool isday;

        public string Mainx { get { return main; } set { main = value; } }
        public string Descriptionx { get { return description; } set { description = value; } }
        public int Temperaturex { get { return temperature; } set { temperature = value; } }
        public DateTime Datex { get { return date; } set { date = value; } }
        public DateTime Timex { get { return time; } set { time = value; } }
        public bool IsDay { get { return isday; } set { isday = value; } }

        public string mensaje { get; set; }

        public ICommand ActualizarClima { get; set; }

        public ClienteViewModel()
        {
            ActualizarClima = new Command(Update);
        }

        private void Update(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
