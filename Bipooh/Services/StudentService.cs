using Bipooh.DataAccessLayer;
using Bipooh.Helpers;
using Microsoft.Extensions.Options;

namespace Bipooh.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppSettings _appSettings;
        //private readonly IDateTimeProvider _dateTimeProvider;
        private readonly StudentContext _modelContext;
        public StudentService(IOptions<AppSettings> appSettings, StudentContext modelContext)
        {
            _appSettings = appSettings.Value;
            _modelContext = modelContext;
        }


        public IEnumerable<IStudent> GetAll()
        {
            //return _modelContext.StudentItems.AsEnumerable();
            return null;
        }

        public IStudent GetById(int id)
        {
            //return _modelContext.StudentItems.FirstOrDefault(x => x.Id == id);
            return null;
        }
    }
}
