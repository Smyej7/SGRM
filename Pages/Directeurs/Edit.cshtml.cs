using SGRM.Authorization;
using SGRM.Data;
using SGRM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGRM.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SGRM.Pages.Directeurs
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
        public Directeur Directeur { get; set; }
        public SelectList? Departements { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ViewData["RequestMethod"] = Request.Method;
            ViewData["ResponseStatusCode"] = Response.StatusCode;
            if (id == null)
            {
                return NotFound();
            }

            Directeur? directeur = await Context.Directeurs.FirstOrDefaultAsync(
                                                                m => m.DirecteurId == id);

            if (directeur == null)
            {
                return NotFound();
            }

            Directeur = directeur;

            IQueryable<int> departementsQuery = from d in Context.Departements
                                                orderby d.DepartementId
                                                select d.DepartementId;
            departementsQuery.ToList().ForEach(d => { Console.WriteLine(d); });
            //departementsQuery = departementsQuery.Where(i => i != Directeur.DepartementId);
            Departements = new SelectList(departementsQuery.ToList());

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            //ViewData["NotificationMessage"] = "Changes successfully saved";
            ViewData["RequestMethod"] = Request.Method;
            ViewData["ResponseStatusCode"] = Response.StatusCode;
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                // Fetch Contact from DB to get OwnerID.
                var directeur = await Context
                    .Directeurs.AsNoTracking()
                    .FirstOrDefaultAsync(d => d.DirecteurId == id);

                if (directeur == null)
                {
                    return NotFound();
                }

                Context.Attach(Directeur).State = EntityState.Modified;

                await Context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch(Exception ex) 
            {
                ViewData["NotificationMessage"] = "dept kda has already a directeur";
                IQueryable<int> departementsQuery = from d in Context.Departements
                                                    orderby d.DepartementId
                                                    select d.DepartementId;
                departementsQuery.ToList().ForEach(d => { Console.WriteLine(d); });
                //departementsQuery = departementsQuery.Where(i => i != Directeur.DepartementId);
                Departements = new SelectList(departementsQuery.ToList());
                return Page();
            }
        }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
