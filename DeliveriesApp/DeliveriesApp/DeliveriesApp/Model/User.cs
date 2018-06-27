using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveriesApp.Model
{
    class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public static async Task<bool> Login(string email, string password)
        {
            bool result = false;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                result = false;
            }
            else
            {
                //First() generates an exception if user doesnt exist, FirtOrDefault return null if user doesn't exist
                var user = (await AzureHelper.MobileService.GetTable<User>().Where(u => u.Email == email).ToListAsync()).FirstOrDefault();
                if (user != null)
                {
                    if (user.Password == password)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else
                {
                    result = false;
                }

            }

            return result;

        }

        public static async Task<bool> Register(string email, string password, string confirmPassword)
        {
            bool result = false;

            if (password == confirmPassword)
            {
                var user = new User()
                {
                    Email = email,
                    Password = password
                };

                await AzureHelper.MobileService.GetTable<User>().InsertAsync(user);
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
    }
}
