using Microsoft.AspNetCore.Mvc.Rendering;
using SGRM.Models;

namespace SGRM.ViewModels
{
    public class DirecteurViewModel
    {
        public Directeur? directeur { get; set; }
        public SelectList? Departements { get; set; }
    }
}
