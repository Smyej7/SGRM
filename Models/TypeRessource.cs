namespace SGRM.Models
{
    public class TypeRessource
    {
        public int TypeRessourceId { get; set; }
        public string Name { get; set; }
        public List<Ressource>? Ressources { get; set; }
        public List<TypePanne>? TypePannes { get; set; }
    }
}
