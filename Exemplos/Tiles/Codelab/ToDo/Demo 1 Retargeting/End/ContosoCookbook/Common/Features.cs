using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;
using ContosoCookbook.Data;
using Microsoft.Phone.Marketplace;
using Microsoft.Phone.Scheduler;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace ContosoCookbook.Common
{
    public class Features
    {
        public class Notifications
        {
            public static void SetRemainder(RecipeDataItem item)
            {
                if (!IsScheduled(item.UniqueId))
                {
                    Microsoft.Phone.Scheduler.Reminder reminder = new Microsoft.Phone.Scheduler.Reminder(item.UniqueId);
                    reminder.Title = item.Title;
                    reminder.Content = "Did you finished?";
                    if (System.Diagnostics.Debugger.IsAttached)
                        reminder.BeginTime = DateTime.Now.AddMinutes(1);
                    else
                        reminder.BeginTime = DateTime.Now.Add(TimeSpan.FromMinutes(Convert.ToDouble(item.PrepTime)));
                    reminder.ExpirationTime = reminder.BeginTime.AddMinutes(5);
                    reminder.RecurrenceType = RecurrenceInterval.None;
                    reminder.NavigationUri = new Uri("/RecipeDetailPage.xaml?ID=" + item.UniqueId + "&GID=" + item.Group.UniqueId, UriKind.Relative);
                    ScheduledActionService.Add(reminder);
                }
                else
                {
                    var schedule = ScheduledActionService.Find(item.UniqueId);
                    ScheduledActionService.Remove(schedule.Name);
                }
            }

            public static bool IsScheduled(string name)
            {
                var schedule = ScheduledActionService.Find(name);
                if (schedule == null)
                {
                    return false;
                }
                else
                {
                    return schedule.IsScheduled;
                }
            }
        }

        public class Tile
        {
            public static bool TileExists(string NavSource)
            {
                ShellTile tile = ShellTile.ActiveTiles.FirstOrDefault(o => o.NavigationUri.ToString().Contains(NavSource));
                return tile == null ? false : true;
            }

            public static void DeleteTile(string NavSource)
            {
                ShellTile tile = ShellTile.ActiveTiles.FirstOrDefault(o => o.NavigationUri.ToString().Contains(NavSource));
                if (tile == null) return;

                tile.Delete();
            }

            public static void SetTile(RecipeDataItem item, string NavSource)
            {
                FlipTileData tileData = new FlipTileData()
                {
                    //Front square data
                    Title = item.Title,
                    BackgroundImage = new Uri(item.GetImageUri(), UriKind.Relative),
                    SmallBackgroundImage = new Uri(item.GetImageUri(), UriKind.Relative),

                    //Back square data
                    BackTitle = item.Title,
                    BackContent = makeString(item.Ingredients),
                    BackBackgroundImage = new Uri(item.Group.GetImageUri(), UriKind.Relative),

                    //Wide tile data
                    WideBackgroundImage = new Uri(item.GetImageUri(), UriKind.Relative),
                    WideBackBackgroundImage = new Uri(item.Group.GetImageUri(), UriKind.Relative),
                    WideBackContent = item.Directions
                };

                ShellTile.Create(new Uri(NavSource, UriKind.Relative), tileData, true);
            }

            private static string makeString(ObservableCollection<string> Ingredients)
            {
                string res = "";

                foreach (var ingredient in Ingredients)
                {
                    res += ingredient + "\n";
                }

                return res;
            }

            public static void SetGroupTile(RecipeDataGroup group, string NavSource)
            {
                List<Uri> list = new List<Uri>();
                foreach (var recipe in group.Items)
                    list.Add(new Uri(recipe.ImagePath.LocalPath, UriKind.Relative));

                CycleTileData tileData = new CycleTileData()
                {
                    Title = group.Title,
                    SmallBackgroundImage = new Uri(group.GetImageUri(), UriKind.RelativeOrAbsolute),
                    CycleImages = list
                };

                ShellTile.Create(new Uri(NavSource, UriKind.Relative), tileData, true);

            }

            public static void UpdateMainTile(RecipeDataGroup group)
            {
                //Get application's main tile
                var mainTile = ShellTile.ActiveTiles.FirstOrDefault();

                if (null != mainTile)
                {
                    IconicTileData tileData = new IconicTileData()
                    {
                        Count = group.RecipesCount,
                        BackgroundColor = Color.FromArgb(255, 195, 61, 39),
                        Title = "Contoso Cookbooks",
                        IconImage = new Uri("/Assets/MediumLogo.png", UriKind.RelativeOrAbsolute),
                        SmallIconImage = new Uri("/Assets/SmallLogo.png", UriKind.RelativeOrAbsolute),
                        WideContent1 = "Recent activity:",
                        WideContent2 = "Browsed " + group.Title + " group",
                        WideContent3 = "with total of " + group.RecipesCount + " recipes"
                    };

                    mainTile.Update(tileData);
                }
            }
        }
    }
}
