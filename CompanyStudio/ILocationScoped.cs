using CompanyStudio.Models;

namespace CompanyStudio
{
    public interface ILocationScoped
    {
        Location LocationModel { get; set; }
    }
}
