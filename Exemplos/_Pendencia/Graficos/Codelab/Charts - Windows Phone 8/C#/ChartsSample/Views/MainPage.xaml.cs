using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ChartsSample.Resources;
using System.Collections.ObjectModel;
using ChartsSample.Models;

namespace ChartsSample
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            //Pie Chart Data Source
            ObservableCollection<PieData> PieDataCollection = new ObservableCollection<PieData>()
            {
                new PieData() { Title = "Title 1", Value = 30 },
                new PieData() { Title = "Title 2", Value = 60 },
                new PieData() { Title = "Title 3", Value = 40 }
            };
            PieChart.DataSource = PieDataCollection;

            //Line Chart Data Source
            ObservableCollection<LineData> LineDataCollection = new ObservableCollection<LineData>()
            {
                new LineData { Category = "E1", Line1 = 80, Line2 = 40, Line3 = 50 },
                new LineData { Category = "E2", Line1 = 50, Line2 = 70, Line3 = 40 },
                new LineData { Category = "E3", Line1 = 60, Line2 = 50, Line3 = 20 },
                new LineData { Category = "E4", Line1 = 10, Line2 = 30, Line3 = 50 },
                new LineData { Category = "E5", Line1 = 40, Line2 = 10, Line3 = 70 }
            };
            LineChart.DataSource = LineDataCollection;

            //Bar Chart Data Source
            ObservableCollection<BarData> BarDataCollection = new ObservableCollection<BarData>()
            {
                new BarData { Category = "E1", Value = 80 },
                new BarData { Category = "E2", Value = 50 },
                new BarData { Category = "E3", Value = 60 },
                new BarData { Category = "E4", Value = 10 },
                new BarData { Category = "E5", Value = 40 }
            };
            BarChart.DataSource = BarDataCollection;

            //Mixed Chart Data Source, it's the same as the Line Chart
            MixedChart.DataSource = LineDataCollection;
        }

    }
}