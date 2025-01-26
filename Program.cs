using Api.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => {
	options.UseNpgsql(builder.Configuration.GetConnectionString("AppDatabase"));
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/fruits", async (string color, AppDbContext db) => {

	List<Fruit> fruits;

	if (color != null) {
		fruits = await db.Fruits.Where(f => f.Color == color).ToListAsync();
	} else {
		fruits = await db.Fruits.ToListAsync();
	}

	return Results.Ok(fruits);
});

app.MapGet("/fruits/{id}", async (int id, AppDbContext db) => {
	if (await db.Fruits.FindAsync(id) is Fruit fruit) {
		return Results.Ok(fruit);
	}
	return Results.NotFound();
});

app.MapPost("/fruits", async (Fruit fruit, AppDbContext db) => {
	db.Fruits.Add(fruit);
	await db.SaveChangesAsync();
});

app.MapDelete("/fruits/{id}", async (int id, AppDbContext db) => {
	if (await db.Fruits.FindAsync(id) is Fruit fruit) {
		db.Fruits.Remove(fruit);
		await db.SaveChangesAsync();
		return Results.Ok();
	}
	return Results.NotFound();
});

app.Run();
