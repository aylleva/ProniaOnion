using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Domain.Entities
{
public class AppUser:IdentityUser
    {
        public string Name {  get; set; }
        public string Surname {  get; set; }
        public bool IsActive {  get; set; }

        public AppUser()
        {
            IsActive = true;
        }
    }
}
