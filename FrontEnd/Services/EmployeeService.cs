using FrontEnd.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace FrontEnd.Services
{
    public class EmployeeService
    {
        public Employee Add(Employee emp,string token)
        {
            Employee empp = null;
            using (var client=new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:18823/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var PostTask = client.PostAsJsonAsync<Employee>("Employee", emp);
                PostTask.Wait();
                var Result = PostTask.Result;
                if (Result.IsSuccessStatusCode)
                {
                    var data = Result.Content.ReadFromJsonAsync<Employee>();
                    data.Wait();
                    empp = data.Result;
                }
            }
            return empp;
        }
        public ICollection<Employee> GetAll(string token)
        {
            using(var client=new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:18823/api/");
                client.DefaultRequestHeaders.Authorization =new  AuthenticationHeaderValue("Bearer", token);
                var Get = client.GetFromJsonAsync<ICollection<Employee>>("Employee");
                Get.Wait();
                if (Get != null)
                {
                    
                    return Get.Result;
                }
            }
            return null;
        }
    }
}
