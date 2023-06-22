using Microsoft.AspNetCore.Http;

namespace ChatApp.Application.Common.Dtos.Security
{
    public class UserCreationDto
    {
        public List<RoleDto> Roles { get; set; } = new();
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int Age { get; set; }

        public IFormFile? Profilepicture { get; set; }

    }
}