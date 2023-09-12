using System.ComponentModel.DataAnnotations;

namespace OkraFurnitureUI.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen Email Adresinizi Giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen Parolanızı Giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen Parolanızı Tekrar Giriniz")]
        [Compare("Password", ErrorMessage = "Lütfen Aynı Şifreyi Girdiğinizden Emin Olun")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Lütfen Şirket Kodunuzu Giriniz")]
        [Compare("ConfirmCode", ErrorMessage = "Doğru Kod Girdiğinize Emin Olunuz")]
        public string Code { get; set; }

        public string ConfirmCode { get; } = "Bamyacı2013";
    }
}
