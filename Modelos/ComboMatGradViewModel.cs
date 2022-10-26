using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba.Modelos
{
    public class ComboMatGradViewModel
    {
        public IEnumerable<MATERIA> Materias { get; set; }
        public string SeletedMateria { get; set; }
        public IEnumerable<string> grados { get; set; }
        public string SeletedGrado { get; set; }

    }
}