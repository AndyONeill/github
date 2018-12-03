using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeopleData;
using PeopleData.Models;
namespace web_People_RazorPages.Pages.People
{
    public class EditModel : PageModel
    {
        private readonly IRepository _db;

        [BindProperty]
        public string Mode { get; set; } = "Edit";

        [BindProperty]
        public Person Person { get; set; }

        public async Task OnGetAsync(int id = 0)
        {
            if(id == 0)
            {
                Person = new Person();
                Mode = "Add new Person";
                return;
            }
            Mode = "Edit existing Person";
            Person = await _db.GetPersonAsync(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(Person.Id == 0)
            {
                await _db.InsertPersonAsync(Person);
            }
            else
            {
                await _db.UpdatePersonAsync(Person);
            }
            return RedirectToPage("/People/List");
        }

        public EditModel(IRepository db)
        {
            _db = db;
        }
    }
}