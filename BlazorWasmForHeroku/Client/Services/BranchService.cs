

using BlazorWasmForHeroku.Shared;
using BlazorWasmForHeroku.Shared.Models;
using BlazorWasmForHeroku.Shared.Utility;
using System.Net.Http.Json;

namespace BlazorWasmForHeroku.Client.Services
{
    public interface IBranchService
    {
        Task<bool> CreateItem(Branch entity);
        Task<List<Branch>> GetBranchs();
        Task<Branch> GetDetails(int id);
        Task<bool> UpdateItem(Branch entity);
        Task<bool> Delete(Branch branch);

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

        public async Task<bool> CreateItem(Branch entity)
        {
            var result = await _http.PostAsJsonAsync("api/Branch/create", entity);
            return result.IsSuccessStatusCode;
        }

        public async Task<Branch> GetDetails(int id)
        {
            var res = await ApiWrapper.Get<Branch>($"{_http.BaseAddress.AbsoluteUri}api/Branch/getdetails/{id}");
            return res;
        }

        public async Task<bool> UpdateItem(Branch entity)
        {
            var result = await ApiWrapper.Put<Branch>($"{_http.BaseAddress.AbsoluteUri}api/Branch/update", entity);
            return result != null;
        }

        public async Task<bool> Delete(Branch branch)
        {
            var delete = await _http.DeleteAsync($"api/branch/deletebranch/{branch.BranchId}");
            return delete.IsSuccessStatusCode;
        }
    }
}
