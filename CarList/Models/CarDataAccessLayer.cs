using System.Collections.Generic;
using CarList.DataProviders;

namespace CarList.Models
{
    public static class CarDataAccessLayer
    {
        private static ICustomDataProvider _dataProvider;

        public static void SetDataProvider(ICustomDataProvider provider)
        {
            _dataProvider = provider;
        }
        public static IEnumerable<Car> GetAllCars()
        {
            return _dataProvider.GetAllCars();
        }

        public static void CreateNewCar(Car car)
        {
            _dataProvider.CreateNewCar(car);
        }

        public static void UpdateCar(Car car)
        {
            _dataProvider.UpdateCar(car);
        }

        public static Car GetCarData(int? id)
        {
            return _dataProvider.GetCarData(id);
        }

        public static void DeleteCar(int? id)
        {
            _dataProvider.DeleteCar(id);
        }
    }
}
