using CQRS_Mediatr_LearningProj.Components;
using LearningLibrary;
using LearningLibrary.DataAccess;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register IDataAccess and MediatR
builder.Services.AddSingleton<IDataAccess, DemoDataAccess>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LearningLibraryMediatrEntryPoint).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
