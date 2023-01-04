namespace SGRM.Models
{
    public class Enseignant
    {
        public int EnseignantId { get; set; }

        public string Name { get; set; }

        public int? DepartementId { get; set; }
        public Departement? Departement { get; set; }

        public List<Laboratoire>? Laboratoires { get; set; }

        public string? IdentityUserId { get; set; }

        public override string ToString()
        {
            string s = $"Enseignant[ Id : {EnseignantId}, name : {Name}, DepartementId : {DepartementId}]";
            return s;
        }
    }
}
