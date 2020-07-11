using CarList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarList.Pages.Cars
{
    public class CreateModel : PageModel
    {
        [BindProperty]  
        public Car Car { get; set; }  
  
        public ActionResult OnPost()  
        {  
            if (!ModelState.IsValid)  
            {  
                return Page();  
            }  
  
            CarDataAccessLayer.CreateNewCar(Car);  
  
            return RedirectToPage("/Index");  
        }    
    }
}
