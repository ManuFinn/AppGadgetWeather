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
<<<<<<< HEAD
using System.Runtime.CompilerServices;
=======
using AppGidget.Views;
>>>>>>> 71da53d3c54963b605db8f2ac6c5c45195a49805

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

<<<<<<< HEAD
        public string Mensaje { get => mensaje; set { mensaje = value; NotifyPropertyChanged(); } }

        public ICommand ActualizarClima { get; }
=======
        public ICommand ConectarCommand { get; set; }
        public ICommand ActualizarClimaCommand { get; set; }
>>>>>>> 71da53d3c54963b605db8f2ac6c5c45195a49805

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
