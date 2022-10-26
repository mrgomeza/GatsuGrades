using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba
{
    public class MATGRAD
    {
        public MATGRAD()
        {
            this.gradList = new SelectList(new List<string>());
        }

        public string matNombre { get; set; }
        public SelectList matList { get; set; }
        public string matGrad { get; set; }
        public SelectList gradList { get; set; }
    }
}