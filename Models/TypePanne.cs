namespace SGRM.Models
{
    public class TypePanne
    {
        public int TypePanneId { get; set; }
        public string Name { get; set; }
        public List<TypeRessource>? TypeRessources { get; set; }
        public List<Panne>? Pannes { get; set; }
    }
}
