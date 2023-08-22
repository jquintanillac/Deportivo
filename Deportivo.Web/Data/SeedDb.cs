using Deportivo.Common.Enums;
using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using System;

namespace Deportivo.Web.Data
{
	public class SeedDb
	{
		private readonly IUsers _users;
        public DataContext _context;

        public SeedDb(DataContext context, IUsers users)
		{
            _context = context;
            _users = users;
		}

		public async Task SeedAsync()
		{
            await _context.Database.EnsureCreatedAsync();
			await checkRolesAsync();
			await CheckUserAsync("1010", "Juan", "Quintanilla", "juanqcalderon@gmail.com", "995512267", "Urb. buena vista A-26", UserType.Admin);
            await CheckUserAsync("2020", "Andres", "Calderon", "andresqcalderon@gmail.com", "995512267", "Urb. buena vista A-26", UserType.User);
            
        }

        private async Task<User> CheckUserAsync(
                  string document,
                  string firstName,
                  string lastName,
                  string email,
                  string phone,
                  string address,
                  UserType userType
                  )
        {
            User user = await _users.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,                    
                    UserType = userType
                };

                await _users.AddUserAsync(user, "123456");
                await _users.AddUserToRoleAsync(user, userType.ToString());


            }

            return user;
        }

        private async Task checkRolesAsync()
        {
            await _users.CheckRoleAsync(UserType.Admin.ToString());
			await _users.CheckRoleAsync(UserType.User.ToString());
        }
    }
}
