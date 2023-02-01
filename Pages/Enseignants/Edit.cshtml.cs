using SGRM.Authorization;
using SGRM.Data;
using SGRM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SGRM.ViewModels;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SGRM.Pages.Enseignants
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public class EditModel : DI_BasePageModel
    {
        public EditModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        [BindProperty]
        public Enseignant Enseignant { get; set; }
        public SelectList? Departements { get; set; }
        public List<Laboratoire> DepartementLaboratoires { get; set; }
        public List<Laboratoire> AttachedLaboratoires { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ViewData["RequestMethod"] = Request.Method;
            ViewData["ResponseStatusCode"] = Response.StatusCode;
            if (id == null)
            {
                return NotFound();
            }
            Enseignant? enseignant = await Context.Enseignants.FirstOrDefaultAsync(
                                                                m => m.EnseignantId == id);
            if (enseignant == null)
            {
                return NotFound();
            }

            Enseignant = enseignant;
            IQueryable<int> departementsQuery = from d in Context.Departements
                                                orderby d.DepartementId
                                                select d.DepartementId;
            Departements = new SelectList(departementsQuery.ToList());

            List<Laboratoire> departementLaboratoires = Context.Laboratoires.ToList();
            List<Laboratoire> attachedLaboratoires = SeedData.getLaboratoiresByEnseignantId(Context, enseignant.EnseignantId);
            DepartementLaboratoires = departementLaboratoires; 
            AttachedLaboratoires = attachedLaboratoires;

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            ViewData["RequestMethod"] = Request.Method;
            ViewData["ResponseStatusCode"] = Response.StatusCode;
            Console.WriteLine($"ModelState.IsValid : {ModelState.IsValid}");
            /*
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (ModelError item in errors)
                {
                    Console.WriteLine(item.ErrorMessage);
                }
                return Page();
            }
            */
            // Fetch Contact from DB to get OwnerID.
            var enseignant = await Context
                .Enseignants.AsNoTracking()
                .FirstOrDefaultAsync(d => d.EnseignantId == id);

            if (enseignant == null)
            {
                return NotFound();
            }
            Context.Attach(Enseignant).State = EntityState.Modified;

            await Context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        public IActionResult OnPostDetachLaboratoire(int enseignantId, int laboratoireId)
        {
            //Console.WriteLine($"remove ensId : {enseignantId}, laboId : {laboratoireId}");
            
            SeedData.removeEnsLaboAssociation(Context, enseignantId, laboratoireId);
            return Redirect($"https://localhost:7137/Enseignants/Edit?id={enseignantId}");
        }
        
        public IActionResult OnPostAttachLaboratoire(int enseignantId, int laboratoireId)
        {
            SeedData.addEnsLaboAssociation(Context, enseignantId, laboratoireId);
            return Redirect($"https://localhost:7137/Enseignants/Edit?id={enseignantId}");
        }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
