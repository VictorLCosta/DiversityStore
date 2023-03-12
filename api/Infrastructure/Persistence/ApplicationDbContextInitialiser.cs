using System.Text.Json;

using Api.Domain.Entities;
using Api.Domain.Entities.Identity;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILoggerFactory loggerFactory, ApplicationDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = loggerFactory.CreateLogger<ApplicationDbContextInitialiser>();
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            var administratorRole = new IdentityRole("Administrator");
            var customerRole = new IdentityRole("Customer");

            if (!await _roleManager.Roles.AnyAsync())
            {
                await _roleManager.CreateAsync(administratorRole);
                await _roleManager.CreateAsync(customerRole);
            }

            var administrator = new AppUser { UserName = "admin@example.com", Email = "admin@example.com", DisplayName = "Admin" };

            if (!await _userManager.Users.AnyAsync())
            {
                var result = await _userManager.CreateAsync(administrator, "sistema123");
                if (!string.IsNullOrWhiteSpace(administratorRole.Name))
                {
                    await _userManager.AddToRolesAsync(administrator, new [] { administratorRole.Name });
                }
            }

            if (!await _context.Customers.AnyAsync()) 
            {
                var customersData = File.ReadAllText("../Infrastructure/Persistence/SeedData/customers.json");

                var customers = JsonSerializer.Deserialize<List<Customer>>(customersData);

                foreach (var item in customers!)
                {
                    await _userManager.CreateAsync(item.AppUser, "sistema123");
                    if (!string.IsNullOrWhiteSpace(customerRole.Name))
                    {
                        await _userManager.AddToRolesAsync(item.AppUser, new [] { customerRole.Name });
                    }

                    await _context.Customers.AddAsync(item);
                }

                await _context.SaveChangesAsync();
            }
            if (!await _context.Products.AnyAsync()) 
            {
                var productsData = File.ReadAllText("../Infrastructure/Persistence/SeedData/products.json");

                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                foreach (var item in products!)
                {
                    await _context.Products.AddAsync(item);
                }

                await _context.SaveChangesAsync();
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }
}
