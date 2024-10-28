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

        public Task<List<Person>> GetAllPersons()
        {
            return Task.FromResult(_allPersons);
        }

        public Task<Person?> UpdatePerson(int id, Person item)
        {
            var person = _allPersons.FirstOrDefault(p => id == p.Id);
            if (person != null)
            {
                person.FirstName = item.FirstName;
                person.LastName = item.LastName;
                person.Address = item.Address;
            }
            return Task.FromResult(person);
        }

        public Task DeletePerson(int id)
        {
            var person = _allPersons.FirstOrDefault(p => id == p.Id);
            if (person != null)
            {
                _allPersons.Remove(person);
            }
            return Task.CompletedTask;
        }
    }
}
