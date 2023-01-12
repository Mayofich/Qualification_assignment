using Syncfusion.Blazor.Data;
using Syncfusion.Blazor;
using System.Data.Common;
using Qualification_API_Blazor.Services;
using Qualification_API_Blazor.Models;


namespace Qualification_API_Blazor.Adapters
{
    public class StrojAdapter : DataAdaptor
    {
        private readonly IStrojService _StrojService;

        public StrojAdapter(IStrojService StrojService)
        {
            _StrojService = StrojService;
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key)
        {
            List<Stroj> strojevi = await _StrojService.GetStrojList();
            int count = strojevi.Count;
            return dataManagerRequest.RequiresCounts ? new DataResult() { Result = strojevi, Count = count } : count;
        }

        public override async Task<object> InsertAsync(DataManager dataManager, object data, string key)
        {
            await _StrojService.CreateStroj(data as Stroj);
            return data;
        }

        public override async Task<object> RemoveAsync(DataManager dataManager, object data, string keyField, string key)
        {
            await _StrojService.DeleteStroj(Convert.ToInt32(data));
            return keyField;
        }

        public override async Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
        {
            await _StrojService.UpdateStroj(data as Stroj);
            return data;
        }
    }
}
