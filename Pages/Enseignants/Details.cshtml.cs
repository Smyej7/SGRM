using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGRM.Data;
using SGRM.Models;
using SGRM.ViewModels;

namespace SGRM.Pages.Enseignants
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class DetailsModel : DI_BasePageModel
    {
        public DetailsModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        public EnseignantViewModel EnseignantVM { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Enseignant? enseignant = await Context.Enseignants.FirstOrDefaultAsync(
                                                                d => d.EnseignantId == id);

            if (enseignant == null)
            {
                return NotFound();
            }

            List<Laboratoire> laboratoires = SeedData.getLaboratoiresByEnseignantId(Context, enseignant.EnseignantId);
            EnseignantVM = new EnseignantViewModel
            {
                Enseignant = enseignant,
                AttachedLaboratoires = laboratoires
            };

            return Page();
        }

    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
