using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PeopleData
{
    public class Repository
    {
        public async Task<List<Person>> GetAllPeopleAsync()
        {
            List<Person> people = new List<Person>();
            using (var db = new AndyPeopleEntities())
            {
                people = await db.People.ToListAsync();
            }
            return people;
        }
        public async Task<Person> GetPersonAsync(int id)
        {
            Person person = new Person();
            using (var db = new AndyPeopleEntities())
            {
                person = await db.People.FindAsync(id);
            }
            return person;
        }
        public async Task<bool> InsertPersonAsync(Person person)
        {
            bool result = false;
            using (var db = new AndyPeopleEntities())
            {
                db.People.Attach(person);
                db.Entry(person).State = EntityState.Added;
                int changed = await db.SaveChangesAsync();
                if (changed == 1)
                {
                    result = true;
                }
            }
            return result;
        }
        public async Task<bool> UpdatePersonAsync(Person person)
        {
            bool result = false;
            using (var db = new AndyPeopleEntities())
            {
                db.People.Attach(person);
                db.Entry(person).State = EntityState.Modified;
                int changed = await db.SaveChangesAsync();
                if(changed == 1)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
