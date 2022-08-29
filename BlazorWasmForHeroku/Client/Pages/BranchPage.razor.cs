using BlazorWasmForHeroku.Client.Services;
using BlazorWasmForHeroku.Shared.Models;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor.Components;

namespace BlazorWasmForHeroku.Client.Pages
{
    public partial class BranchPage
    {
        [Inject] IBranchService BranchService { get; set; }
        public List<Branch> BranchList { get; set; }
        private Branch SelectedItem { get; set; }
        public Branch CurrentBranch { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            BranchList = await BranchService.GetBranchs();
        }

        public async Task Create(GridCommandEventArgs args)
        {
            var item = (Branch)args.Item;
            await BranchService.CreateItem(item);

            BranchList.Add(item);
        }

        public async Task EditItem(GridCommandEventArgs args)
        {
            var item = (Branch)args.Item;
            var branchid = item.BranchId;
            CurrentBranch = await BranchService.GetDetails(branchid);
        }

        public async Task Update(GridCommandEventArgs args)
        {
            var branch = (Branch)args.Item;
            var listindex = BranchList.FindIndex(s => s.BranchId == branch.BranchId);
            BranchList[listindex] = branch;
            var updated = await BranchService.UpdateItem(branch);
        }

        public async Task Delete()
        {
            Branch branch = SelectedItem;
            await BranchService.Delete(branch);
            BranchList.Remove(branch);
        }

    }
}
