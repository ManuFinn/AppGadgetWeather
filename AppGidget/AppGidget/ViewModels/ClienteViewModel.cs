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
using System.Runtime.CompilerServices;

namespace AppGidget.ViewModels
{
    public class ClienteViewModel : INotifyPropertyChanged
    {

        public List<ClimaClase> Climas { get; set; } =
            new List<ClimaClase>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName]string propertyname = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        // {"weather":{"main":"clouds","description":"broken clouds","temperature":18.19},
        // "datetime":{"date":"2021-12-06","time":"3:37 PM","isday":true}}

        private string url = "http://192.168.1.72/info";
        private ClimaClase clima = new ClimaClase();
        private string mensaje = "";

        public string Url { get => url; set { url = value; NotifyPropertyChanged(); } }

        public ClimaClase Clima {get => clima; set { clima = value; NotifyPropertyChanged(); }}

        public string Mensaje { get => mensaje; set { mensaje = value; NotifyPropertyChanged(); } }

        public ICommand ActualizarClima { get; }

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
