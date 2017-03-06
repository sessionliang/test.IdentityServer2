using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace IS.Users.Infrastructure
{
    /// <summary>
    /// 自定义密码复杂策略
    /// </summary>
    public class CustomePasswordValidator : PasswordValidator
    {
        public override async Task<IdentityResult> ValidateAsync(string password)
        {
            IdentityResult result = await base.ValidateAsync(password);

            //内建的验证通过后，验证定制的逻辑
            if (password.Contains("123456"))
            {
                var errors = result.Errors.ToList();
                errors.Add("密码不能包含数字序列。");
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
}