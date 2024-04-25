
namespace Backend.Service.Models.Shared
{
    public interface IDelete
    {
        string ID { get; set; }
        bool IsDeleted { get; set; }
    }
}
