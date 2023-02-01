namespace SGRM.Models
{
    public class Directeur
    {
        public int DirecteurId { get; set; }

        public string Name { get; set; }

        public int? DepartementId { get; set; }
        public Departement? Departement { get; set; }

        public string? IdentityUserId { get; set; } //modify later to notNull

        public override string ToString()
        {
            string s = $"Directeur[ Id : {DirecteurId}, name : {Name}, DepartementId : {DepartementId}, IdentityUserId : {IdentityUserId}]";
            return s;
        }
    }
}
