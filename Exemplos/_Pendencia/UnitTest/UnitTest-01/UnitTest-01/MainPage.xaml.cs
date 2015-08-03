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



namespace UnitTest_01
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        public class Temperatura
        {
            // Campos
            public Double dCelsius;
            public Double dFahrenheit;

            // Construtor
            public Temperatura ()
            {
                dCelsius = 0.0;
                dFahrenheit = 0.0;
            }
            public void Fahrenheit (double Fahrenheit)
            {
                dFahrenheit = Fahrenheit;
            }

            // Metodo
            public void Celsius ( )
            {
                dCelsius = (((dFahrenheit / 5) * 9) + 32);
                //return (dCelsius);
            }

            public double GetCelsius ()
            {
                return dCelsius;
            }

            public double GetFahrenheit()
            {
                return dFahrenheit;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void btnExecuta_Click(object sender, RoutedEventArgs e)
        {
            Temperatura Converte = new Temperatura();
            String strValor = "";
            double dAux1 = 0.0;
            double dAux2 = 0.0;

            dAux2 = Convert.ToDouble(txtDigita.Text);
            Converte.Fahrenheit(dAux2);
            Converte.Celsius();

            dAux1 = Converte.dCelsius;
            strValor = Convert.ToString(dAux1);
            lblResultado.Text = strValor;

        }
    }
}
