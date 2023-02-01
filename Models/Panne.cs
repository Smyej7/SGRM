namespace SGRM.Models
{
    public class Panne
    {
        public int PanneId { get; set; }
        public string Name { get; set; }
        public int RessourceId { get; set; }
        public Ressource? Ressource { get; set; }
        public int TypePanneId { get; set; }
    }
}
