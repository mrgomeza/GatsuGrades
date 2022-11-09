using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prueba
{
    public class NotasModel
    {

        public int ID_NOTA { get; set; }
        [Display(Name = "ID")]
        public int ID_ESTUDIANTE { get; set; }
        [Display(Name = "NOMBRE")]
        public string EST_NOMBRE { get; set; }
        [Display(Name = "APELLIDO")]
        public string EST_APELLIDO { get; set; }
        [Display(Name = "PAR 1")]
        public Nullable<float> np1 { get; set; }
        [Display(Name = "PAR 2")]
        public Nullable<float> np2 { get; set; }
        [Display(Name = "EX Q1")]
        public Nullable<float> eq1 { get; set; }
        [Display(Name = "QUIM 1")]
        public Nullable<float> q1 { get; set; }
        [Display(Name = "PAR 3")]
        public Nullable<float> np3 { get; set; }
        [Display(Name = "PAR 4")]
        public Nullable<float> np4 { get; set; }
        [Display(Name = "EX Q2")]
        public Nullable<float> eq2 { get; set; }
        [Display(Name = "QUIM 2")]
        public Nullable<float> q2 { get; set; }
        [Display(Name = "FINAL")]
        public Nullable<float> final { get; set; }
    }
}