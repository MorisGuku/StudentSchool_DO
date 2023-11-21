using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace DbModel;

public class DbCar
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string? BrandCar { get; set; }
    public string? ModelCar { get; set; }
    public int CoastCar { get; set; }
    public List<DbUser> Users { get; set; } = new();
    public List<DbSalesOffice> SalesOffices { get; set; } = new();
}

