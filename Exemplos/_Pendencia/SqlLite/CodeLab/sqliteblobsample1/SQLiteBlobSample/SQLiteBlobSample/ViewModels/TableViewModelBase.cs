using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SQLiteBlobSample.ViewModels
{
  public abstract class TableViewModelBase<TItemType, TKeyType>
  {
    protected abstract string GetSelectAllSql();
    protected abstract void FillSelectAllStatement(SQLiteWinRT.Statement statement);

    protected abstract TItemType CreateItem(SQLiteWinRT.Statement statement);
    
    protected abstract string GetSelectItemSql();
    protected abstract void FillSelectItemStatement(SQLiteWinRT.Statement statement, TKeyType key);

    protected abstract string GetDeleteItemSql();
    protected abstract void FillDeleteItemStatement(SQLiteWinRT.Statement statement, TKeyType key);
    
    protected abstract string GetInsertItemSql();
    protected abstract void FillInsertStatement(SQLiteWinRT.Statement statement, TItemType item);
    
    protected abstract string GetUpdateItemSql();
    protected abstract void FillUpdateStatement(SQLiteWinRT.Statement statement, TKeyType key, TItemType item);

    protected DateTime lastModifiedTime = DateTime.MaxValue;
    public virtual DateTime Timestamp
    {
      get { return lastModifiedTime; }
      protected set { lastModifiedTime = value; }
    }

    public async Task<ObservableCollection<TItemType>> GetAllItems()
    {
      var items = new ObservableCollection<TItemType>();
      var db = await App.GetDatabaseAsync();
      using (var statement = await db.PrepareStatementAsync(GetSelectAllSql()))
      {
        FillSelectAllStatement(statement);
        while (await statement.StepAsync())
        {
          var item = CreateItem(statement);
          items.Add(item);
        }
      }
      Timestamp = DateTime.Now;

      return items;
    }

    public async Task<TItemType> GetItemAsync(TKeyType key)
    {
      var db = await App.GetDatabaseAsync();
      using (var statement = await db.PrepareStatementAsync(GetSelectItemSql()))
      {
        FillSelectItemStatement(statement, key);

        // Enable the columns property, just for kicks
        statement.EnableColumnsProperty();

        if (await statement.StepAsync())
        {
          var item = CreateItem(statement);
          Timestamp = DateTime.Now;
          return item;
        }
      }

      throw new ArgumentOutOfRangeException("key not found");
    }

    public async Task InsertItemAsync(TItemType item)
    {
      var db = await App.GetDatabaseAsync();
      using (var statement = await db.PrepareStatementAsync(GetInsertItemSql()))
      {
        FillInsertStatement(statement, item);
        await statement.StepAsync();
      }
      Timestamp = DateTime.Now;
    }

    public async Task UpdateItemAsync(TKeyType key, TItemType item)
    {
      var db = await App.GetDatabaseAsync();
      using (var statement = await db.PrepareStatementAsync(GetUpdateItemSql()))
      {
        FillUpdateStatement(statement, key, item);
        await statement.StepAsync();
      }
      Timestamp = DateTime.Now;
    }

    public async Task DeleteItemAsync(TKeyType key)
    {
      var db = await App.GetDatabaseAsync();
      using (var statement = await db.PrepareStatementAsync(GetDeleteItemSql()))
      {
        FillDeleteItemStatement(statement, key);
        await statement.StepAsync();
      }
      Timestamp = DateTime.Now;
    }
  }
}
