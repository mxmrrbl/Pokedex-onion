using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Domain.Entities
{
    public class PokemonType
    {
        public int id { get; set; }
        public string name { get; set; }

        //Nav Prop
        public ICollection<Pokemon> Pokemons1 { get; set; }
        public ICollection<Pokemon> Pokemons2 { get; set; }
    }
}
