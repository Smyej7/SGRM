using Microsoft.Data.SqlClient;
using SGRM.Data;

namespace SGRM.Models
{
    public class Enseignant
    {
        public int EnseignantId { get; set; }

        public string Name { get; set; }

        public int? DepartementId { get; set; }
        public Departement? Departement { get; set; }

        public List<Laboratoire> Laboratoires { get; set; }

        public string? IdentityUserId { get; set; } //modify later to notNull

        public override string ToString()
        {
            string s = $"Enseignant[ Id : {EnseignantId}, name : {Name}, DepartementId : {DepartementId}, ";
            s += $"LaboratoiresID : {toStr(getLaboratoires(EnseignantId))}, ";
            s += $"IdentityUserId : {IdentityUserId}]";
            return s;
        }

        public static string toStr(List<int> list)
        {
            string s = "[";
            if (list == null) 
            {
                s += "null" + "]";
                return s;
            }

            if (list.Count == 0)
            {
                s += "]";
                return s;
            } else if (list.Count == 1)
            {
                s += list[0] + "]";
                return s;
            }
            else {
                s += list[0];
            }

            for (int i = 1; i < list.Count; i++)
            {
                s += ", " + list[i];
            }
            s += "]";
            return s;
        }

        public static List<int> getLaboratoires(int enseignantId)
        {
            string? connString = "Server=(localdb)\\mssqllocaldb;Database=aspnet-SGRM;Trusted_Connection=True;MultipleActiveResultSets=true";
            List<int> laboratoiresId = new List<int>();
            string query;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    query = "SELECT LaboratoiresLaboratoireId FROM AssociationEnseignantsLaboratoires " +
                                    $"where EnseignantsEnseignantId = {enseignantId}";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            laboratoiresId.Add(dr.GetInt32(0));
                        }
                    }
                    dr.Close();
                    conn.Close();
                    return laboratoiresId;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
