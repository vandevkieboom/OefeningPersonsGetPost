using OefeningPersonsGetPost.Services;

namespace OefeningPersonsGetPost.Models
{
    public class PersonsService : IPersonsService
    {
        private static readonly List<Person> _allPersons = new();

        public Task CreatePerson(Person item)
        {
            _allPersons.Add(item);
            return Task.CompletedTask;
        }

        public Task<Person?> GetPerson(int id)
        {
            var person = _allPersons.FirstOrDefault(p => id == p.Id);
            return Task.FromResult(person);
        }
    }
}
