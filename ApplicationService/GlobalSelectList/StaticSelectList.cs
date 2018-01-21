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

        public static List<SelectListItem> MartialList() =>
            new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Single",
                    Value ="Single"
                },
                new SelectListItem
                {
                    Text = "Married",
                    Value = "Married"
                },
                new SelectListItem
                {
                    Text="UnMarried",
                    Value="UnMarried"
                },
                new SelectListItem
                {
                    Text="Divorced",
                    Value="Divorced"
                }
            };

        public static List<SelectListItem> PersonTypeList([Optional] string type) =>
            new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text="Child",
                    Value="Child",
                    Selected = type == "Child"
                },
                new SelectListItem
                {
                    Text="Teen",
                    Value="Teen",
                    Selected=type=="Teen"
                },
                new SelectListItem
                {
                    Text="Adult",
                    Value="Adult",
                    Selected = type == "Adult"
                }

            };

        public static List<SelectListItem> HeightUnitList() =>
            new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text ="ft",
                    Value="ft",
                    Selected = true
                },
                new SelectListItem
                {
                    Text="inch",
                    Value="inch",

                },
                new SelectListItem
                {
                    Text="cm",
                    Value="cm"
                }
            };


    }
}
