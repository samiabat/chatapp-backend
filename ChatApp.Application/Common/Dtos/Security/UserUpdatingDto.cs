using Microsoft.AspNetCore.Http;

namespace ChatApp.Application.Common.Dtos.Security
{
    public class UserUpdatingDto
    {
        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }
        public IFormFile? Profilepicture { get; set; }

    }
}