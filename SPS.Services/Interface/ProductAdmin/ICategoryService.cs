using SPS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Services.Interface
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDetail>GetCategory();
    }
}
