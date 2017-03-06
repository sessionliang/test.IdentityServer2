using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IS.Users.Models
{
    public class AppUser : IdentityUser
    {
        //添加附加属性

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
    }
}