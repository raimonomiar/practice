using ApplicationService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationService.Models;
using ApplicationRepository.UnitOfWork;
using ApplicationRepository;
using System.Data.Entity;

namespace ApplicationService.Implementation
{
    public class MunicipalityService : IMunicipalityService
    {
        private readonly IUnitOfWork unitOfWork;

        public MunicipalityService(IUnitOfWork _unitOfWork = null)
        {
            unitOfWork = _unitOfWork ?? new UnitOfWork();
        }
        public void Add(MunicipalityModel model)
        {
            var municipality = Mapper.MuncipalityMapper.MuncipalityModelToMunicpality(model);

            unitOfWork.MunicipalityRepository.Create(municipality);
        }

        public void Delete(object id)
        {
            unitOfWork.MunicipalityRepository.Delete(id);
        }

        public List<MunicipalityModel> GetAllMunicipalityRecord()
        {
            using (practiceEntities db = new practiceEntities())
            {
                var municipalityList = db.Municipalities
                    .Include(d => d.District)
                    .Include(m => m.MunicipalityType)
                    .OrderByDescending(x => x.Id)
                    .ToList();

                var municipalityModelList = Mapper.MuncipalityMapper.MunicipalityToMunicipalityModelList(municipalityList);

                return municipalityModelList;
            }
        }

        public List<MunicipalityModel> GetAllT()
        {

            var municipalityList = unitOfWork.MunicipalityRepository.All().ToList();

            var municipalityModelList = Mapper.MuncipalityMapper.MunicipalityToMunicipalityModelList(municipalityList);

            return municipalityModelList;
        }

        public MunicipalityModel GetEmptyModel() => new MunicipalityModel();

        public MunicipalityModel GetOneModel(int Id)
        {
            var municipality = unitOfWork.MunicipalityRepository.GetById(Id);

            var municipalityModel = Mapper.MuncipalityMapper.MuncipalityToMuncipalityModel(municipality);

            return municipalityModel;
        }

        public MunicipalityModel GetOneMunicipalityRecord(int id)
        {
            using (practiceEntities db = new practiceEntities())
            {
                var municipality = db.Municipalities
                    .Include(x => x.District)
                    .Include(m => m.MunicipalityType).SingleOrDefault(x => x.Id == id);

                var muncipalityModel = Mapper.MuncipalityMapper.MuncipalityToMuncipalityModel(municipality);

                return muncipalityModel;
            }
        }

        public void Update(MunicipalityModel model)
        {
            var municipality = Mapper.MuncipalityMapper.MuncipalityModelToMunicpality(model);

            unitOfWork.MunicipalityRepository.Update(municipality);
        }
    }
}
