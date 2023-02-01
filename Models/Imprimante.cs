namespace SGRM.Models
{
    public class Imprimante
    {
        public int ImprimanteId { get; set; }
        public string Name { get; set; }
        public int RessourceId { get; set; }
        public Ressource? Ressource { get; set; }
        public int TypeRessourceId { get; set; }
    }
}
