using Qualification_API_Blazor.Models;
namespace Qualification_API_Blazor.Services
{
    public class StrojService : IStrojService
    {
        private readonly IDbService _dbService;

        public StrojService(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<bool> CreateStroj(Stroj stroj)
        {
            var result = await _dbService.Insert<int>("INSERT INTO public.Stroj (id,name, age, address, mobile_number) VALUES (@Id, @Name, @Age, @Address, @MobileNumber)", stroj);
            return true;
        }

        public async Task<List<Stroj>> GetStrojList()
        {
            var StrojList = await _dbService.GetAll<Stroj>("SELECT * FROM public.Stroj", new { });
            return StrojList;
        }

        public async Task<Stroj> UpdateStroj(Stroj stroj)
        {
            var updateStroj = await _dbService.Update<int>("Update public.Stroj SET name=@Name, age=@Age, address=@Address, mobile_number=@MobileNumber WHERE id=@Id", stroj);
            return Stroj;
        }

        public async Task<bool> DeleteStroj(int key)
        {
            var deleteStroj = await _dbService.Delete<int>("DELETE FROM public.Stroj WHERE id=@Id", new { id = key });
            return true;
        }

        public Task<bool> CreateStroj(Stroj stroj)
        {
            throw new NotImplementedException();
        }

        public Task<List<Stroj>> GetStrojList()
        {
            throw new NotImplementedException();
        }

        public Task<Stroj> UpdateStroj(Stroj stroj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStroj(int key)
        {
            throw new NotImplementedException();
        }
    }
}
