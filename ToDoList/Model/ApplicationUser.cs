using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Model
{
    public class ApplicationUser:IdentityUser<int>//,CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        //public override int Id { get; set; }
        public string Password { get; set; }
        //public string token { get; set; }
        //public DateTime expiration { get; set; }
    }
}
