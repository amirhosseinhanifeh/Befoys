using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels.Register.Step
{
    public class ViewStep3
    {
        public IFormFile Shenasname { get; set; }
        public IFormFile MelliCart { get; set; }
        public IFormFile JavazKasb { get; set; }
        public IFormFile Govahi { get; set; }

        public IFormFile RoznameRasmi { get; set; }
        public IFormFile Asasname { get; set; }
        public IFormFile Agahi { get; set; }

    }
}
