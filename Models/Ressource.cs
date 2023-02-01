namespace SGRM.Models
{
    public class Ressource
    {
        public int RessourceId { get; set; }
        public string Name { get; set; }
        public int LivraisonId { get; set; }
        public Livraison? Livraison { get; set; }
        public int TypeRessourceId { get; set; }
        public TypeRessource? TypeRessource { get; set; }
        public List<Panne>? Pannes { get; set; }
        public string? IdentityUserId { get; set; }
    }
}
