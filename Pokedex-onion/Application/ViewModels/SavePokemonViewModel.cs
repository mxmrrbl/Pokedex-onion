using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.ViewModels
{
    public class SavePokemonViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Campo Name requerido")]
        public string name { get; set; }

        [Required(ErrorMessage = "Campo Image requerido")]
        public string imageUrl { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Campo Tipo requerido")]
        public int type1 { get; set; }
        public int? type2 { get; set; }

        [Range(1,int.MaxValue, ErrorMessage = "Campo Region requerido")]
        public int region { get; set; }

    }
}
