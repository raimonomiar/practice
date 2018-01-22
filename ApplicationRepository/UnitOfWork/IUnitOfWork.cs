using ApplicationRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRepository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<User> UserRepository { get; }
        IRepository<Role> RoleRepository { get; }
        IRepository<RoleAccess> RoleAccessRepository { get; }

        IRepository<Colour> ColourRepository { get; }

        IRepository<Municipality> MunicipalityRepository { get; }

        IRepository<Office> OfficeRepository { get; }

        IRepository<OfficeType> OfficeTypeRepository { get; }

        IRepository<Designation> DesignationRepository  { get;}

        IRepository<EducationLevel> EducationLevelRepository { get; }

        IRepository<Religion> ReligionRepository {get;}

        IRepository<FiscalYear> FiscalYearRepository {get;}

        IRepository<District> DistrictRepository {get;}

        IRepository<Menu> MenuRepository { get; }

        IRepository<MunicipalityType> MunicipalityTypeRepository { get; }

        IRepository<Missing> MissingRepository { get; }

        IRepository<State> StateRepository { get; }

        IRepository<Photo> PhotoRepository { get; }

        IRepository<country> CountryRepository { get; }

        IRepository<IdType> IdTypeRepository { get; }

        IRepository<Ethnicity> EthnicityRepository { get; }

    }
}
