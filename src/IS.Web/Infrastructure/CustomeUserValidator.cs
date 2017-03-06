using IS.Users.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace IS.Users.Infrastructure
{
    /// <summary>
    /// 自定义用户属性安全策略
    /// </summary>
    public class CustomeUserValidator : UserValidator<AppUser>
    {
        public CustomeUserValidator(UserManager<AppUser, string> manager) : base(manager)
        {
        }

        public override async Task<IdentityResult> ValidateAsync(AppUser user)
        {
            var result = await base.ValidateAsync(user);
            var errors = result.Errors.ToList();
            if (user.UserName.ToLower() == "admin")
            {
                errors.Add("admin is not allowed");
            }
            if (!user.Email.ToLower().EndsWith("@example.com"))
            {
                errors.Add("Only example.com email addresses are allowed");
                result = new IdentityResult(errors);
            }
            if (errors.Count > 0)
            {
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
}