using System.Collections.Generic;
using System.Threading.Tasks;
using PeopleData.Models;

namespace PeopleData
{
    public interface IRepository
    {
        Task<bool> DeletePersonAsync(int id);
        Task<List<Person>> GetAllPeopleAsync();
        Task<Person> GetPersonAsync(int id);
        Task<bool> InsertPersonAsync(Person person);
        Task<bool> UpdatePersonAsync(Person person);
    }
}