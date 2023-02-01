namespace SGRM.Models
{
    public class Ordinateur
    {
        public int OrdinateurId { get; set; }
        public string Name { get; set; }
        public int RessourceId { get; set; }
        public Ressource? Ressource { get; set; }
        public int TypeRessourceId { get; set; }
    }
}
