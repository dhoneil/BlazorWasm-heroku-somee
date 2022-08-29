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

        [HttpPost, Route("api/Branch/create")]
        public async Task<bool> Create([FromBody] Branch entity)
        {
            await db.Branches.AddAsync(entity);
            var res = await db.SaveChangesAsync();
            return res == 0 ? false : true;
        }

        [HttpGet, Route("api/Branch/getdetails/{id}")]
        public async Task<Branch> GetDetails(int id)
        {
            var res = await db.Branches.FirstOrDefaultAsync(s => s.BranchId == id);
            return res;
        }

        [HttpPut, Route("api/Branch/update")]
        public async Task<IActionResult> Update(Branch entity)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var result = await db.Branches.FirstOrDefaultAsync(x => x.BranchId == entity.BranchId);
            db.Entry(result).CurrentValues.SetValues(entity);
            var affectedRows = await db.SaveChangesAsync() > 0 ? true : false;

            if (!affectedRows)
                return BadRequest("Failed during inserting to database");

            return Ok();
        }

        [HttpDelete]
        [Route("api/branch/deletebranch/{id}")]
        public async Task<int> DeleteManagementCompany(int id)
        {
            //Get Contract for delete
            Branch branch = await db.Branches.FirstOrDefaultAsync(data => data.BranchId == id);

            //Delete contract
            db.Branches.Remove(branch);
            var affectedrows = await db.SaveChangesAsync();
            return affectedrows;
        }
    }
}
