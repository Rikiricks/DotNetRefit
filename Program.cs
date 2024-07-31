// See https://aka.ms/new-console-template for more information

//namespace MyProject;
//class Program
//{
//    static void Main(string[] args)
//    {
//        Console.WriteLine("Hello, World!");
//    }
//}


using DotNetRefit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((test, services) => {
        
        services
               .AddRefitClient<IUsersClient>()
               .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/"));
    }).Build();


var usersClient = host.Services.GetRequiredService<IUsersClient>();

var createUser = new User() { Email = "riki@gmail.com", Name = "Riki" };

try
{
    var userAPI = RestService.For<IUsersClient>("https://jsonplaceholder.typicode.com");
    var res = await userAPI.GetUserById(81);

    if (!res.IsSuccessStatusCode)
    {
        throw new Exception(res.Error.Message);
    }

    var response = await usersClient.CreateUser(createUser);

    var users = await usersClient.GetAll();
    foreach (var user in users)
    {
        Console.WriteLine(user);
    }

    var single = await usersClient.GetUser(125);
    Console.WriteLine(single.Name);

    
}
catch(Exception e)
{

}



