using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("MOVIES")]
public class Movie {

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    [Column("MOVIE_ID")]
    public int Id { get; set; }

    [StringLength(100, ErrorMessage = "invalid string length: name")]
    [Required(ErrorMessage = "name required")]
    [Column("NAME", TypeName = "VARCHAR(100)")]
    public string? Name { get; set; }
        
    [StringLength(255, ErrorMessage = "invalid string length: short-description")]
    [Required(ErrorMessage = "short-description required")]
    [Column("SHORT_DESCRIPTION", TypeName = "VARCHAR(255)")]
    public string? ShortDescription { get; set; }
        
    [StringLength(1000, ErrorMessage = "invalid string length: description")]
    [Required(ErrorMessage = "description required")]
    [Column("DESCRIPTION", TypeName = "TEXT")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "release date required")]
    [Column("RELEASE_DATE")]
    public DateTime ReleaseDate { get; set; } = DateTime.Today;
        
    [Required(ErrorMessage = "genre required")]
    [Column("GENRE")]
    public EGenre Genre { get; set; }
        
    [Range(1, 1000, ErrorMessage = "invalid number value: length")]
    [Required(ErrorMessage = "movie length is required")]
    [Column("DURATION", TypeName = "DECIMAL(4,0)")]
    public int Duration { get; set; }
        
        
    [StringLength(100, ErrorMessage = "invalid string length: director")]
    [Required(ErrorMessage = "director required")]
    [Column("DIRECTOR", TypeName = "VARCHAR(100)")]
    public string? Director { get; set; }

    [NotMapped]
    public List<string>? Writers { get; set; }
}