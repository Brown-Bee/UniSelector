using Microsoft.AspNetCore.Identity;

namespace UniSelector.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Name { get; set; }
        public string? StateAdress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
    }
}
