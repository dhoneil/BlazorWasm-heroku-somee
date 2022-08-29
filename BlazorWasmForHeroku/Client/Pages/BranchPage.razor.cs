using BlazorWasmForHeroku.Client.Services;
using BlazorWasmForHeroku.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorWasmForHeroku.Client.Pages
{
    public partial class BranchPage
    {
        [Inject] IBranchService BranchService { get; set; }
        public List<Branch> BranchList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            BranchList = await BranchService.GetBranchs();
        }

    }
}
