using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreBackend.Domain.Entities;

[Table("User")]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("Name")]
    [StringLength(50)]
    [Required]
    public required string Name { get; set; }

    [Required]
    public Guid ExternalId { get; set; }

    [Required]
    [MaxLength(50)]
    public required string Username { get; set; }

    [Required]
    [MaxLength(100)]
    public string Email { get; set; } = String.Empty;

    [Required]
    [MaxLength(256)]
    public string Passwordhash { get; set; } = String.Empty;
}
