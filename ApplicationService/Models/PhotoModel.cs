﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Models
{
    public class PhotoModel
    {
        public int Id { get; set; }

        public int? MissingId { get; set; }
        
        [StringLength(150)]
        public string UploadedFileName { get; set; }

        [StringLength(255)]
        public string FilePath { get; set; }

        [StringLength(255)]
        public string FileDetails { get; set; }

        [StringLength(50)]
        public string FileExtension { get; set; }
    }
}