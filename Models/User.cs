using PromoAPI.Data.Request;

namespace PromoAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }       
    }
}
