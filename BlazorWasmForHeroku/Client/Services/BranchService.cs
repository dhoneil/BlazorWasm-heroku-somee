

using BlazorWasmForHeroku.Shared;
using BlazorWasmForHeroku.Shared.Models;
using BlazorWasmForHeroku.Shared.Utility;

namespace BlazorWasmForHeroku.Client.Services
{
    public interface IBranchService
    {
        Task<List<Branch>> GetBranchs();
    }

    public class BranchService : IBranchService
    {
        public readonly HttpClient _http;
        public BranchService(HttpClient httpClient)
        {
            _http = httpClient;
        }

        public async Task<List<Branch>> GetBranchs()
        {
            return await ApiWrapper.Get<List<Branch>>($"{_http.BaseAddress.AbsoluteUri}api/Branch/getBranchs");
        }
    }
}
