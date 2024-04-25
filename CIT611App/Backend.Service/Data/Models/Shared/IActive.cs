
namespace Backend.Service.Models.Shared
{
    public interface IActive
    {
        string ID { get; set; }
        bool IsActive { get; set; }
    }
}
