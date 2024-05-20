using System.ComponentModel.DataAnnotations;

namespace HaberlerApp.Models;

public class Haber
{
    [Required]
    public string Baslik { get; set; }

    [Required]
    public string Detay { get; set; }

    [Required]
    public string Slug { get; set; }
}
