namespace SGRM.Models
{
    public class Departement
    {
        public int DepartementId { get; set; }

        public string Name { get; set; }

        public Directeur? Directeur { get; set; }
        public List<Enseignant>? Enseignants { get; set; }
        public List<Laboratoire>? Laboratoires { get; set; }

        public override string ToString()
        {
            string directeurId = (Directeur == null) ? "" : Directeur.DirecteurId + "";
            string s = $"Departement[ Id : {DepartementId}, name : {Name}, DirecteurId : {directeurId}]";
            return s;
        }
    }
}
