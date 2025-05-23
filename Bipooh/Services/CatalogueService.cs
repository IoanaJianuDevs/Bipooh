using Bipooh.DataAccessLayer;
using Bipooh.Helpers;
using Microsoft.Extensions.Options;

namespace Bipooh.Services
{
    public class CatalogueService : ICatalogueService
    {
        public readonly CatalogueContext CatalogueContext;

        public CatalogueService(CatalogueContext catalogueContext)
        {
            CatalogueContext = catalogueContext;
        }

        public ICatalogue GetById(int studentId, int subjectId)
        {
            throw new NotImplementedException();
        }


        //public IEnumerable<ICatalogue> GetAll()
        //{
        //    return CatalogueContext.Catalogues.AsEnumerable();
        //}

        //public ICatalogue GetById(int id)
        //{
        //    return _modelContext.Catalogues.FirstOrDefault(x => x.Id == id);
        //}
        //public ICatalogue GetByName(string lastName)
        //{
        //    return _modelContext.Catalogues.FirstOrDefault(x => x.Id == id);
        //}

        ICatalogue ICatalogueService.GetById(int studentId, int subjectId)
        {
            throw new NotImplementedException();
        }
    }
}
