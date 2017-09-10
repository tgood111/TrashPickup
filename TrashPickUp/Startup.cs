using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TrashPickUp.Models;

[assembly: OwinStartupAttribute(typeof(TrashPickUp.Startup))]
namespace TrashPickUp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }


        //In this method we will create default User roles and Admin user for login
        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));




            //in startup i am creating first Admin role and creating default Admin User
            if (!roleManager.RoleExists("Admin"))
            {
                //first create admin role
                var role = new IdentityRole {Name = "Admin"};
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "terenceterrellg@gmail.com";
                user.Email = "terenceterrellg@gmail.com";
                string userPWD = "defaultpass";
                var chkUser = userManager.Create(user, userPWD);
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole { Name = "User" };
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("TrashCollector"))
            {
                var role = new IdentityRole { Name = "TrashCollector"};
                roleManager.Create(role);
            }
            
        }


    }
}
