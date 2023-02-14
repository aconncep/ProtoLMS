using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoLMS.Data;
using ProtoLMS.Models;

namespace ProtoLMS.Pages
{
    public class AdminPanelModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _db;

        public Organization? organization;
        public Administrator? administrator;


        public AdminPanelModel(ILogger<IndexModel> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _db = applicationDbContext;
        }

        public IActionResult OnGet()
        {
            string username = HttpContext.Session.GetString("username")!;
            if (username == null)
            {
                return RedirectToPage("./Index");
            }
            string orgID = HttpContext.Session.GetString("orgID")!;
            if (orgID == null)
            {
                return RedirectToPage("./Index");

            }
            int orgIDint = int.Parse(orgID);



            organization = _db.Organization.SingleOrDefault(r => r.Id == orgIDint);
            administrator = _db.Administrator.SingleOrDefault(r => (r.Organization.Id == orgIDint) && (r.Username == username));
            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("orgID");

            return RedirectToPage("./Index");
        }
    }
}