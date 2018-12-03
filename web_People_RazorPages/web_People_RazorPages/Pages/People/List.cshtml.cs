using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeopleData.Models;
using PeopleData;
namespace web_People_RazorPages.Pages.People
{
    public class ListModel : PageModel
    {
        private readonly IRepository _db;
        [BindProperty]
        public List<Person> People { get; set; } = new List<Person>();

        public async Task OnGetAsync()
        {
            People = await _db.GetAllPeopleAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _db.DeletePersonAsync(id);
            return  RedirectToPage();
        }

        public ListModel(IRepository db)
        {
            _db = db;
        }
    }
}