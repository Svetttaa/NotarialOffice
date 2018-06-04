using System;
using System.Data.Entity;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NotarialOffice.Models.Data;

namespace NotarialOffice.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
	    public DbSet<Category> Categories { get; set; }
	    public DbSet<Item> Items { get; set; }
	    public DbSet<News> News { get; set; }
	    public DbSet<Request> Requests { get; set; }

		public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

		public class AppDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
	    //public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
	    {
		    protected override void Seed(ApplicationDbContext context)
		    {
			    #region Роли

			    var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
			    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

			    var adminRole = new IdentityRole
			    {
				    Name = "Admin"
			    };

			    roleManager.Create(adminRole);

			    var admin = new ApplicationUser
			    {
				    Email = "admin@mail.ru",
				    UserName = "admin@mail.ru"
			    };
			    string password = "QWErty1!";
			    var result = userManager.Create(admin, password);

			    if(result.Succeeded) userManager.AddToRole(admin.Id, adminRole.Name);

			    #endregion

			    var db = new ApplicationDbContext();

			    int i = 1;
			    foreach(var s in File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content", "cont.txt")))
			    {
				    if(s.StartsWith("#"))
					    continue;

				    var info = s.Split('|');

				    var item = new Item()
				    {
					    Id = i++,
					    Title = info[0],
					    Price = info[2],
					    Description = info[3]
				    };

				    db.Items.Add(item);
			    }

			    db.SaveChanges();
			    base.Seed(context);
		    }
	    }

    }
}