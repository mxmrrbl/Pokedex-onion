using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Domain.Entities
{
    public class Region
    {
        public int id { get; set; }
        public string name { get; set; }

        //Nav Prop
        public ICollection<Pokemon> Pokemons { get; set; }
    }
}
