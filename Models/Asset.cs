namespace EasyKeep.Models;

public class Asset
{
    public int Id { get; set; }
    public string AssetCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime PurchaseDate { get; set; }
    public decimal PurchasePrice { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public string UpdatedBy { get; set; } = string.Empty;
    public DateTime UpdatedAt { get; set; }
    public string? ImageUrl { get; set; } = string.Empty;
    public string? SerialNumber { get; set; } = string.Empty;
    public string? Manufacturer { get; set; } = string.Empty;
    public string? Model { get; set; } = string.Empty;
    public string? WarrantyInfo { get; set; } = string.Empty;
    public string? Notes { get; set; } = string.Empty;
    public string? AssignedTo { get; set; } = string.Empty;
    public DateTime? AssignedDate { get; set; }
    public DateTime? ExpectedReturnDate { get; set; }
}