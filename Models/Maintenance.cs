namespace SGRM.Models
{
    public class Maintenance
    {
        public int MaintenanceId { get; set; }

        public string Name { get; set; }

        public int? DepartementId { get; set; }
        public Departement? Departement { get; set; }

        public string? IdentityUserId { get; set; } //modify later to notNull
    }
}
