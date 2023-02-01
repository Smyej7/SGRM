using SGRM.Authorization;
using SGRM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Configuration;

// dotnet aspnet-codegenerator razorpage -m Contact -dc ApplicationDbContext -outDir Pages\Contacts --referenceScriptLibraries
namespace SGRM.Data
{
    public static class SeedData
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        #region snippet_Initialize
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // For sample purposes seed both with the same password.
                // Password is set with the following:
                // dotnet user-secrets set SeedUserPW <pw>
                // The admin user can do anything
                
                var adminID = await EnsureUser(serviceProvider, testUserPw, "responsable@fake.com");
                await EnsureRole(serviceProvider, adminID, Roles.ResponsableRole);

                // allowed user can create and edit contacts that they create
                var managerID = await EnsureUser(serviceProvider, testUserPw, "directeur1@fake.com");
                await EnsureRole(serviceProvider, managerID, Roles.DirecteurRole);

                Initialize(serviceProvider);
            }
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                                    string testUserPw, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = UserName,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, testUserPw);
            }

            if (user == null)
            {
                throw new Exception("The password is probably not strong enough!");
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                                      string uid, string role)
        {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            IdentityResult IR;
            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            //if (userManager == null)
            //{
            //    throw new Exception("userManager is null");
            //}

            var user = await userManager.FindByIdAsync(uid);

            if (user == null)
            {
                throw new Exception("The testUserPw password was probably not strong enough!");
            }

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }
        #endregion

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                SeedDB(context);
            }
        }

        public static List<Laboratoire> getLaboratoiresByEnseignantId(ApplicationDbContext context, int enseignantId)
        {
            string? connString = context.Database.GetConnectionString();
            List<Laboratoire> laboratoires = new List<Laboratoire>();
            string query;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    query = "SELECT LaboratoiresLaboratoireId FROM AssociationEnseignantsLaboratoires " +
                                    $"where EnseignantsEnseignantId = {enseignantId}";
                    /*
                    string query = @"SELECT e.id,e.code,e.firstName,e.lastName,l.code,l.descr
                                     FROM employees e
                                     INNER JOIN location l on e.locationID=l.id";
                    */
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    //Console.WriteLine("\nRetrieving data from database...\n");
                    //Console.WriteLine("Retrieved records:");
                    List<int> laboratoiresId = new List<int>();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Console.WriteLine($"dr.GetInt32(0) : {dr.GetInt32(0)}");
                            laboratoiresId.Add(dr.GetInt32(0));
                        }
                    }
                    dr.Close();
                    conn.Close();

                    if (laboratoiresId.Count > 0)
                    {
                        laboratoires = context.Laboratoires.Where(l => laboratoiresId.Contains(l.LaboratoireId)).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return laboratoires;
        }

        public static void removeEnsLaboAssociation(ApplicationDbContext context, int enseignantId, int laboratoireId)
        {
            string? connString = context.Database.GetConnectionString();
            string query;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    query = "DELETE FROM AssociationEnseignantsLaboratoires " +
                            $"where EnseignantsEnseignantId = {enseignantId} " +
                            $"and LaboratoiresLaboratoireId = {laboratoireId}";

                    /*
                    string query = @"SELECT e.id,e.code,e.firstName,e.lastName,l.code,l.descr
                                     FROM employees e
                                     INNER JOIN location l on e.locationID=l.id";
                    */
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void addEnsLaboAssociation(ApplicationDbContext context, int enseignantId, int laboratoireId)
        {
            string? connString = context.Database.GetConnectionString();
            string query;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    query = "INSERT INTO AssociationEnseignantsLaboratoires " + 
                            $"VALUES({enseignantId}, {laboratoireId})";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void SeedDB(ApplicationDbContext context)
        {
            //initData(context);
            //removeData(context);
            PrintDB(context);
        }

        public static string GetConnectionString()
        {
            ConnectionStringSettingsCollection settings =
                System.Configuration.ConfigurationManager.ConnectionStrings;

            if (settings != null)
            {
                return settings[0].ConnectionString;
            }
            return null;
        }

        public static void initData(ApplicationDbContext context)
        {
            AddDepartements(context);
            AddDirecteurs(context);
            AddEnseignants(context);
            AddLaboratoires(context);

            LinkDirecteurDepartement(context, 1, 1);
            LinkDirecteurDepartement(context, 2, 2);

            LinkLaboratoireDepartement(context, 1, 1);
            LinkLaboratoireDepartement(context, 2, 1);
            LinkLaboratoireDepartement(context, 3, 2);

            LinkEnseignantDepartement(context, 1, 1);
            LinkEnseignantDepartement(context, 2, 1);
            LinkEnseignantDepartement(context, 3, 2);

            LinkEnseignantLaboratoire(context, 1, 1);
            LinkEnseignantLaboratoire(context, 1, 2);
            LinkEnseignantLaboratoire(context, 2, 1);
            LinkEnseignantLaboratoire(context, 3, 2);
        }

        private static void removeData(ApplicationDbContext context)
        {
            removeAllEnseignants(context);
            removeAllLaboratoiress(context);
            removeAllDirecteurs(context);
            removeAllDepartements(context);
        }

        private static void removeAllEnseignants(ApplicationDbContext context)
        {
            if (context.Enseignants.Any())
            {
                context.RemoveRange(context.Enseignants.ToList());
                context.SaveChanges();
            }
        }

        private static void removeAllDepartements(ApplicationDbContext context)
        {
            if (context.Departements.Any())
            {
                context.RemoveRange(context.Departements.ToList());
                context.SaveChanges();
            }
        }

        private static void removeAllDirecteurs(ApplicationDbContext context)
        {
            if (context.Directeurs.Any())
            {
                context.RemoveRange(context.Directeurs.ToList());
                context.SaveChanges();
            }
        }

        private static void removeAllLaboratoiress(ApplicationDbContext context)
        {
            if (context.Laboratoires.Any())
            {
                context.RemoveRange(context.Laboratoires.ToList());
                context.SaveChanges();
            }
        }

        public static void AddDepartements(ApplicationDbContext context)
        {
            context.Departements.AddRange(
                new Departement
                {
                    Name = "dept 1"
                },
                new Departement
                {
                    Name = "dept 2"
                }
            );
            context.SaveChanges();
        }

        public static void AddDirecteurs(ApplicationDbContext context)
        {
            context.Directeurs.AddRange(
                new Directeur
                {
                    Name = "dir 1-1"
                },
                new Directeur
                {
                    Name = "dir 2-2"
                }
            );
            context.SaveChanges();
        }

        public static void AddEnseignants(ApplicationDbContext context)
        {
            context.Enseignants.AddRange(
                new Enseignant
                {
                    Name = "ens 1-1"
                },
                new Enseignant
                {
                    Name = "ens 1-2"
                },
                new Enseignant
                {
                    Name = "ens 2-3"
                }
            );
            context.SaveChanges();
        }

        public static void AddLaboratoires(ApplicationDbContext context)
        {
            context.Laboratoires.AddRange(
                new Laboratoire
                {
                    Name = "lab 1-1", 
                    DepartementId = 1
                },
                new Laboratoire
                {
                    Name = "lab 1-2",
                    DepartementId = 1
                },
                new Laboratoire
                {
                    Name = "lab 2-3",
                    DepartementId = 2
                }
            );
            context.SaveChanges();
        }

        public static void LinkDirecteurDepartement(ApplicationDbContext context, int directeurId, int departementId)
        {
            Directeur dir = context.Directeurs.Where(dir => dir.DirecteurId == directeurId).FirstOrDefault();

            if (dir == null) return;

            dir.DepartementId = departementId;

            context.SaveChanges();
        }

        public static void LinkEnseignantLaboratoire(ApplicationDbContext context, int enseignantId, int laboratoireId)
        {
            Enseignant ens = context.Enseignants.Where(e => e.EnseignantId == enseignantId).FirstOrDefault();
            Laboratoire labo = context.Laboratoires.Where(l => l.LaboratoireId == laboratoireId).FirstOrDefault();

            if (ens == null) return;
            if (labo == null) return;

            if (ens.Laboratoires == null)
            {
                ens.Laboratoires = new List<Laboratoire>();
                Console.WriteLine("ens.Laboratoires == null");
            }
            else
            {
                foreach (Laboratoire l in ens.Laboratoires)
                {
                    Console.Write(l.LaboratoireId + "; ");
                }
            }
            ens.Laboratoires.Add(labo);

            context.SaveChanges();
        }

        public static void LinkEnseignantDepartement(ApplicationDbContext context, int enseignantId, int departementId)
        {
            Enseignant ens = context.Enseignants.Where(e => e.EnseignantId == enseignantId).FirstOrDefault();

            if (ens == null) return;

            ens.DepartementId = departementId;
            context.SaveChanges();
        }

        public static void LinkLaboratoireDepartement(ApplicationDbContext context, int laboratoireId, int departementId)
        {
            Laboratoire labo = context.Laboratoires.Where(l => l.LaboratoireId == laboratoireId).FirstOrDefault();

            if (labo == null) return;

            labo.DepartementId = departementId;

            context.SaveChanges();
        }

        public static void PrintDB(ApplicationDbContext context)
        {
            if (context.Departements.Any())
                context.Departements.ToList().ForEach(Console.WriteLine);
            
            if (context.Directeurs.Any())
                context.Directeurs.ToList().ForEach(Console.WriteLine);

            if (context.Enseignants.Any())
                context.Enseignants.ToList().ForEach(Console.WriteLine);

            if (context.Laboratoires.Any())
                context.Laboratoires.ToList().ForEach(Console.WriteLine);
        }
    }
}
#pragma warning restore CS8602 // Dereference of a possibly null reference.
