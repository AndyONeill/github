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
    public partial class People : System.Web.UI.Page
    {
        public  async Task<List<Person>> GetPeople()
        {
            Repository rep = new Repository();
            var people = await rep.GetAllPeopleAsync();
            return people;
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditPerson.aspx?id=0");
        }
    }
}