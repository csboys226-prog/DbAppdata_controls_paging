using Microsoft.EntityFrameworkCore;
using DbAppdata_controls_paging.Data; // Ensure this matches your namespace

var builder = WebApplication.CreateBuilder(args);

// --- ADD THESE LINES HERE ---
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("StudentPagingDb")); 
// ----------------------------

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();