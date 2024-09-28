using Microsoft.AspNetCore.Identity;

namespace InventoryRepository.Data
{
    public class Appuser : IdentityUser
    {
        public string Name { get; set; }
    }
}