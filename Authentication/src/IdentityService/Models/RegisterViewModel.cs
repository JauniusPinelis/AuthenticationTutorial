using System.ComponentModel.DataAnnotations;

namespace IdentityService.Models
{
	public class RegisterViewModel
	{
		[Required]
		public string Username { get; set; }
		
		[DataType(DataType.Password)]
		[Required]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Required]
		[Compare("Password")]
		public string ConfirmPassword { get; set; }
		public string ReturnUrl { get; set; }
	}
}