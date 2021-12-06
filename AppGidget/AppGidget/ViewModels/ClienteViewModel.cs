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
using AppGidget.Views;

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
        private ClimaClase clima_actual = new ClimaClase();
        private string mensaje = "";

        public string Url { get => url; set { url = value; NotifyPropertyChanged(); } }

        public ClimaClase ClimaActual {get => clima_actual; set { clima_actual = value; NotifyPropertyChanged(); }}


        public string Mensaje { get => mensaje; set { mensaje = value; NotifyPropertyChanged(); } }

        public ICommand ConectarCommand { get; set; }
        public ICommand ActualizarClimaCommand { get; set; }

        public ClienteViewModel()
        {
            ConectarCommand = new Command(Connect);
            ActualizarClimaCommand = new Command(Update);
        }

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
                        var clima = JsonConvert.DeserializeObject<ClimaClase>(json);

                        if(clima != null) {
                            ClimaActual = clima;
                            Climas.Add(ClimaActual);
                        }

                    }
                }
                Mensaje = "La URL especificada es incorrecta";
            }
            catch (Exception ex) when (ex is Exception) { Mensaje = ex.ToString(); }
            catch (Exception ex) when (ex is IOException) { Mensaje = ex.ToString(); }
        }

        private void Update(object obj)
        {
            throw new NotImplementedException();
        }

    }
}
