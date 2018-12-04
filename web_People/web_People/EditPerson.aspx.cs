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
    public partial class EditPerson : System.Web.UI.Page
    {
        public async Task<object> fvPerson_GetItem()
        {
            Person person = new Person();
            string idString = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(idString))
            {
                int id = int.Parse(idString);
                if (id != 0)
                {
                    Repository rep = new Repository();
                    person = await rep.GetPersonAsync(id);
                }
            }
            return person;
        }
        public async void fvPerson_UpdateItem(int id)
        {
            Person person = new Person();
            TryUpdateModel(person);
            Repository rep = new Repository();
            if (person.ID == 0)
            {
                bool ok = await rep.InsertPersonAsync(person);
            }
            else
            {
                bool ok = await rep.UpdatePersonAsync(person);
            }
            Response.Redirect("People.aspx");
        }
    }
}