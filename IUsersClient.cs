using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetRefit
{
    [Headers("X-Header-Name: HeaderContent")]
    public interface IUsersClient
    {
        [Headers("X-Header-Name: HeaderContent")]
        [Get("/users")]
        Task<IEnumerable<User>> GetAll();

        [Get("/users/{id}")]
        Task<User> GetUser(int id);

        [Get("/users/{id}")]
        Task<ApiResponse<GenericResponse<User>>> GetUserById(int id);

        [Get("/users/{id}")]
        Task<User> GetUserByUserId([AliasAs("id")] int userId);

        [Post("/users")]
        Task<User> CreateUser([Body] User user);

        [Put("/users/{id}")]
        Task<User> UpdateUser(int id, [Body] User user);

        [Delete("/users/{id}")]
        Task DeleteUser(int id);

        [Get("/users")]
        Task<List<User>> GetUsers([Header("Authorization")] string bearerToken);


    }
}
