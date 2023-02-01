using SGRM.Authorization;
using SGRM.Data;
using SGRM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SGRM.Pages.Laboratoires
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class CreateModel : DI_BasePageModel
    {
        public CreateModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Laboratoire Laboratoire { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine($"ModelState.IsValid : {ModelState.IsValid}");
            IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (ModelError item in errors)
            {
                Console.WriteLine($"item.Exception : {item.Exception}");
                Console.WriteLine($"item.GetHashCode : {item.GetHashCode}");
                Console.WriteLine($"item.ErrorMessage : {item.ErrorMessage}");
                Console.WriteLine($"item.GetType : {item.GetType}");
                Console.WriteLine($"item.ToString : {item.ToString}");
            }
            Console.WriteLine(Laboratoire);
            /*
            if (!ModelState.IsValid)
            {
                return Page();
            }
            */
            Context.Laboratoires.Add(Laboratoire);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
