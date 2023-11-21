using System.Runtime.InteropServices;

namespace DbModel;

public class DbUser
{
    public Guid UserId { get; set; }
    public Guid CarId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.Now;
    public List<DbCar> Cars {get; set;}
}
