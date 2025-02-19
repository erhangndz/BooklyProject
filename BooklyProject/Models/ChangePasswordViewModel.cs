using System.ComponentModel.DataAnnotations;

namespace BooklyProject.Models
{
	public class ChangePasswordViewModel
	{
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }

        [Compare("NewPassword",ErrorMessage ="Şifreler birbiri ile eşleşmiyor")]
        public string ConfirmPassword { get; set; }

    }
}