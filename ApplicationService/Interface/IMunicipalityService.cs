using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Interface
{
    public interface IMunicipalityService : IAllService<MunicipalityModel>
    {
        MunicipalityModel GetOneMunicipalityRecord(int id);

        List<MunicipalityModel> GetAllMunicipalityRecord();
    }
}
