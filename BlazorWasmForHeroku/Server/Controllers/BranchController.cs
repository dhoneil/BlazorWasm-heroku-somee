using BlazorWasmForHeroku.Shared;
using BlazorWasmForHeroku.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorWasmForHeroku.Server.Controllers
{
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly DataContext db;
        public BranchController(DataContext _db)
        {
            db = _db;
        }

        [HttpGet, Route("api/Branch/getBranchs")]
        public async Task<List<Branch>> GetAdministratorAllAsync()
        {
            var res = await db.Branches.ToListAsync();
            return res;
        }
    }
}
