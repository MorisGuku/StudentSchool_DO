namespace hw_2.WebApi;

public class UserDto
{
  public Guid UserId { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public DateTime CreatedTime { get; set; }
}
