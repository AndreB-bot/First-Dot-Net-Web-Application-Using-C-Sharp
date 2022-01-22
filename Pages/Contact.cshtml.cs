using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestApplication.Pages
{
    public class ContactModel : PageModel
    {
        public bool hasData;
        public string firstName = "";
        public string lastName = "";
        public string message = "";
        public string email = "";

        public void OnGet()
        {

        }

        public void OnPost()
        {
            hasData = true;
            firstName = Request.Form["firstname"];
            lastName = Request.Form["lastname"];
            message = Request.Form["message"];
            email = Request.Form["email"];
        }
    }
}
