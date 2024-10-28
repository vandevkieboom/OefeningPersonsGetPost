using OefeningPersonsGetPost.Models;

namespace OefeningPersonsGetPost.Services
{
    public interface IPersonsService
    {
        public Task CreatePerson(Person item);
        public Task<Person?> GetPerson(int id);
    }
}
