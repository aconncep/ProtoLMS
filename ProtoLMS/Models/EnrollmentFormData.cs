using Microsoft.AspNetCore.Mvc;

namespace ProtoLMS.Models
{
    public class EnrollmentFormData
    {
        [BindProperty]
        public string OrgName { get; set; }

        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string LastName { get; set; }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }
    }
}
