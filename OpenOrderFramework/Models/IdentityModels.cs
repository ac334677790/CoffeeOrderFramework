using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OpenOrderFramework.Models {
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager) {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false) {
        }


        public DbSet<Item> Items { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Catagorie> Catagories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Param> Params { get; set; }
        public DbSet<CodeKind> CodeKinds { get; set; }
        public DbSet<Code> Codes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<UserGroup_m> UserGroup_ms { get; set; }
        public DbSet<UserGroup_d> UserGroup_ds { get; set; }
        public DbSet<Privilege> Privileges { get; set; }
        public DbSet<ProductKind> ProductKinds { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<LongOrder_m> LongOrder_ms { get; set; }
        public DbSet<Order_m> Order_ms { get; set; }
        public DbSet<Order_d> Order_ds { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Factory> Factorys { get; set; }
        public DbSet<CombProduct_m> CombProduct_ms { get; set; }
        public DbSet<CombProduct_d> CombProduct_ds { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product_d> Product_ds { get; set; }
        public DbSet<Order_d_tran> Order_d_trans { get; set; }


        static ApplicationDbContext() {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create() {
            return new ApplicationDbContext();
        }
    }
}