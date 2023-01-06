using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGRM.Data;
using SGRM.Models;

namespace SGRM.Pages.Directeurs
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class DeleteModel : DI_BasePageModel
    {
        public DeleteModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        [BindProperty]
        public Directeur Directeur { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Directeur? directeur = await Context.Directeurs.FirstOrDefaultAsync(
                                                        d => d.DirecteurId == id);

            if (directeur == null)
            {
                return NotFound();
            }

            Directeur = directeur;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directeur = await Context
                .Directeurs.AsNoTracking()
                .FirstOrDefaultAsync(d => d.DirecteurId == id);

            if (directeur == null)
            {
                return NotFound();
            }

            Context.Directeurs.Remove(directeur);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
