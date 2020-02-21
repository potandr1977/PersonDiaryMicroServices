using System.Threading.Tasks;
using PersonDiary.Infrastructure.Domain.Models.FileStore;
using PersonDiary.Infrastucture.Domain.DataAccess;

namespace PersonDiary.Infractructure.DataAccess.Mongo
{
    public class DbExecutorMongo : IDbExecutorMongo
    {
        public Task<string> UploadFileAsync(UploadedFileModel file)
        {
            throw new System.NotImplementedException();
        }
    }
}