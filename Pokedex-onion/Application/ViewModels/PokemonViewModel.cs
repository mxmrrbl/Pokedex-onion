using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.ViewModels
{
    public class PokemonViewModel
    {

        public int id { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }
        public string type1 { get; set; }
        public string? type2 { get; set; }
        public string region { get; set; }

        public int Region { get; set; }
    }
}
