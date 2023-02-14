using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.SqlServer.Server;
using ProtoLMS.Data;
using ProtoLMS.Models;
using System.Security.Cryptography;

namespace ProtoLMS.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _db;

        public Organization? organization;

        [BindProperty]
        public LoginFormData? FormData { get; set; }


        public LoginModel(ILogger<IndexModel> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _db = applicationDbContext;
        }

        public IActionResult OnGet()
        {
            // Todo: check account type here
            if (HttpContext.Session.GetString("username") != null)
            {
                return RedirectToPage("./AdminPanel");
            }

            int orgId = int.Parse(HttpContext.Request.Query["org"].ToString());
            organization = _db.Organization.SingleOrDefault(r => r.Id == orgId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (FormData != null)
            {
                int orgId = int.Parse(Request.Form["id"]);
                organization = _db.Organization.SingleOrDefault(r => r.Id == orgId);

                var administrator = _db.Administrator.SingleOrDefault(r => (r.Username == FormData.Username) && (r.Organization == organization));
                if (administrator != null)
                {
                    var hasher = new PasswordHasher<Administrator>();
                    var verificationResult = hasher.VerifyHashedPassword(administrator, administrator.Password, FormData.Password);
                    if (verificationResult == PasswordVerificationResult.Success)
                    {
                        HttpContext.Session.SetString("username", FormData.Username);
                        HttpContext.Session.SetString("orgID", orgId.ToString());
                        return RedirectToPage("./AdminPanel");
                    }
                }


            }

            return RedirectToPage("./Index");

        }
    }
}