using ApplicationRepository;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Mapper
{
    public class PhotoMapper
    {
        public static Photo PhotoModelToPhoto(PhotoModel model)
        {
            var photo = new Photo
            {
              Id = model.Id,
              MissingId = model.MissingId,
              Photo1 = model.Photo,
              FileExtension = model.FileExtension,
              FilePath = model.FilePath,
              Detail = model.Detail,
              IsPhoto = model.IsPhoto
            };

            return photo;
        }

        public static PhotoModel PhotoToPhotoModel(Photo model)
        {
            var photoModel = new PhotoModel
            {
                Id = model.Id,
                MissingId = model.MissingId,
                Photo = model.Photo1,
                FileExtension = model.FileExtension,
                FilePath = model.FilePath,
                Detail = model.Detail,
                IsPhoto = model.IsPhoto

            };

            return photoModel;
        }

        public static List<PhotoModel> PhotoToPhotoModelList(List<Photo> models)
        {
            var photoModelList = new List<PhotoModel>();

            foreach (var model in models)
            {
                photoModelList.Add(new PhotoModel
                {
                    Id = model.Id,
                    MissingId = model.MissingId,
                    Photo = model.Photo1,
                    FileExtension = model.FileExtension,
                    FilePath = model.FilePath,
                    Detail = model.Detail,
                    IsPhoto = model.IsPhoto

                });
            }
            return photoModelList;
        }
    }
}
