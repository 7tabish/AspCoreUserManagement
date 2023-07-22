using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using User.Management.API.Models.Authentication.Signup;

namespace User.Management.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IConfiguration _configuration;

		public AuthenticationController(UserManager<IdentityUser> userManager,
			RoleManager<IdentityRole> roleManager, IConfiguration configuration
			)
		{

			_userManager = userManager;
			_roleManager = roleManager;
			_configuration = configuration;
		}


		[HttpPost]
		public async Task<IActionResult> Register([FromBody] RegisterUser registerUser, string role)
		{
			var userExist = await _userManager.FindByEmailAsync(registerUser.Email);

			//check user existance in DB
			if (userExist!=null)
			{
				return StatusCode(StatusCodes.Status403Forbidden,
					new Response {Status="Error", Message="User already exists" }
					);
			}

			//create Identity user in DB
			IdentityUser user = new()
			{
				Email = registerUser.Email,
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = registerUser.Username
			};

			if (await _roleManager.RoleExistsAsync(role))
			{
				var result = await _userManager.CreateAsync(user, registerUser.Password);

				if (result.Succeeded)
				{

					//add role
					await _userManager.AddToRoleAsync(user,role);
					return StatusCode(StatusCodes.Status201Created,
						new Response { Status = "Success", Message = "User created successfully" }
						);

				}

				else if (result.Errors.Count() > 0)
				{
					var errorDescription = result.Errors.Select(e => e.Description).ToList();
					return StatusCode(StatusCodes.Status400BadRequest,
						new Response
						{
							Status = "Error",
							Message = string.Join(", ", errorDescription)
						}
						);
				}
				else
				{
					return StatusCode(StatusCodes.Status400BadRequest,
						new Response { Status = "Error", Message = "Error while creating user" }
						);
				}
			}//end role exists
			else
			{
				return StatusCode(StatusCodes.Status400BadRequest,
					new Response { Status = "Error", Message = "Role not exist" }
					);
			}




		}

	}

}
