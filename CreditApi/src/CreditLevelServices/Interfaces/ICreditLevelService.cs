using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Credit.CreditLevelServices.Dtos;
using Data.Commons.Dtos;
namespace Credit.CreditLevelServices.Interfaces
{
    public interface ICreditLevelService
    {
        Task TeamLevelCreate(CerditLeveDto input);
    }
}
