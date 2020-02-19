using System.Threading.Tasks;
using PersonDiary.Person.Dto;

namespace PersonDiary.Lifeevent.ApiClient
{
    public interface ILifeEventApiClient
    {
        Task GetLifeEvent(int personId);

        Task GetLifeEvents(int id);

        Task<string> SaveOrUpdate(GateWayUpdateLifeEventDto gateWayUpdateLifeEventDto);

        Task<string> Delete(int id);
    }
}