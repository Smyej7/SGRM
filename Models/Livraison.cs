namespace SGRM.Models
{
    public class Livraison
    {
        public int LivraisonId { get; set; }
        public string Name { get; set; }
        public List<Ressource>? Ressources { get; set; }
        public int FournisseurId { get; set; }
        public Fournisseur? Fournisseur { get; set; }
    }
}
