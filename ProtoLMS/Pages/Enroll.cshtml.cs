using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoLMS.Data;
using ProtoLMS.Models;

namespace ProtoLMS.Pages
{
    public class EnrollModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public EnrollmentFormData? FormData { get; set; }

        public EnrollModel(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {

            if (FormData != null)
            {
                var organization = new Organization { Name = FormData.OrgName };
                var administrator = new Administrator
                {
                    FirstName = FormData.FirstName,
                    LastName = FormData.LastName,
                    Username = FormData.Username,
                    Organization = organization
                };
                var hasher = new PasswordHasher<Administrator>();
                string passwordHash = hasher.HashPassword(administrator, FormData.Password);
                administrator.Password = passwordHash;
                _db.Organization.Add(organization);
                _db.Administrator.Add(administrator);

                await _db.SaveChangesAsync();
            }

            return RedirectToPage("./Index");

        }
    }
}
