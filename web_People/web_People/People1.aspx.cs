using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PeopleData;

namespace web_People
{
    public partial class People1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public async Task<List<Person>> GetPeople()
        {
            Repository rep = new Repository();
            var people = await rep.GetAllPeopleAsync();
            return people;
        }
        public async Task<bool> UpdatePerson(int id)
        {
            Person person = new Person { ID = id };
            TryUpdateModel(person);
            bool worked = false;
            if (ModelState.IsValid)
            {
                Repository rep = new Repository();
                worked = await rep.UpdatePersonAsync(person);
            }
            return worked;
        }
    }
}