using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FrontEnd
{
    public class UserService
    {
        public UserService()
        {
           
        }
        public Users Login(Users users)
        {
            Users user = null;
            using (var client=new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:18823/api/");
                var PostTask=client.PostAsJsonAsync<Users>("User/Login", users);
                PostTask.Wait();
                var Result = PostTask.Result;
                if (Result.IsSuccessStatusCode)
                    {
                        var data = Result.Content.ReadFromJsonAsync<Users>();
                        data.Wait();
                        user = data.Result;
                         Console.WriteLine(user.JWTToken);
                    }
            }
            return user;
        }
    }
}
