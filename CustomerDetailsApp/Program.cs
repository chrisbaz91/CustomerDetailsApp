using CustomerDetailsApp.DataAccess;
using CustomerDetailsApp.Validators;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<CustomerContext>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
//builder.Services.AddValidatorsFromAssemblyContaining<FieldsModelValidator>();
//builder.Services.AddScoped<IValidator<CreateModel>, CreateModelValidator>();
//builder.Services.AddScoped<IValidator<EditModel>, EditModelValidator>();

// Seed test data into in-memory database
await SeedData.SetInitialData();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customers}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages();

app.Run();
