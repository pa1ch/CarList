﻿using CarList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarList.Pages.Cars
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Car Car { get; set; }
        
        public ActionResult OnGet(int? id)  
        {  
            if (id == null)  
            {  
                return NotFound();  
            }  
            Car = CarDataAccessLayer.GetCarData(id);  
  
            if (Car == null)  
            {  
                return NotFound();  
            }  
            return Page();  
        }  
  
        public ActionResult OnPost()  
        {  
            if (!ModelState.IsValid)  
            {  
                return Page();  
            }  
            CarDataAccessLayer.UpdateCar(Car);  
  
            return RedirectToPage("/Index");  
        }
    }
}
