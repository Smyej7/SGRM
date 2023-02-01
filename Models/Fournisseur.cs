namespace SGRM.Models
{
    public class Fournisseur
    {
        public int FournisseurId { get; set; }
        public string Name { get; set; }
        public List<Livraison>? Livraisons { get; set; }
    }
}
