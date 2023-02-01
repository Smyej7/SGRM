using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SGRM.Data;
using Microsoft.AspNetCore.Authorization;
using SGRM.Authorization.Role_Responsable;
using SGRM.Authorization.Role_Directeur;
using SGRM.Authorization.Role_PersonnelDepartement;
using SGRM.Authorization.Role_ServiceMaintenance;
//using ContactManager.Authorization;

#region snippet3
#region snippet2
#region snippet
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add Role services to Identity (view in ressources)
builder.Services.AddDefaultIdentity<IdentityUser>(
    options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
#endregion

builder.Services.AddRazorPages();

// Require authenticated users (view in ressources)
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});
#endregion

#region authorisations
// Authorization handlers.
#region Responsable authorisations
builder.Services.AddSingleton<IAuthorizationHandler,
                      DepartementResponsablesAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
                      DirecteurResopnsablesAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
                      EnseignantResopnsablesAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
                      FournisseurResopnsablesAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
                      ImprimanteResopnsablesAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
                      LaboratoireResopnsablesAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
                      LivraisonResopnsablesAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
                      OrdinateurResopnsablesAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
                      PanneResopnsablesAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
                      RessourceResopnsablesAuthorizationHandler>();
#endregion
#region Directeur authorisations
builder.Services.AddSingleton<IAuthorizationHandler,
                      DepartementDirecteursAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
                      DirecteurDirecteursAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
                      EnseignantDirecteursAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
                      FournisseurDirecteursAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
                      ImprimanteDirecteursAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
                      LaboratoireDirecteursAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
                      LivraisonDirecteursAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
                      OrdinateurDirecteursAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
                      PanneDirecteursAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
                      RessourceDirecteursAuthorizationHandler>();
#endregion
#region PersonnelDepartement authorisations
builder.Services.AddSingleton<IAuthorizationHandler,
                      DepartementPersonnelDepartementsAuthorizationHandler>();
/*
builder.Services.AddSingleton<IAuthorizationHandler,
                      DirecteurPersonnelDepartementsAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
                      EnseignantPersonnelDepartementsAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
                      FournisseurPersonnelDepartementsAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
                      ImprimantePersonnelDepartementsAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
                      LaboratoirePersonnelDepartementsAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
                      LivraisonPersonnelDepartementsAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
                      OrdinateurPersonnelDepartementsAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
                      PannePersonnelDepartementsAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
                      RessourcePersonnelDepartementsAuthorizationHandler>();
*/
#endregion
#region Maintenance authorisations
builder.Services.AddSingleton<IAuthorizationHandler,
                      DepartementMaintenancesAuthorizationHandler>();
/*
*/
#endregion
var app = builder.Build();

// Configure the test account (view in ressources)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
    // requires using Microsoft.Extensions.Configuration;
    // Set password with the Secret Manager tool.
    // dotnet user-secrets set SeedUserPW <pw>

    //var testUserPw = builder.Configuration.GetValue<string>("SeedUserPW");
    var testUserPw = "Passw0rd!";
    await SeedData.Initialize(services, testUserPw);
}

#endregion

# region last_region
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
#endregion
#endregion