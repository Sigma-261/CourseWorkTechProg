using CourseWorkMain.DB;
using CourseWorkMain.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseWorkMain.Repositories
{
    public class BaseRepository
    {
        public ApplicationContext _ctx;

        public BaseRepository(ApplicationContext ctx)
        {
            _ctx = ctx;
        }

        //Получить всю информаци по всем продуктам
        public List<BusinessTrip> GetLocalities()
        {
            return _ctx.Localities.ToList();
        }
    }
}