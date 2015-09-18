using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Lazy_Loading_ListView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int offset = 0;
        bool incall = false, endoflist=false;
        public class Countries
        {
            public string name { get; set; }
        }
        public static ObservableCollection<Countries> category_stories = new ObservableCollection<Countries>();
        public static string[] Names = new string[]
        {
	    "Afghanistan",
	    "Albania",
	    "Algeria",
	    "American Samoa",
	    "Andorra",
	    "Angola",
	    "Anguilla",
	    "Antarctica",
	    "Antigua and Barbuda",
	    "Argentina",
	    "Armenia",
	    "Aruba",
	    "Australia",
	    "Austria",
	    "Azerbaijan",
	    "Bahamas",
	    "Bahrain",
	    "Bangladesh",
	    "Barbados",
	    "Belarus",
	    "Belgium",
	    "Belize",
	    "Benin",
	    "Bermuda",
	    "Bhutan",
	    "Bolivia",
	    "Bosnia and Herzegovina",
	    "Botswana",
	    "Bouvet Island",
	    "Brazil",
	    "British Indian Ocean Territory",
	    "Brunei Darussalam",
	    "Bulgaria",
	    "Burkina Faso",
	    "Burundi",
	    "Cambodia",
	    "Cameroon",
	    "Canada",
	    "Cape Verde",
	    "Cayman Islands",
	    "Central African Republic",
	    "Chad",
	    "Chile",
	    "China",
	    "Christmas Island",
	    "Cocos (Keeling) Islands",
	    "Colombia",
	    "Comoros",
	    "Congo",
	    "Congo, the Democratic Republic of the",
	    "Cook Islands",
	    "Costa Rica",
	    "Cote D'Ivoire",
	    "Croatia",
	    "Cuba",
	    "Cyprus",
	    "Czech Republic",
	    "Denmark",
	    "Djibouti",
	    "Dominica",
	    "Dominican Republic",
	    "Ecuador",
	    "Egypt",
	    "El Salvador",
	    "Equatorial Guinea",
	    "Eritrea",
	    "Estonia",
	    "Ethiopia",
	    "Falkland Islands (Malvinas)",
	    "Faroe Islands",
	    "Fiji",
	    "Finland",
	    "France",
	    "French Guiana",
	    "French Polynesia",
	    "French Southern Territories",
	    "Gabon",
	    "Gambia",
	    "Georgia",
	    "Germany",
	    "Ghana",
	    "Gibraltar",
	    "Greece",
	    "Greenland",
	    "Grenada",
	    "Guadeloupe",
	    "Guam",
	    "Guatemala",
	    "Guinea",
	    "Guinea-Bissau",
	    "Guyana",
	    "Haiti",
	    "Heard Island and Mcdonald Islands",
	    "Holy See (Vatican City State)",
	    "Honduras",
	    "Hong Kong",
	    "Hungary",
	    "Iceland",
	    "India",
	    "Indonesia",
	    "Iran, Islamic Republic of",
	    "Iraq",
	    "Ireland",
	    "Israel",
	    "Italy",
	    "Jamaica",
	    "Japan",
	    "Jordan",
	    "Kazakhstan",
	    "Kenya",
	    "Kiribati",
	    "Korea, Democratic People's Republic of",
	    "Korea, Republic of",
	    "Kuwait",
	    "Kyrgyzstan",
	    "Lao People's Democratic Republic",
	    "Latvia",
	    "Lebanon",
	    "Lesotho",
	    "Liberia",
	    "Libyan Arab Jamahiriya",
	    "Liechtenstein",
	    "Lithuania",
	    "Luxembourg",
	    "Macao",
	    "Macedonia, the Former Yugoslav Republic of",
	    "Madagascar",
	    "Malawi",
	    "Malaysia",
	    "Maldives",
	    "Mali",
	    "Malta",
	    "Marshall Islands",
	    "Martinique",
	    "Mauritania",
	    "Mauritius",
	    "Mayotte",
	    "Mexico",
	    "Micronesia, Federated States of",
	    "Moldova, Republic of",
	    "Monaco",
	    "Mongolia",
	    "Montserrat",
	    "Morocco",
	    "Mozambique",
	    "Myanmar",
	    "Namibia",
	    "Nauru",
	    "Nepal",
	    "Netherlands",
	    "Netherlands Antilles",
	    "New Caledonia",
	    "New Zealand",
	    "Nicaragua",
	    "Niger",
	    "Nigeria",
	    "Niue",
	    "Norfolk Island",
	    "Northern Mariana Islands",
	    "Norway",
	    "Oman",
	    "Pakistan",
	    "Palau",
	    "Palestinian Territory, Occupied",
	    "Panama",
	    "Papua New Guinea",
	    "Paraguay",
	    "Peru",
	    "Philippines",
	    "Pitcairn",
	    "Poland",
	    "Portugal",
	    "Puerto Rico",
	    "Qatar",
	    "Reunion",
	    "Romania",
	    "Russian Federation",
	    "Rwanda",
	    "Saint Helena",
	    "Saint Kitts and Nevis",
	    "Saint Lucia",
	    "Saint Pierre and Miquelon",
	    "Saint Vincent and the Grenadines",
	    "Samoa",
	    "San Marino",
	    "Sao Tome and Principe",
	    "Saudi Arabia",
	    "Senegal",
	    "Serbia and Montenegro",
	    "Seychelles",
	    "Sierra Leone",
	    "Singapore",
	    "Slovakia",
	    "Slovenia",
	    "Solomon Islands",
	    "Somalia",
	    "South Africa",
	    "South Georgia and the South Sandwich Islands",
	    "Spain",
	    "Sri Lanka",
	    "Sudan",
	    "Suriname",
	    "Svalbard and Jan Mayen",
	    "Swaziland",
	    "Sweden",
	    "Switzerland",
	    "Syrian Arab Republic",
	    "Taiwan, Province of China",
	    "Tajikistan",
	    "Tanzania, United Republic of",
	    "Thailand",
	    "Timor-Leste",
	    "Togo",
	    "Tokelau",
	    "Tonga",
	    "Trinidad and Tobago",
	    "Tunisia",
	    "Turkey",
	    "Turkmenistan",
	    "Turks and Caicos Islands",
	    "Tuvalu",
	    "Uganda",
	    "Ukraine",
	    "United Arab Emirates",
	    "United Kingdom",
	    "United States",
	    "United States Minor Outlying Islands",
	    "Uruguay",
	    "Uzbekistan",
	    "Vanuatu",
	    "Venezuela",
	    "Viet Nam",
	    "Virgin Islands, British",
	    "Virgin Islands, US",
	    "Wallis and Futuna",
	    "Western Sahara",
	    "Yemen",
	    "Zambia",
	    "Zimbabwe",
        };
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        // method to pull out a ScrollViewer
        public static ScrollViewer GetScrollViewer(DependencyObject depObj)
        {
            if (depObj is ScrollViewer) return depObj as ScrollViewer;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);

                var result = GetScrollViewer(child);
                if (result != null) return result;
            }
            return null;
        }

        private void storylist_Loaded(object sender, RoutedEventArgs e)
        {
            ScrollViewer viewer = GetScrollViewer(this.storylist);
            viewer.ViewChanged += MainPage_ViewChanged;
        }

        private async void MainPage_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            ScrollViewer view = (ScrollViewer)sender;
            double progress = view.VerticalOffset / view.ScrollableHeight;
            System.Diagnostics.Debug.WriteLine(progress);
            if (progress > 0.7 & !incall && !endoflist)
            {
                incall = true;
                progressring.IsActive = true;
                fetchCountries(++offset);
            }
        }

        private void fetchCountries(int offset)
        {
            int start = offset * 20;
            for (int i = start; i < start + 20; i++) { 
                if(i<Names.Length)
                    category_stories.Add(new Countries { name = Names[i] });
                else
                {
                    endoflist= true;
                    break;
                }
            }
            progressring.IsActive = false;
            incall = false;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            storylist.ItemsSource = category_stories;
            fetchCountries(0);
        }
    }
}
