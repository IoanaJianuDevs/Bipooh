namespace Bipooh.Services
{
    public interface ICatalogueService
    {
        ICatalogue GetById(int studentId, int subjectId);
    }
}
