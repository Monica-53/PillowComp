using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillowComp.Models
{
    public class MovieGenreViewModel
    {
        public List<Pillow> Pillows { get; set; }
        public SelectList Names { get; set; }
        public string PillowName { get; set; }
        public string SearchString { get; set; }

    }
}
