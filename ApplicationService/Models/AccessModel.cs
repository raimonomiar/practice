using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Models
{
    public class AccessModel
    {
        public bool CanAdd { get; set; }

        public bool CanEdit { get; set; }

        public bool CanView { get; set; }

        public bool CanDelete { get; set; }

    }
}
