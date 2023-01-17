using Qualification_API_Blazor.Models;

namespace Qualification_API_Blazor.Services
{
    public interface IStrojService
    {
        Task<bool> CreateStroj(Stroj stroj);
        Task<List<Stroj>> GetStrojList();
        Task<Stroj> UpdateStroj(Stroj stroj);
        Task<bool> DeleteStroj(int key);
    }
}
