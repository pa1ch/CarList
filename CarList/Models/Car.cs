using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CarList.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        
        [Range(1886, 2020)]
        public int Production { get; set; }

        public Car(DataRow row)
        {
            ID = Convert.ToInt32(row["ID"]);
            Brand = row["Brand"].ToString();
            Model = row["Model"].ToString();
            Production = Convert.ToInt32(row["Production"]);
        }
        
        public Car() {}
    }
}
