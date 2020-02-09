using System.Threading.Tasks;
using PersonDiary.Person.Domain.Business;
using PersonDiary.Person.Domain.DataAccess;
using PersonDiary.Person.Domain.Models;

namespace PersonDiary.Person.Business.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonDao personDao;

        public PersonService(IPersonDao personDao)
        {
            this.personDao = personDao;
        }

        public Task<PersonModel> GetByIdAsync(int id)
        {
            return personDao.GetByIdAsync(id);
        }
        
        public Task<int> SaveOrUpdateAsync(PersonModel model)
        {
            return personDao.SaveOrUpdateAsync(model);
        }
        
        public Task DeleteByIdAsync(int id)
        {
            return personDao.DeleteByIdAsync(id);
        }
    }
}