using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BindingToCommands
{
  public class Car : INotifyPropertyChanged
  {
    public int ID { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    //public string CheckedInDateTime { get; set; }

    private string checkedInDateTime;

    public string CheckedInDateTime
    {
      get { return checkedInDateTime; }
      set { 
        checkedInDateTime = value;
        NotifyPropertyChanged("CheckedInDateTime");
      }
    }


    public ICommand CheckedInCommand { get; set; }

    public Car()
    {
      CheckedInCommand = new CheckInButtonClick();
    }

    public void CheckInCar()
    {
      this.CheckedInDateTime = String.Format("{0:t}", DateTime.Now);
    }


    public event PropertyChangedEventHandler PropertyChanged;

    private void NotifyPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }

  }

  public class CarDataSource
  {
    private static ObservableCollection<Car> _cars
        = new ObservableCollection<Car>();

    public static ObservableCollection<Car> GetCars()
    {
      if (_cars.Count == 0)
      {
        _cars.Add(new Car() { ID = 1, Make = "Olds", Model = "Cutlas" });
        _cars.Add(new Car() { ID = 2, Make = "Geo", Model = "Prism" });
        _cars.Add(new Car() { ID = 3, Make = "Ford", Model = "Pinto" });
      }
      return _cars;
    }

    public static void CheckInCar(Car car)
    {
      _cars.FirstOrDefault(p => p.ID == car.ID).CheckedInDateTime = String.Format("{0:t}", DateTime.Now);
    }
  }

  public class CheckInButtonClick : ICommand
  {
    public bool CanExecute(object parameter)
    {
      return true;
    }

    public event EventHandler CanExecuteChanged;

    public void Execute(object parameter)
    {
      //throw new NotImplementedException();
      //CarDataSource.CheckInCar((Car)parameter);
      ((Car)parameter).CheckInCar();
    }
  }


}
