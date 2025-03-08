using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

public class Article
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Name ist erforderlich")]
    [StringLength(100, ErrorMessage = "Der Name darf nicht länger als 100 Zeichen sein")]
    public string Name { get; set; } = "";
    
    [Required(ErrorMessage = "Typ ist erforderlich")]
    [StringLength(50, ErrorMessage = "Der Typ darf nicht länger als 50 Zeichen sein")]
    public string Type { get; set; } = "";
    
    [Range(0, int.MaxValue, ErrorMessage = "Der Bestand muss 0 oder positiv sein")]
    public int Stock { get; set; }
    
    [Required(ErrorMessage = "Einheit ist erforderlich")]
    [StringLength(20, ErrorMessage = "Die Einheit darf nicht länger als 20 Zeichen sein")]
    public string Unit { get; set; } = "";
    
    [Range(0, 9999999.99, ErrorMessage = "Der Preis muss zwischen 0 und 9.999.999,99 liegen")]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }
    
    [StringLength(100, ErrorMessage = "Der Standort darf nicht länger als 100 Zeichen sein")]
    public string Location { get; set; } = "";
    
    [StringLength(50, ErrorMessage = "Der Status darf nicht länger als 50 Zeichen sein")]
    public string Status { get; set; } = "";
    
    [StringLength(255, ErrorMessage = "Der Link darf nicht länger als 255 Zeichen sein")]
    [Url(ErrorMessage = "Der Link muss eine gültige URL sein")]
    public string Link { get; set; } = "";

    public DateTime Timestamp { get; set; }

    // Neue Spalte für Zellformatierung als JSON-String
    public string StylesJson { get; set; } = "{}";

    [NotMapped]
    public Dictionary<string, CellStyle> Styles
    {
        get => JsonSerializer.Deserialize<Dictionary<string, CellStyle>>(StylesJson) ?? new();
        set => StylesJson = JsonSerializer.Serialize(value);
    }
}

public class CellStyle
{
    public bool Bold { get; set; }
    public bool Italic { get; set; }
    public bool Underline { get; set; }
    
    [RegularExpression(@"^#([0-9A-Fa-f]{6})$", ErrorMessage = "Die Farbe muss ein gültiger Hexadezimal-Farbcode sein")]
    public string Color { get; set; } = "#000000";
}