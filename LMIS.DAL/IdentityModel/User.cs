using LMIS.DAL.Context;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMIS.DAL.IdentityModel
{
    public class User : IdentityUser
    {
        public bool IsActive { get; set; }
    }
}
