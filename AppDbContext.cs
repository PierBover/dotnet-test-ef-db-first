using Microsoft.EntityFrameworkCore;
using Api.Models;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions options) : base(options) {}

	public DbSet<Fruit> Fruits { get; set; }
}