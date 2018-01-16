using ApplicationRepository;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Mapper
{
    public class ColourMapper
    {
        public static Colour ColourModelToColour(ColourModel model)
        {
            var colour = new Colour
            {
                id = model.id,
                ColourName = model.ColourName
            };

            return colour;
        }


        public static ColourModel ColourToColourModel(Colour model)
        {
            var colour = new ColourModel
            {
                id = model.id,
                ColourName = model.ColourName
            };

            return colour;
        }

        public static List<ColourModel> ColouToColourModelList(List<Colour> model)
        {
            var colourModel = new List<ColourModel>();

            foreach (var colour in model)
            {
                colourModel.Add(new ColourModel
                {
                    id = colour.id,
                    ColourName = colour.ColourName
                });
            }
            return colourModel;
        }
    }
}
