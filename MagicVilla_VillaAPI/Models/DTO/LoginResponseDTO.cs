namespace MagicVilla_VillaAPI.Models.DTO
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public LocalUser User { get; set; }
    }
}
