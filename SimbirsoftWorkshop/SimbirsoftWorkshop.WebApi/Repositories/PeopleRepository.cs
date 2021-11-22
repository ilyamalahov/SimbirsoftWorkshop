using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimbirsoftWorkshop.WebApi.Data;
using SimbirsoftWorkshop.WebApi.Entities;

namespace SimbirsoftWorkshop.WebApi.Repositories
{
    public class PeopleRepository:IPeopleRepository
    {
        private readonly BookLibraryContext bookLibraryContext;

        public PeopleRepository(BookLibraryContext bookLibraryContext)
        {
            this.bookLibraryContext = bookLibraryContext;
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            return await bookLibraryContext.People.FindAsync(id);
        }

        public async Task<Person> GetPersonWithChildrenAsync(int id)
        {
            return await bookLibraryContext.People
                .Include(p => p.Books)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddPersonAsync(Person person)
        {
            await bookLibraryContext.People.AddAsync(person);
            await bookLibraryContext.SaveChangesAsync();
        }

        public async Task UpdatePersonAsync(Person person)
        {
            bookLibraryContext.People.Update(person);
            await bookLibraryContext.SaveChangesAsync();
        }

        public async Task DeletePersonAsync(Person person)
        {
            bookLibraryContext.People.Remove(person);
            await bookLibraryContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> SearchPeopleByFullNameAsync(string firstName, string lastName, string middleName)
        {
            return await bookLibraryContext.People
                .Where(p => 
                    p.FirstName == firstName && 
                    p.LastName == lastName && 
                    p.MiddleName == middleName)
                .ToListAsync();
        }

        public async Task DeletePeopleAsync(IEnumerable<Person> people)
        {
            bookLibraryContext.People.RemoveRange(people);
            await bookLibraryContext.SaveChangesAsync();
        }
    }
}
