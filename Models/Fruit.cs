namespace Api.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Fruits")]
public class Fruit {
	[Column("id")]
	public int Id { get; set; }

	[Column("name")]
	[Required]
	[StringLength(10)]
	[Display(Name = "name")]
	public required string Name { get; set; }

	[Column("color")]
	[Required]
	[StringLength(10)]
	[Display(Name = "color")]
	public required string Color { get; set; }

	[Column("createdAt")]
	// this tells EF to let the DB generate a value when inserting a row
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	// set is private so that it cannot be added when creating a new fruit
	// we want the DB to always set it automatically
	public DateTime CreatedAt { get; private set; }
}