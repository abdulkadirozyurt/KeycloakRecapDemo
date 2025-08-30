using KeycloakRecapDemo.Domain.Products;
using Microsoft.EntityFrameworkCore;
using System;

namespace KeycloakRecapDemo.Infrastructure.Context;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
}
