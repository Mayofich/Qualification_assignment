using Qualification_API_Blazor.Models;
using Dapper;

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
            var result = await _dbService.Insert<int>("STROJEVI", stroj);
            return true;
        }

        public async Task<List<Stroj>> GetStrojList()
        {
            var StrojList = await _dbService.GetAll<Stroj>("SELECT * FROM public.Stroj", new { });
			Console.WriteLine("radi");
			return StrojList;
        }

        public async Task<Stroj> UpdateStroj(Stroj stroj)
        {
            var updateStroj = await _dbService.Update<int>("Update public.Stroj SET NAZIV_STROJA=@NAZIV_STROJA WHERE ID=@ID", stroj);
            return stroj;
        }

        public async Task<bool> DeleteStroj(int key)
        {
            var deleteStroj = await _dbService.Delete<int>("DELETE FROM public.Stroj WHERE ID=@ID", new { ID = key });
            return true;
        }
    }
}
