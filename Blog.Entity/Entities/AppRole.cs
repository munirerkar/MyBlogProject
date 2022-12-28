﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public int MyProperty { get; set; }
    }
}
