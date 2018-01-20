using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ApplicationService.GlobalSelectList
{
    public class StaticSelectList
    {
        public static List<SelectListItem> GenderList([Optional] string gender) =>
            new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value ="Male",
                    Text = "Male",
                    Selected= gender == "Male"

                },
                new SelectListItem
                {
                    Value="Female",
                    Text="Female",
                    Selected= gender == "Female"
                },
                new SelectListItem
                {
                    Value = "Others",
                    Text="Others",
                    Selected= gender == "Others"
                }
            };
    }
}
