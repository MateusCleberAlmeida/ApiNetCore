using PromoAPI.Data.Request;
using PromoAPI.Data.Response;
using PromoAPI.Models;

namespace PromoAPI.Data.Repository.Interface
{
    public interface IUserRepository: IDisposable
    {
        UserResponse login(string cpf, string password);
        UserResponse Create(UserRequest userRequest);
        bool cpfExists(string cpf);

    }
}
