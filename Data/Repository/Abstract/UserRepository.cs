using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PromoAPI.Data.Adapters;
using PromoAPI.Data.Repository.Interface;
using PromoAPI.Data.Request;
using PromoAPI.Data.Response;
using PromoAPI.Models;

namespace PromoAPI.Data.Repository.Abstract
{
    public class UserRepository: IUserRepository
    {
        private readonly ApiDBContext _context;

        public UserRepository(ApiDBContext context)
        {
            _context=context;
        }

        public UserResponse Create(UserRequest userRequest)       
        {
            UserResponse userResponse = new();
            if (cpfExists(userRequest.Cpf))
            {
                userResponse.Message = "CPF já cadastrado!";
                return userResponse;
            }
            else 
            {
                _context.User.Add(UserAdapter.UserRequestAdapter(userRequest));
                _context.SaveChanges();
                // Checar se foi cadastrado na base de dados
                var user = _context.User.FirstOrDefault(u => u.Cpf == userRequest.Cpf && u.Password == userRequest.Password);
               
                userResponse = UserAdapter.UserResponseAdapter(user);
                if (userResponse.Id > 0)
                {
                    userResponse.Message = "Usuário cadastrado com sucesso!";
                }
                else
                {
                    userResponse.Message = "Erro ao cadastrar usuário!";
                }

                return userResponse;
            }
           

           

            /*User? userPesq = await _context.User.FirstOrDefaultAsync(u => u.Cpf == user.Cpf && u.Password == user.Password);
            if (userPesq != null && userPesq.Id>0)
            {
                userPesq.Password = "";
            }
            return userPesq;*/
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public UserResponse login(string cpf, string password)
        {
            UserResponse userResponse = UserAdapter.UserResponseAdapter(_context.User.FirstOrDefault(u => u.Cpf == cpf && u.Password == password));                        
            if (userResponse.Id>0)
            {
                userResponse.Message = "Login efetuado com sucesso";
            }                        
            return userResponse;
        }

        public bool cpfExists(string cpf)
        {
            User? user = _context.User.FirstOrDefault(u => u.Cpf == cpf);

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }
    }
}
