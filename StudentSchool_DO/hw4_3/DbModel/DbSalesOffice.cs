namespace DbModel;

public class DbSalesOffice
{
    public Guid Id { get; set; }
    public string? NameSalesOffice { get; set; }
    public string? AddressSalesOffice { get; set; }
    public List<DbCar> Cars { get; set; } = new();
}
