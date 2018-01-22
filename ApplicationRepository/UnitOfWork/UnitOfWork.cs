using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationRepository.Repository;

namespace ApplicationRepository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        practiceEntities context = null;

        public UnitOfWork()
        {
            context = new practiceEntities();
        }

        public UnitOfWork(practiceEntities _context)
        {
            context = _context ?? new practiceEntities();
        }

        //public IRepository<users> UserRepository { get 
        //    {
        //        return UserRepository ?? (new RepositoryBase<users>(context));
        //    }
        //    private set { }
        //}

        private IRepository<User> _userRepository;

        public IRepository<User> UserRepository
        {
            get => _userRepository ?? (_userRepository = new RepositoryBase<User>());
        }

        private IRepository<Role> _roleRepository;
        public IRepository<Role> RoleRepository
        {
            get => _roleRepository ?? (_roleRepository = new RepositoryBase<Role>());
        }

        private IRepository<RoleAccess> _roleAccessRepository;

        public IRepository<RoleAccess> RoleAccessRepository
        {
            get => _roleAccessRepository ?? (_roleAccessRepository = new RepositoryBase<RoleAccess>());
        }


        private IRepository<Colour> _colourRepository;

        public IRepository<Colour> ColourRepository
        {
            get => _colourRepository ?? (_colourRepository = new RepositoryBase<Colour>());
        }

        private IRepository<Municipality> _municipalityRepository;

        public IRepository<Municipality> MunicipalityRepository
        {
            get => _municipalityRepository ?? (_municipalityRepository = new RepositoryBase<Municipality>());
        }

        private IRepository<Office> _officeRepository;

        public IRepository<Office> OfficeRepository
        {
            get => _officeRepository ?? (_officeRepository = new RepositoryBase<Office>());
        }

        private IRepository<OfficeType> _officeTypeRepository;

        public IRepository<OfficeType> OfficeTypeRepository
        {
            get => _officeTypeRepository ?? (_officeTypeRepository = new RepositoryBase<OfficeType>());
        }

        private IRepository<Designation> _designationRepository;

        public IRepository<Designation> DesignationRepository
        {
            get => _designationRepository ?? (_designationRepository = new RepositoryBase<Designation>());
        }

        private IRepository<EducationLevel> _educationLevelRepository;

        public IRepository<EducationLevel> EducationLevelRepository
        {
            get => _educationLevelRepository ?? (_educationLevelRepository = new RepositoryBase<EducationLevel>());
        }

        private IRepository<Religion> _religionRepository;

        public IRepository<Religion> ReligionRepository
        {
            get => _religionRepository ?? (_religionRepository = new RepositoryBase<Religion>());
        }

        private IRepository<FiscalYear> _fiscalYearRepository;

        public IRepository<FiscalYear> FiscalYearRepository
        {
            get => _fiscalYearRepository ?? (_fiscalYearRepository = new RepositoryBase<FiscalYear>());
        }

        private IRepository<District> _districtRepository;

        public IRepository<District> DistrictRepository
        {
            get => _districtRepository ?? (_districtRepository = new RepositoryBase<District>());
        }

        private IRepository<Menu> _menuRepository;

        public IRepository<Menu> MenuRepository
        {
            get => _menuRepository ?? (_menuRepository = new RepositoryBase<Menu>());
        }

        private IRepository<MunicipalityType> _municipalityTypeRepository;

        public IRepository<MunicipalityType> MunicipalityTypeRepository
        {
            get => _municipalityTypeRepository ?? (_municipalityTypeRepository = new RepositoryBase<MunicipalityType>());
        }


        private IRepository<Missing> _missingRepository;
        public IRepository<Missing> MissingRepository
        {
            get => _missingRepository ?? (_missingRepository = new RepositoryBase<Missing>() );
        }

        private IRepository<State> _stateRepository;

        public IRepository<State> StateRepository
        {
            get => _stateRepository ?? (_stateRepository = new RepositoryBase<State>());
        }

        private IRepository<Photo> _photoRepository;
        public IRepository<Photo> PhotoRepository
        {
            get => _photoRepository ?? (_photoRepository = new RepositoryBase<Photo>());

        }

        private IRepository<country> _countryRepository;
        public IRepository<country> CountryRepository
        {
            get => _countryRepository ?? (_countryRepository = new RepositoryBase<country>());
        }

        private IRepository<IdType> _idTypeRepository;
        public IRepository<IdType> IdTypeRepository
        {
            get => _idTypeRepository ?? (_idTypeRepository = new RepositoryBase<IdType>());
        }

        private IRepository<Ethnicity> _ethnicityRepository;
        public IRepository<Ethnicity> EthnicityRepository
        {
            get => _ethnicityRepository ?? (_ethnicityRepository = new RepositoryBase<Ethnicity>());
        }
    }
}
