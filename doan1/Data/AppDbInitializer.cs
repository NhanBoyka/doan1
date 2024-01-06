using doan1.Data.Enums;
using doan1.Data.Static;
using doan1.Models;
using Microsoft.AspNetCore.Identity;

namespace doan1.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Brand
                if (!context.Brands.Any())
                {
                    context.Brands.AddRange(new List<Brand>()
                    {
                        new Brand()
                        {
                            Logo = "data:image/png;base64,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",
                            Name = "Ring",
                            Address = "VN",
                            PhoneNumber = 097654321,
                            Email = "email123@gmail.com",
                            Description = "This is the description"
                        },
                        new Brand()
                        {
                            Logo = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADgAAAA4CAMAAACfWMssAAAAYFBMVEX///8AebYAe7cAdbQAc7MAgLry+vzQ5PBSl8Xs9flYoMotjsEMhr3E3Ov6/f5mqM6kyOCqzePc6vN3r9Lj7/aKt9Ypir+OvNmZwtxNmsdFlsWx0eXM3+07ksOCtdYAaq9PC3OsAAACvElEQVRIiZ1X2aKjIAwlJOigiEtbq7Z1/v8vJ4CdaytuNy/BwjEhOYmpEDFp6luWG6VMnt3qxkbPLKUoDSKA9AKAqMpiH2u7lkACEqEyRjnNj2S6HWgFyMdUWaU6/KDTqlT8KsQtaNoyDLJvx2yRsedonmu4O0lJl2ts63pxe2P8dj1J6qMwD+VtfCXLjaRlb6o1mJOa72F0DKeaLRxnV4E0Xy7ZFiCP+PH19pyRn6d6xh0giM0BXvMfOJ5q1563qSTOYptywHbu95YGJf3ks5W0Gc+5VCTN/zXK/iiOwyGxCysLklbzvpQr3yvEsUO4HMcJcYHJZCvhhEE2ycl0JguC7AxOiAyoYFUGdULYVMnKSHW0qUxilYM06OGiSZ3M6DMGhtg0bT4XzknmS42hmF6ELDSkYS/pkfzVr3+DFppomIAVYi1uQP7sH9dXXHN5uKfUAPZaaJe24JHQ8J8mKcHNhUgHYNs0z5K7QON5RXfH/ToK1C4RuUQxAZ1iNvSiJFBP9pYAtI4ABcpccITmQA6y5KIbtGjYW1YPjAAdSE1kfwMvroXzUQbQxVdqBGjWgPjgdggPYTPuiqvAhauZa8uybcS1ZW/ViqvL4GSic3YS8QSg0caALjiLdCCXSsomh46zWjh+DXVVVQ/NUfOLKR0zAhBx/KVnvB7YXcyvvj1JR6k8kWExTAT4oByp8d2qRyLvYgKBi7n22gM95d4kT5zMy+RRB51M8rMIJA81ckomyK8L+detw5rzzSpc7nx7hLtfWDzdkKcO0539BNynJd+S6qM4bg4/6Xue+8zNsjfiiQ/rRyRfhz/lXFAfb+JkHhse1NfAornyj4wrapE4bbgZb8aWB6QIjv144e5Ili8GKy/j3hC4ysyn2Ro71Vb1dbgy6ALet9NlOxMbrdV9nx+2KNUvhvmAPfD34R+lpSLrBftTDgAAAABJRU5ErkJggg==",
                            Name = "Dây Chuyền",
                            Address = "China",
                            PhoneNumber = 1234567890,
                            Email = "email321@gmail.co",
                            Description = "This is the description"
                        }
                    });

                    context.SaveChanges();
                }
                //Product
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            ImageURL = "https://bizweb.dktcdn.net/thumb/1024x1024/100/386/618/products/hp15-dy2095wm-1.jpg?v=1639622528773",
                            Name = "Nhẫn Thanh Dương",
                            Price = 10000000,
                            Description = "This is the description for ring",
                            ProductCategory = ProductCategory.ring,
                            BrandId = 1
                        },
                        new Product()
                        {
                            ImageURL = "https://maytinhviet.vn/picture/file/tin-tuc-may-tinh/hang-laptop-dell-cua-nuoc-nao.jpg",
                            Name = "Dây Chuyền S925",
                            Price = 9000000,
                            Description = "This is the description for dây chuyền",
                            ProductCategory = ProductCategory.bracelet,
                            BrandId = 2
                        }
                    });

                    context.SaveChanges();
                }
                
            }
        }

        public static async Task SeedUserAndRoleAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "chinhan@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if(adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Chinhan@123");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                
                string appUserEmail = "chinhan@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Chinhan@123");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
