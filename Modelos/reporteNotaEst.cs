using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Prueba
{
    public class reporteNotaEst
    {


        [Display(Name = "NOMBRE ASIGNATURA")]
        public string MAT_NOMBRE { get; set; }

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
        [Display(Name = "FINAL")]
        public Nullable<float> FINAL { get; set; }


    }
}