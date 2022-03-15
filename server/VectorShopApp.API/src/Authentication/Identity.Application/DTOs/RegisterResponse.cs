using Identity.Domain.Entities;


namespace Identity.Application.DTOs
{
    public class RegisterResponse
    {
        public bool IsSuccess { get; set; }
        public User User { get; set; }
    }
}
