namespace WebApi
{
    public class UserCreateResponse
    {
        public Guid? Id { get; set; }
        public List<string> Errors { get; set; }
    }
}
