using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuscaCamping.DataAccess.Modelo;

namespace BuscaCamping.DataAccess.ViewModels
{
    public class OpinionViewModel
    {
        public Opinion Opinion { get; set; }
        public Camping Camping { get; set; }
    }
}
