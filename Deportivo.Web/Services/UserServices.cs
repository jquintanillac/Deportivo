using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using Deportivo.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace Deportivo.Web.Services
{
	public class UserServices : IUsers
	{
		private readonly UserManager<User> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _singInManager;

        public UserServices(
			UserManager<User> userManager, 
			RoleManager<IdentityRole> roleManager,
			SignInManager<User> singInManager) 
		{ 
			_userManager = userManager;
			_roleManager = roleManager;
            _singInManager = singInManager;
        }
		public async Task<IdentityResult> AddUserAsync(User user, string password)
		{
			return await _userManager.CreateAsync(user, password);
		}

		public async Task AddUserToRoleAsync(User user, string roleName)
		{
			await _userManager.AddToRoleAsync(user, roleName);
		}

		public async Task CheckRoleAsync(string roleName)
		{
			var roleExists = await _roleManager.RoleExistsAsync(roleName);
			if(!roleExists)
			{
				await _roleManager.CreateAsync(new IdentityRole
				{
					Name = roleName
				});
			}
		}

		public async Task<User> GetUserByEmailAsync(string email)
		{
			return await _userManager.FindByEmailAsync(email);
		}

		public async Task<bool> IsUserInRoleAsync(User user, string roleName)
		{
			return await _userManager.IsInRoleAsync(user, roleName);
		}

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
			try
			{
                return await _singInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                model.RememberMe,
                false);
            }
			catch (Exception ex)
			{

				throw ex;
			}
            
        }

        public async Task LogoutAsync()
        {
            await _singInManager.SignOutAsync();
        }
    }
}
