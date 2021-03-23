using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constants;

namespace Business.BusinessAspects.Autofac
{
    //JWT icin 
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;//json web token gondereren her bir kisi icin bir httpContext olusur, 

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');//bir metni benim belirttigim karaktere gore ayirip metine atar. 
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();//injection yapmak icin

        }

        protected override void OnBefore(IInvocation invocation)//method interceptiondan methodun onunde calistir. 
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();//claim rollerini bul 
            foreach (var role in _roles)//kullanicinin rollerini gez
            {
                if (roleClaims.Contains(role))
                {
                    return;     //eger claim eslesiyorsa hata verme
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
