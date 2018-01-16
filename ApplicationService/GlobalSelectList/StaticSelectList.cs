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
        public static List<SelectListItem> GenderList([Optional] int genderId) =>
            new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value ="1",
                    Text = "Male",
                    Selected= genderId == 1

                },
                new SelectListItem
                {
                    Value="2",
                    Text="Female",
                    Selected= genderId == 2
                },
                new SelectListItem
                {
                    Value = "3",
                    Text="Others",
                    Selected= genderId == 3
                }
            };
    }
}
