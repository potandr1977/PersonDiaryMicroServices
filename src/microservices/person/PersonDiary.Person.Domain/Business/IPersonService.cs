using System.Threading.Tasks;
using PersonDiary.Person.Domain.Models;

namespace PersonDiary.Person.Domain.Business
{
    public interface IPersonService
    {
        Task<PersonModel> GetByIdAsync(int id);

        Task<int> SaveOrUpdateAsync(PersonModel model);

        Task DeleteByIdAsync(int id);
    }
}