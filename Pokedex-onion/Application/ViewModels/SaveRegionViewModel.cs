using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.ViewModels
{
    public class SaveRegionViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Campo Name requerido")]
        public string name { get; set; }
    }
}
