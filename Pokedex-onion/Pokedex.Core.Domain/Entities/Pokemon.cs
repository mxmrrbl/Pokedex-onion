using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Domain.Entities
{
    public class Pokemon
    {
        public int id { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }
        public int type1 { get; set; }
        public int? type2 { get; set; } 
        public int region { get; set; }

        //Nav Prop
        public PokemonType PokemonType1 { get; set; }
        public PokemonType? PokemonType2 { get; set; }
        public Region Region { get; set; }
    }
}
