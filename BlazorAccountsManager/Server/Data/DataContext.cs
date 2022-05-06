namespace BlazorAccountsManager.Server.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(b => { b.ToTable("Users"); });
            modelBuilder.Entity<IdentityUserClaim<string>>(b => { b.ToTable("UserClaims"); });
            modelBuilder.Entity<IdentityUserLogin<string>>(b => { b.ToTable("UserLogins"); });
            modelBuilder.Entity<IdentityUserToken<string>>(b => { b.ToTable("UserTokens"); });
            modelBuilder.Entity<IdentityRole>(b => { b.ToTable("Roles"); });
            modelBuilder.Entity<IdentityRoleClaim<string>>(b => { b.ToTable("RoleClaims"); });
            modelBuilder.Entity<IdentityUserRole<string>>(b => { b.ToTable("UserRoles"); });

            foreach (string role in Enum.GetNames(typeof(Roles)))
            {
                var guid = Guid.NewGuid().ToString();
                modelBuilder.Entity<IdentityRole>().HasData(
                    new IdentityRole
                    {
                        Name = role,
                        NormalizedName = role.ToUpper(),
                        Id = guid,
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    });

                if (role == "SuperAdmin")
                    SeedSuperUser(modelBuilder, guid);

            }    
        }




        private void SeedSuperUser(ModelBuilder builder, string roleGuid)
        {
            var userGuid = Guid.NewGuid().ToString();
            ApplicationUser user = new ApplicationUser()
            {
                Id = userGuid,
                UserName = "superadmin",
                NormalizedUserName = "SUPERADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                FirstName = "Super",
                LastName = "Admin",
                DisplayName = "SuperAdmin"
            };

            user.PasswordHash = GeneratePasswordHash(user, "Admin*123");
            builder.Entity<ApplicationUser>().HasData(user);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>() 
            { 
                RoleId = roleGuid, 
                UserId = userGuid
            });
        }

        public string GeneratePasswordHash(ApplicationUser user, string password)
        {
            var passHash = new PasswordHasher<ApplicationUser>();
            return passHash.HashPassword(user, password);
        }


    }
}
