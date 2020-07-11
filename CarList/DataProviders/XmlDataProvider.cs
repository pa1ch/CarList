using System.Collections.Generic;
using System.Data;
using System.Linq;
using CarList.Models;

namespace CarList.DataProviders
{
    public class XmlDataProvider : ICustomDataProvider
    {
        private string ConnectionString { get; }
        private readonly DataTable _dataTable = new DataTable("Cars"); 

        public XmlDataProvider(string xmlFilePath)
        {
            ConnectionString = xmlFilePath;
            ConfigureDataTable();
            LoadDataFromXml();
        }

        private void LoadDataFromXml()
        {
            _dataTable.ReadXml(ConnectionString);
        }
        
        private void ConfigureDataTable()
        {
            var column1 = new DataColumn("ID", typeof(int));
            _dataTable.Columns.Add(column1);
            _dataTable.Columns.Add("Brand", typeof(string));
            _dataTable.Columns.Add("Model", typeof(string));
            _dataTable.Columns.Add("Production", typeof(int));
            _dataTable.PrimaryKey = new [] {column1};
            column1.AutoIncrement = true;  
            column1.AutoIncrementSeed = 100;  
            column1.AutoIncrementStep = 3;
       
        }
        
        private void SaveDataToXml()
        {
            _dataTable.WriteXml(ConnectionString);
        }
        
        public IEnumerable<Car> GetAllCars()
        {
            return (from object? car in _dataTable.Rows select (new Car((DataRow) car))).ToList();
        }

        public void CreateNewCar(Car car)
        {
            var newRow = _dataTable.NewRow();
            newRow["Brand"] = car.Brand;
            newRow["Model"] = car.Model;
            newRow["Production"] = car.Production;
            _dataTable.Rows.Add(newRow);
            SaveDataToXml();
        }

        public void UpdateCar(Car car)
        {
            var carRow = _dataTable.Rows.Find(car.ID);
            carRow["Brand"] = car.Brand;
            carRow["Model"] = car.Model;
            carRow["Production"] = car.Production;
            SaveDataToXml();
        }

        public Car GetCarData(int? id)
        {
            var carRow = _dataTable.Rows.Find(id);
            return new Car(carRow);
        }

        public void DeleteCar(int? id)
        {
            var carRow = _dataTable.Rows.Find(id);
            _dataTable.Rows.Remove(carRow);
            SaveDataToXml();
        }
    }
}