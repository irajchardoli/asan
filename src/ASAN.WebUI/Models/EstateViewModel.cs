using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASAN.WebUI.Models
{
    public class EstateViewModel : ASAN.Entities.Estate
    {
        public EstateViewModel():base()
        {
        }

        public List<SelectListItem> Owners { set; get; }
    }
}