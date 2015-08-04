using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Phone.Shell;

namespace CAPPLOUD.WP.Controllers
{
    public class ApplicationBarController
    {
        IApplicationBar _appbar;

        public ApplicationBarController(IApplicationBar appbar)
        {
            this._appbar = appbar;
        }

        Dictionary<string, IApplicationBarIconButton> Buttons { get; set; }
        Dictionary<string, IApplicationBarMenuItem> MenuItems { get; set; }

        /// <summary>
        /// Add new Menu Item to the collection.
        /// Must call ShowMenuItems or ShowMenuItem to show the menu
        /// </summary>
        /// <param name="Text">Name of the menu item</param>
        /// <param name="isEnabled"></param>
        /// <param name="e">Delegated event</param>
        public void AddNewMenuItem(string Text, bool isEnabled, EventHandler e)
        {
            if (MenuItems == null)
            {
                MenuItems = new Dictionary<string, IApplicationBarMenuItem>();
            }

            if (MenuItems.ContainsKey(Text)) { return; }

            ApplicationBarMenuItem menuitem = new ApplicationBarMenuItem()
            {
                Text = Text,
                IsEnabled = isEnabled
            };
            menuitem.Click += e;

            MenuItems.Add(Text, menuitem);
        }
        /// <summary>
        /// Add new Icon Button to the collection.
        /// Must call ShowButtons or Showbutton to show the icon button
        /// </summary>
        /// <param name="Text">Text of the icon button</param>
        /// <param name="IconUri">Relative image url</param>
        /// <param name="isEnabled"></param>
        /// <param name="e">Delegated event</param>
        public void AddNewButton(string Text, string IconUri, bool isEnabled, EventHandler e)
        {
            if (Buttons == null)
            {
                Buttons = new Dictionary<string, IApplicationBarIconButton>();
            }

            if (Buttons.ContainsKey(Text)) { return; }

            ApplicationBarIconButton btn = new ApplicationBarIconButton()
            {
                Text = Text,
                IconUri = new Uri(IconUri, UriKind.Relative),
                IsEnabled = isEnabled
            };
            btn.Click += e;
            
            Buttons.Add(Text, btn);
        }

        /// <summary>
        /// Replace and show selected buttons in the application bar
        /// </summary>
        /// <param name="ButtonText">Icon Button texts to show</param>
        public void ShowButtons(params string[] ButtonText)
        {
            this._appbar.Buttons.Clear();

            foreach (string text in ButtonText)
            {
                if (!_appbar.Buttons.Contains(Buttons[text]))
                {
                    _appbar.Buttons.Add(Buttons[text]);
                }
            }
        }
        /// <summary>
        /// Append the icon button in the application bar
        /// </summary>
        /// <param name="ButtonText">Icon Button texts to show</param>
        public void ShowButton(params string[] ButtonText)
        {
            foreach (string text in ButtonText)
            {
                if (!_appbar.Buttons.Contains(Buttons[text]))
                {
                    _appbar.Buttons.Add(Buttons[text]);
                }
            }
        }
        /// <summary>
        /// Remove selected buttonsin the application bar
        /// </summary>
        /// <param name="ButtonText">Icon Button texts to show</param>
        public void RemoveButtons(params string[] ButtonText)
        {
            foreach (string text in ButtonText)
            {
                if (_appbar.Buttons.Contains(Buttons[text]))
                {
                    _appbar.Buttons.Remove(Buttons[text]);
                }
            }
        }
        /// <summary>
        /// Clear all Icon Buttons in the application bar
        /// </summary>
        public void RemoveButtons()
        {
            this._appbar.Buttons.Clear();
        }
        /// <summary>
        /// Enable or Disable selected buttons
        /// </summary>
        /// <param name="Enabled"></param>
        /// <param name="ButtonText">Icon Button texts to Enable or Disable</param>
        public void EnableButtons(bool Enabled, params string[] ButtonText)
        {
            foreach (string text in ButtonText)
            {
                Buttons[text].IsEnabled = Enabled;
            }
        }

        /// <summary>
        /// Replace and show selected menu items in the application bar
        /// </summary>
        /// <param name="MenuItemText">menu items texts to show</param>
        public void ShowMenuItems(params string[] MenuItemText)
        {
            this._appbar.MenuItems.Clear();

            foreach (string text in MenuItemText)
            {
                if (!_appbar.MenuItems.Contains(MenuItems[text]))
                {
                    _appbar.MenuItems.Add(MenuItems[text]);
                }
            }
        }
        /// <summary>
        /// Append the menu items in the application bar
        /// </summary>
        /// <param name="MenuItemText">menu items texts to show</param>
        public void ShowMenuItem(params string[] MenuItemText)
        {
            foreach (string text in MenuItemText)
            {
                if (!_appbar.MenuItems.Contains(MenuItems[text]))
                {
                    _appbar.MenuItems.Add(MenuItems[text]);
                }
            }
        }
        /// <summary>
        /// Remove selected menu items in the application bar
        /// </summary>
        /// <param name="MenuItemText">menu items texts to show</param>
        public void RemoveMenuItems(params string[] MenuItemText)
        {
            foreach (string text in MenuItemText)
            {
                if (_appbar.MenuItems.Contains(MenuItems[text]))
                {
                    _appbar.MenuItems.Remove(MenuItems[text]);
                }
            }
        }
        /// <summary>
        /// Clear all menu items in the application bar
        /// </summary>
        public void RemoveMenuItems()
        {
            _appbar.MenuItems.Clear();
        }
        /// <summary>
        /// Enable or Disable selected menu items
        /// </summary>
        /// <param name="Enabled"></param>
        /// <param name="MenuItemText">menu items texts to Enable or Disable</param>
        public void EnableMenuItems(bool Enabled, params string[] MenuItemText)
        {
            foreach (string text in MenuItemText)
            {
                MenuItems[text].IsEnabled = Enabled;
            }
        }

        /// <summary>
        /// Show or Hide application bar
        /// </summary>
        /// <param name="Show"></param>
        public void ShowAppBar(bool Show)
        {
            if (this._appbar.IsVisible != Show)
            {
                this._appbar.IsVisible = Show;
            }
        }
    }
}
