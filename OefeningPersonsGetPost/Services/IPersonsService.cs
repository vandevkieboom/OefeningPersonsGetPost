using OefeningPersonsGetPost.Models;

namespace OefeningPersonsGetPost.Services
{
    public interface IPersonsService
    {
        public Task CreatePerson(Person item);
        public Task<Person?> GetPerson(int id);
        public Task<List<Person>> GetAllPersons();
        public Task<Person?> UpdatePerson(int id, Person item);
        public Task DeletePerson(int id);
    }
}
