using CrudSinger.Database;
using CrudSinger.Models;
using CrudSinger.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudSinger.BL
{
    public class Singers : ISinger
    {
        //Eliminar una fila
        public async Task<bool> Delete(SingerModel singerModel)
        {
            using(var singersContext = new SingerContext())
            {
                var tracking = singersContext.Remove(singerModel);
                await singersContext.SaveChangesAsync();
                var isDeleted = tracking.State == EntityState.Deleted;
                return isDeleted;
            }
        }

        //Eliminar todo
        public async Task<bool> DeleteAllSingers()
        {
            using (var singersContext = new SingerContext())
            {
                singersContext.RemoveRange(singersContext.TbSingers);
                await singersContext.SaveChangesAsync();
            }
            return true;
        }

        //Obtener la lista
        public async Task<List<SingerModel>> GetListSingers()
        {
            using (var singersContext = new SingerContext())
            {
                return await singersContext.TbSingers.ToListAsync();
            }
        }

        //Obtener un dato
        public async Task<SingerModel> GetSinger(int SingerId)
        {
            using (var singersContext = new SingerContext())
            {
                return await singersContext.TbSingers.Where(p => p.IdSingerModel == SingerId).FirstOrDefaultAsync();
            }
        }

        //Insertar una fila
        public async Task<bool> Insert(SingerModel singerModel)
        {
            using (var singerContext = new SingerContext())
            {
                singerContext.Add(singerModel);
                await singerContext.SaveChangesAsync();
            }
            return true;
        }

        //Actualizar una fila
        public async Task<bool> Update(SingerModel singerModel)
        {
            using (var singersContext = new SingerContext())
            {
                var tracking = singersContext.Update(singerModel);
                await singersContext.SaveChangesAsync();

                var isModified = tracking.State == EntityState.Modified;
                return isModified;
            }
        }
    }
}
