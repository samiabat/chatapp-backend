namespace ChatApp.Application.Common.Dtos.Security
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int Age { get; set; }

    }
}