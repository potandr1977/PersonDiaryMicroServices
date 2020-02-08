using System.Threading.Tasks;
using PersonDiary.GateWay.Dto;

namespace PersonDiary.GateWay.ApiClient
{
    public interface ILifeEventApiClient
    {
        Task GetLifeEvent(int personId);

        Task GetLifeEvents(int id);

        Task<string> SaveOrUpdate(GateWayUpdateLifeEventDto lifeevent);

        Task<string> Delete(int id);
    }
}