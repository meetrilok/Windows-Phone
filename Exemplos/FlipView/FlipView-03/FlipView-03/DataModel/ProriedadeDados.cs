using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ====================================================================
// Insercao Obrigatoria
// ====================================================================

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Resources.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace FlipViewControle
{
    [Windows.Foundation.Metadata.WebHostHidden]
    public abstract class ProriedadeDados : SDKTemplate.Common.AplicaPropriedade
    {
        private static Uri _baseUri = new Uri("ms-appx:///");

        public ProriedadeDados ( String strTitulo, String strImagem )
        {
            this._title = strTitulo;
            this._picture = strImagem;
        }

        private string _title = string.Empty;
        public string Title
        {
            get { return this._title; }
            set { this.SetProperty(ref this._title, value); }
        }

        private Uri _image = null;
        private String _picture = null;
        public Uri Image
        {
            get
            {
                return new Uri(ProriedadeDados._baseUri, this._picture);
            }

            set
            {
                this._picture = null;
                this.SetProperty(ref this._image, value);
            }
        }
    }

    public class ItemImagem : ProriedadeDados
    {
        public ItemImagem(String title, String picture) : base(title, picture)
        {
        }
    }

    public sealed class DefineDadosImagem
    {
        private ObservableCollection<object> _items = new ObservableCollection<object>();
        public ObservableCollection<object> Items
        {
            get { return this._items; }
        }

        public DefineDadosImagem()
        {
            Items.Add(new ItemImagem ("Penhasco", "Images/Cliff.jpg"));
            Items.Add(new ItemImagem ("Uvas", "Images/Grapes.jpg"));
            Items.Add(new ItemImagem ("Montanha", "Images/Rainier.jpg"));
            Items.Add(new ItemImagem ("Pôr do Sol", "Images/Sunset.jpg"));
            Items.Add(new ItemImagem ("Vale",  "Images/Valley.jpg"  ));
            Items.Add(new ItemImagem ("Cachoeira", "Images/waterfall.jpg"));
        }
    }
}


