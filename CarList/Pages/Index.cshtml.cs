﻿using System.Collections.Generic;
using System.Linq;
using CarList.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarList.Pages
{
    public class IndexModel : PageModel
    {
        public IList<Car> Car { get;set; }

        public void OnGet()  
        {  
            Car = CarDataAccessLayer.GetAllCars().ToList();
        }  
    }
}
