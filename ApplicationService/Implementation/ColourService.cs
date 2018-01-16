using ApplicationRepository;
using ApplicationRepository.UnitOfWork;
using ApplicationService.Interface;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementation
{
    public class ColourService : IAllService<ColourModel>
    {
        private readonly IUnitOfWork unitOfWork;
        public ColourService(IUnitOfWork _unitOfWork = null)
        {
            unitOfWork = _unitOfWork ?? new UnitOfWork();
        }
        public void Add(ColourModel model)
        {
            Colour colour = Mapper.ColourMapper.ColourModelToColour(model);

            unitOfWork.ColourRepository.Create(colour);
        }

        public void Delete(object id)
        {
          unitOfWork.ColourRepository.Delete(id);

        }

        public List<ColourModel> GetAllT()
        {
            List<Colour> colours = unitOfWork.ColourRepository.All().ToList();

            List<ColourModel> colourModel = Mapper.ColourMapper.ColouToColourModelList(colours);

            return colourModel;
        }

        public ColourModel GetEmptyModel() => new ColourModel();

        public ColourModel GetOneModel(int Id)
        {
            Colour colour = unitOfWork.ColourRepository.GetById(Id);

            ColourModel colourModel = Mapper.ColourMapper.ColourToColourModel(colour);

            return colourModel;

        }

        public void Update(ColourModel model)
        {
            Colour modelC = Mapper.ColourMapper.ColourModelToColour(model);

            unitOfWork.ColourRepository.Update(modelC);
        }

    }
}
