using ApplicationRepository.UnitOfWork;
using ApplicationService.Interface;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ApplicationService.Implementation
{
    public class PhotoService : IAllService<PhotoModel>
    {
        private readonly IUnitOfWork unitOfWork;

        public PhotoService(IUnitOfWork _unitOfWork = null)
        {
            unitOfWork = _unitOfWork ?? new UnitOfWork();
        }
        public void Add(PhotoModel model)
        {
            var photo = Mapper.PhotoMapper.PhotoModelToPhoto(model);

            unitOfWork.PhotoRepository.Create(photo);

        }

        public void Delete(object id)
        {
            unitOfWork.PhotoRepository.Delete(id);
        }

        public List<PhotoModel> GetAllT()
        {
            var photoList = unitOfWork.PhotoRepository.All().ToList();

            return Mapper.PhotoMapper.PhotoToPhotoModelList(photoList);
        }

        public PhotoModel GetEmptyModel() => new PhotoModel();

        public PhotoModel GetOneModel(int Id)
        {
            var photo = unitOfWork.PhotoRepository.Find(Id);

            return Mapper.PhotoMapper.PhotoToPhotoModel(photo);
        }

        public void Update(PhotoModel model)
        {
            var photo = Mapper.PhotoMapper.PhotoModelToPhoto(model); ;

            unitOfWork.PhotoRepository.Update(photo);
        }

        public byte[] GetPhoto(HttpPostedFileBase File,MissingModel model,IEnumerable<HttpPostedFileBase> Files )
        {
            var photo = new byte[File.ContentLength];

            File.InputStream.Read(photo, 0, File.ContentLength);

            return photo;
        }
    }
}
