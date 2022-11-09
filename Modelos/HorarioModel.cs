using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba
{
    public class HorarioModel
    {
        public HorarioModel()
        {
            this.B1 = new string [7];
            this.B2 = new string[7];
            this.B3 = new string[7];
            this.B4 = new string[7];
            this.B5 = new string[7];
            this.B6 = new string[7];
            this.B7 = new string[7];

        }
        public String[] B1 { get; set; }
        public String[] B2 { get; set; }
        public String[] B3 { get; set; }
        public String[] B4 { get; set; }
        public String[] B5 { get; set; }
        public String[] B6 { get; set; }
        public String[] B7 { get; set; }


    }
}