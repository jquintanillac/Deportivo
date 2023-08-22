using Deportivo.Web.Data.Entities;
using Deportivo.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace Deportivo.Web.IServices
{
	public interface IUsers
	{
		Task<User> GetUserByEmailAsync(string email);
		Task<IdentityResult> AddUserAsync(User user, string password);
		Task CheckRoleAsync(string roleName);
		Task AddUserToRoleAsync(User user, string roleName);
		Task<bool> IsUserInRoleAsync(User user, string roleName);
        Task<SignInResult> LoginAsync(LoginViewModel model);
        Task LogoutAsync();
    }
}
