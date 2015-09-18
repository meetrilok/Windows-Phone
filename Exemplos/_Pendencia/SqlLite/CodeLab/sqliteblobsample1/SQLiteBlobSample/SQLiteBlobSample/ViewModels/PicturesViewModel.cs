using SQLiteWinRT;
using System.IO;
using System.Windows.Media.Imaging;
using System.Runtime.InteropServices.WindowsRuntime;

namespace SQLiteBlobSample.ViewModels
{
  public class PicturesViewModel : TableViewModelBase<PictureViewModel, int>
  {
    private PicturesViewModel() { }

    static PicturesViewModel instance;
    public static PicturesViewModel GetDefault()
    {
      lock (typeof(PicturesViewModel))
      {
        if (instance == null)
          instance = new PicturesViewModel();
      }

      return instance;
    }

    protected override string GetSelectAllSql()
    {
      return "SELECT Id, Name, Image FROM Pictures";
    }

    protected override void FillSelectAllStatement(SQLiteWinRT.Statement statement)
    {
      // nothing to do
    }

    protected override PictureViewModel CreateItem(SQLiteWinRT.Statement statement)
    {
      // Read the image from the BLOB column
        Windows.Storage.Streams.IBuffer blobBuffer = null;
        if (statement.GetColumnType(2) != ColumnType.Null)
        {
            blobBuffer = statement.GetBlobAt(2);
        }

        // Convert IBuffer back to a BitmapImage
        byte[] pictureBytes = blobBuffer.ToArray();

        var bitmapSource = new BitmapImage();

        using (MemoryStream ms = new MemoryStream(pictureBytes))
        {
            bitmapSource.CreateOptions = BitmapCreateOptions.None;
            ms.Seek(0, SeekOrigin.Begin);
            bitmapSource.SetSource(ms);
        };

      var c = new PictureViewModel(
        statement.GetIntAt(0),
        statement.GetTextAt(1),
        bitmapSource);

      return c;
    }

    protected override string GetSelectItemSql()
    {
      return "SELECT Id, Name, Image FROM Pictures WHERE Id = ?";
    }

    protected override void FillSelectItemStatement(SQLiteWinRT.Statement statement, int key)
    {
      statement.BindIntParameterAt(1, key);
    }

    protected override string GetInsertItemSql()
    {
      return "INSERT INTO Pictures (Name, Image) VALUES (@name, @image)";
    }

    protected override void FillInsertStatement(SQLiteWinRT.Statement statement, PictureViewModel item)
    {
      // Convert BitmapImage to byte array
      byte[] imagebytes = ConvertToBytes(item.Picture);
      // .. and from that to an IBuffer
      Windows.Storage.Streams.IBuffer imagebuffer = imagebytes.AsBuffer();

      // set the statement parameters
      statement.BindTextParameterWithName("@name", item.Name);
      statement.BindBlobParameterWithName("@image", imagebuffer);
    }

    private byte[] ConvertToBytes(BitmapImage bitmapImage)
    {
        byte[] data = null;
        using (MemoryStream stream = new MemoryStream())
        {
            WriteableBitmap wBitmap = new WriteableBitmap(bitmapImage);
            wBitmap.SaveJpeg(stream, wBitmap.PixelWidth, wBitmap.PixelHeight, 0, 100);
            stream.Seek(0, SeekOrigin.Begin);
            data = stream.GetBuffer();
        }

        return data;
    }

    protected override string GetUpdateItemSql()
    {
      return "UPDATE Pictures SET Name = ?, Image = ? WHERE Id = ?";
    }

    protected override void FillUpdateStatement(SQLiteWinRT.Statement statement, int key, PictureViewModel item)
    {
      // NOTE that the first host parameter has an index of 1, not 0.
      statement.BindTextParameterAt(1, item.Name);
      statement.BindBlobParameterAt(2, ConvertToBytes(item.Picture).AsBuffer());
      statement.BindIntParameterAt(3, key);
    }

    protected override string GetDeleteItemSql()
    {
      return "DELETE FROM Pictures WHERE Id = ?";
    }

    protected override void FillDeleteItemStatement(SQLiteWinRT.Statement statement, int key)
    {
      statement.BindIntParameterAt(1, key);
    }
  }
}
