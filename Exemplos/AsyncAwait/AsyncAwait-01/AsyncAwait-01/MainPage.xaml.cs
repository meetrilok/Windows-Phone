using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// ====================================================================
// Inserção Obrigatória
// ====================================================================

using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Windows.Storage;

namespace AsyncAwait_01
{   
    public sealed partial class MainPage : Page
    {    
        private const string JSONFILE = "data.json";    

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void EscreveJson(object sender, RoutedEventArgs e)
        {
            await EscreveJsonAssincrono();
        }

        private async void LeJson(object sender, RoutedEventArgs e)
        {
            await LeJsonAsync();
        }

        private List<Car> buildObjectGraph()
        {
            var MeusCarros = new List<Car>();

            MeusCarros.Add(new Car() { Id = 1, Fabricante = "Fiat", Modelo = "Oggi", Ano = 1983 });
            MeusCarros.Add(new Car() { Id = 2, Fabricante = "Ford", Modelo = "Belina", Ano = 1977 });
            MeusCarros.Add(new Car() { Id = 3, Fabricante = "Chevrolet", Modelo = "Chevette", Ano = 1973 });

            return MeusCarros;
        }

        private async Task EscreveJsonAssincrono()
        {
            var MeusCarros = buildObjectGraph();

            var serializer = new DataContractJsonSerializer(typeof(List<Car>));
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(
                          JSONFILE,
                          CreationCollisionOption.ReplaceExisting))
            {
                serializer.WriteObject(stream, MeusCarros);
            }

            resultTextBlock.Text = "Dados Gravados com Sucesso";
        }


        private async Task readJsonAsync()
        {
            string content = String.Empty;

            var myStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(JSONFILE);
            using (StreamReader reader = new StreamReader(myStream))
            {
                content = await reader.ReadToEndAsync();
            }

            resultTextBlock.Text = content;
        }

        private async Task LeJsonAsync()
        {
            string content = String.Empty;

            List<Car> myCars;
            var jsonSerializer = new DataContractJsonSerializer(typeof(List<Car>));

            var myStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(JSONFILE);

            myCars = (List<Car>)jsonSerializer.ReadObject(myStream);

            foreach (var car in myCars)
            {
                content += String.Format(" ID: {0} \n Make: {1} \n Model: {2} \n Ano: {3} \n", car.Id, car.Fabricante, car.Modelo, car.Ano);
            }

            resultTextBlock.Text = content;
        }
    }
}
