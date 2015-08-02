using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Custom_Data_Template.Resources;

namespace Custom_Data_Template
{
    public class Quote
    {
        public string shortmessage { get; set; }
        public string type { get; set; }
    }
    public abstract class DataTemplateSelector : ContentControl
    {
        public virtual DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return null;
        }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);

            ContentTemplate = SelectTemplate(newContent, this);
        }
    }
    public class QuoteTemplateSelector : DataTemplateSelector
    {
        public DataTemplate BQuote
        {
            get;
            set;
        }
        public DataTemplate Ad
        {
            get;
            set;
        }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Quote quoteItem = item as Quote;
            if (quoteItem != null)
            {
                if (quoteItem.type == "quote")
                {
                    return BQuote;
                }
                else if (quoteItem.type == "ad")
                {
                    return Ad;
                }
            }

            return base.SelectTemplate(item, container);
        }
    }
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            additems();
         }
        public void additems()
        {
            mylistbox.Items.Add(new Quote { shortmessage="Nice day", type="quote"});
            mylistbox.Items.Add(new Quote { shortmessage = "Warm day", type = "quote" });
            mylistbox.Items.Add(new Quote { shortmessage = "Cold day", type = "quote" });
            mylistbox.Items.Add(new Quote { shortmessage = "Rainy day", type = "quote" });
            mylistbox.Items.Add(new Quote { shortmessage = "Sultry day", type = "quote" });
            mylistbox.Items.Add(new Quote { shortmessage = string.Empty, type = "ad" });
            mylistbox.Items.Add(new Quote { shortmessage = "Windy day", type = "quote" });
            mylistbox.Items.Add(new Quote { shortmessage = "Stormy day", type = "quote" });
        }
    }
}