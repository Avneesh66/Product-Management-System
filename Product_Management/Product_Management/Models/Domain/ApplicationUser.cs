using Microsoft.AspNetCore.Identity;

namespace Product_Management.Models.Domain
{
    public class ApplicationUser:IdentityUser
    {
        public string ? Name { get; set; }

        public string ? ProfilePictute {  get; set; }
    }
}
