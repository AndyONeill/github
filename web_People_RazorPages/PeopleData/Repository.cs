using Microsoft.EntityFrameworkCore;
using PeopleData.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleData
{
    public class Repository : IRepository
    {
        public async Task<List<Person>> GetAllPeopleAsync()
        {
            List<Person> people = new List<Person>();
            using (var db = new AndyPeopleContext())
            {
                people = await db.People
                                 .AsNoTracking()
                                 .ToListAsync();
            }
            return people;
        }

        public async Task<Person> GetPersonAsync(int id)
        {
            Person person = new Person();
            using (var db = new AndyPeopleContext())
            {
                person = await db.People.FindAsync(id);
            }
            return person;
        }
        public async Task<bool> InsertPersonAsync(Person person)
        {
            int numUpdated = 0;
            using (var db = new AndyPeopleContext())
            {
                db.People.Add(person);
                db.Entry(person).State = EntityState.Added;
                numUpdated = await db.SaveChangesAsync();
            }
            return numUpdated == 1;
        }
        public async Task<bool> UpdatePersonAsync(Person person)
        {
            int numUpdated = 0;
            using (var db = new AndyPeopleContext())
            {
                db.People.Add(person);
                db.Entry(person).State = EntityState.Modified;
                numUpdated = await db.SaveChangesAsync();
            }
            return numUpdated == 1;
        }
        public async Task<bool> DeletePersonAsync(int id)
        {
            int numUpdated = 0;
            using (var db = new AndyPeopleContext())
            {
                Person person = db.People.Find(id);
                db.Entry(person).State = EntityState.Deleted;
                numUpdated = await db.SaveChangesAsync();
            }
            return numUpdated == 1;
        }
    }
}
