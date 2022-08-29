using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasmForHeroku.Shared.Models
{
    public partial class Branch
    {
        public int BranchId { get; set; }
        public string? BranchName { get; set; }
        public bool? IsActive { get; set; }
    }
}
