using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoLMS.Data;
using ProtoLMS.Models;

namespace ProtoLMS.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _db;

        public IEnumerable<User> Users;

        public int NumOrganizations { get; set; }
        public int NumInstructors { get; set; }
        public int NumStudents { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _db = applicationDbContext;
        }

        public void OnGet()
        {
            NumOrganizations = _db.Organization.Count();
            NumInstructors = _db.Instructor.Count();
            NumStudents = _db.Student.Count();
        }
    }
}