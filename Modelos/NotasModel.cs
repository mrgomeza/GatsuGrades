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
        public Nullable<float> NP1 { get; set; }
        [Display(Name = "PAR 2")]
        public Nullable<float> NP2 { get; set; }
        [Display(Name = "EX Q1")]
        public Nullable<float> EQ1 { get; set; }
        [Display(Name = "QUIM 1")]
        public Nullable<float> Q1 { get; set; }
        [Display(Name = "PAR 3")]
        public Nullable<float> NP3 { get; set; }
        [Display(Name = "PAR 4")]
        public Nullable<float> NP4 { get; set; }
        [Display(Name = "EX Q2")]
        public Nullable<float> EQ2 { get; set; }
        [Display(Name = "QUIM 2")]
        public Nullable<float> Q2 { get; set; }
        public Nullable<float> FINAL { get; set; }
    }
}