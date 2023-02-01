namespace SGRM.Models
{
    public class Laboratoire
    {
        public int LaboratoireId { get; set; }

        public string Name { get; set; }

        public int DepartementId { get; set; }
        public Departement Departement { get; set; }

        public List<Enseignant> Enseignants { get; set; }

        public override string ToString()
        {
            string s = $"Laboratoire[ Id : {LaboratoireId}, name : {Name}, DepartementId : {DepartementId}]";
            return s;
        }
    }
}
