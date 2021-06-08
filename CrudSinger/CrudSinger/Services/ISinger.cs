using CrudSinger.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudSinger.Services
{
    public interface ISinger
    {
        Task<List<SingerModel>> GetListSingers();
        Task<SingerModel> GetSinger(int SingerId);
        Task<bool> Insert(SingerModel singerModel);
        Task<bool> Update(SingerModel singerModel);
        Task<bool> Delete(SingerModel singerModel);
        Task<bool> DeleteAllSingers();
    }
}
