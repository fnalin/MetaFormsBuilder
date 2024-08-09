using MetaFormsBuilder.Data;
using MetaFormsBuilder.Data.Data;
using MetaFormsBuilder.Data.Repositories;
using MetaFormsBuilder.Domain.Contracts.Infra;
using MetaFormsBuilder.Domain.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MetaFormsBuilderDbContext>(options =>
{
    //dotnet ef migrations add Initial --project ./MetaFormsBuilder.Data -s ./MetaFormsBuilder.Web -c MetaFormsBuilderDbContext
    //dotnet ef database update --project ./MetaFormsBuilder.Web
    
    options.UseSqlServer(builder.Configuration.GetConnectionString("MetaFormsBuilderDbConnection"));
});

builder.Services.AddTransient<IFormRepository, FormRepository>();
builder.Services.AddTransient<IFieldRepository, FieldRepository>();
builder.Services.AddTransient<IDataTypeRepository, DataTypeRepository>();
builder.Services.AddTransient<IFormSubmitedRepository, FormSubmitedRepository>();
builder.Services.AddScoped<IUoW, UoW>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();