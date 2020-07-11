using System.Collections.Generic;
using CarList.Models;

namespace CarList.DataProviders
{
    public interface ICustomDataProvider
    {
        public IEnumerable<Car> GetAllCars();
        public void CreateNewCar(Car car);
        public void UpdateCar(Car car);
        public Car GetCarData(int? id);
        public void DeleteCar(int? id);
    }
}