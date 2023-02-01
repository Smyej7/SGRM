using SGRM.Models;

namespace SGRM.ViewModels
{
    public class EnseignantViewModel
    {
        public Enseignant? Enseignant { get; set; }
        public List<Laboratoire>? AttachedLaboratoires { get; set; }
        public List<Laboratoire>? DepartementLaboratoires { get; set; }
    }
}
