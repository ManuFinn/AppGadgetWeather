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
using AppGidget.Views;

namespace AppGidget.ViewModels
{
    public class ClienteViewModel : INotifyPropertyChanged
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

        public ICommand ConectarCommand { get; set; }
        public ICommand ActualizarClimaCommand { get; set; }

        public ClienteViewModel()
        {
            ConectarCommand = new Command(Connect);
            ActualizarClimaCommand = new Command(Update);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private async void Connect()
        {
            Uri uri;

            try
            {
                if(Uri.TryCreate(url, UriKind.Absolute, out uri))
                {
                    PrincipalPage page = new PrincipalPage() { BindingContext = this };
                    await App.Current.MainPage.Navigation.PushAsync(page);

                    HttpClient client = new HttpClient();
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var clima = JsonConvert.DeserializeObject<List<ClimaClase>>(json);

                        Climas = clima;

                    }
                }
                mensaje = "La URL especificada es incorrecta";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(mensaje)));
            }
            catch (Exception ex) when (ex is Exception) { mensaje = ex.ToString(); }
            catch (Exception ex) when (ex is IOException) { mensaje = ex.ToString(); }
        }

        private void Update(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
