namespace SGRM.Models
{
    public class PersonnelDepartement
    {
        public int PersonnelDepartementId { get; set; }

        public string Name { get; set; }

        public int? DepartementId { get; set; }
        public Departement? Departement { get; set; }

        public string? IdentityUserId { get; set; } //modify later to notNull
    }
}
