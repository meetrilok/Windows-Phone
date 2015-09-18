
using System.Windows.Media.Imaging;
namespace SQLiteBlobSample.ViewModels
{
  public class PictureViewModel : ViewModelBase
  {
    #region Properties

    private int id = -1;
    public int Id
    {
      get { return id; }
      //set { SetProperty(ref id, value); }
    }

    private string name = string.Empty;
    public string Name
    {
      get { return name; }
      set { if (SetProperty(ref name, value)) IsDirty = true; }
    }

    private BitmapImage picture;
    public BitmapImage Picture
    {
        get { return picture; }
        set { if (SetProperty(ref picture, value)) IsDirty = true; }
    }

    private bool isDirty = false;
    public bool IsDirty
    {
      get { return isDirty; }
      set { SetProperty(ref isDirty, value); }
    }

    #endregion "Properties"

    internal PictureViewModel()
    { 
    }

    internal PictureViewModel(int id, string name, BitmapImage image)
    {
      this.id = id;
      this.name = name;
      this.picture = image;
      this.isDirty = false;
    }

    public bool IsNew { get { return Id < 0; } }
  }
}
