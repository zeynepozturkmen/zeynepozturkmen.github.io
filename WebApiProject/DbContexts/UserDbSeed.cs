using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiProject.Entities;

namespace WebApiProject.DbContexts
{
    public static class UserDbSeed
    {
        public static async void Initialize(IServiceProvider serviceProvider, bool create = false)
        {
            using var serviceScope = serviceProvider.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetService<UserDbContext>();

            dbContext.Database.Migrate();

            var user = dbContext.Users.Where(x => !x.IsDeleted && x.UserName == "Emre").FirstOrDefault();

            if (user is null)
            {
                user = new User();
                //user.Id = 1;
                user.UserName = "zeynep";
                user.Email = "zeynepozturkmen@hotmail.com";
                user.Password = "12345";

                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }



        }

    }
}
