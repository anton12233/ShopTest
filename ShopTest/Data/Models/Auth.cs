using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ShopTest.Data.Models
{
    public class Auth
    {

        private readonly AppDBContent appDBContent;

        public Auth(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }


        public static Auth getAuth(IServiceProvider service)
        {
            var context = service.GetService<AppDBContent>();
            return new Auth(context);
        }
        public UserShop setAuth(Login login)
        {
            return appDBContent.Users.Where(p => p.login == login.loginName && p.password == login.password).FirstOrDefault();
        }

        public int getIDbyLogin(string login) 
        {
            return appDBContent.Users.Where(p => p.login == login).FirstOrDefault().id;
        }

    }
}
