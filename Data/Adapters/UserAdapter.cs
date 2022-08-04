using PromoAPI.Data.Request;
using PromoAPI.Data.Response;
using PromoAPI.Models;

namespace PromoAPI.Data.Adapters
{
    public class UserAdapter
    {
        public static User UserRequestAdapter(UserRequest userRequest)
        {
            User user = new();
            user.Cpf = userRequest.Cpf;
            user.FullName = userRequest.FullName;
            user.Password=userRequest.Password;
            return user;

        }

        public static UserResponse UserResponseAdapter(User? user)
        {
            UserResponse userResponse = new();
            if (user==null)
            {
                return userResponse;
            }
            userResponse.Id = user.Id;
            userResponse.Cpf = user.Cpf;
            userResponse.FullName = user.FullName;
            return userResponse;

        }
    }
}
