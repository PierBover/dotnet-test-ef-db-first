namespace Api.Models;

using System.ComponentModel.DataAnnotations.Schema;

[Table("Fruits")]
public class Fruit {
	[Column("id")]
	public int Id { get; set; }

	[Column("name")]
	public required string Name { get; set; }

	[Column("color")]
	public required string Color { get; set; }

	[Column("createdAt")]
	// this tells EF to let the DB generate a value when inserting a row
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public DateTime CreatedAt { get; set; }
}