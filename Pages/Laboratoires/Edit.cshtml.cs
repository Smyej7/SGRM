using SGRM.Authorization;
using SGRM.Data;
using SGRM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SGRM.Pages.Laboratoires
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
        public Laboratoire Laboratoire { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Laboratoire? laboratoire = await Context.Laboratoires.FirstOrDefaultAsync(
                                                                m => m.LaboratoireId == id);

            if (laboratoire == null)
            {
                return NotFound();
            }

            Laboratoire = laboratoire;

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            Console.WriteLine($"ModelState.IsValid : {ModelState.IsValid}");
            IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (ModelError item in errors)
            {
                Console.WriteLine(item.ErrorMessage);
            }
            /*
            if (!ModelState.IsValid)
            {
                return Page();
            }
            */
            // Fetch Contact from DB to get OwnerID.
            var laboratoire = await Context
                .Laboratoires.AsNoTracking()
                .FirstOrDefaultAsync(d => d.LaboratoireId == id);

            if (laboratoire == null)
            {
                return NotFound();
            }

            Context.Attach(Laboratoire).State = EntityState.Modified;

            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
