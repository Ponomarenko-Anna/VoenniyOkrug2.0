using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoenniyOkrug.Control.RegisterControl
{/// <summary>
/// 
/// </summary>
    class RegisterControl
    {
        private Context.voenniy_okrugEntities context;

        public RegisterControl() {
            context = new Context.voenniy_okrugEntities();
        }

        public bool IsLoginFree(string login) {

            if ((context.Users.Where(x => x.login == login)).Any())
            {
                return false;
            }
            else {
                return true;
            }


        }

        public bool CreateUser(string login, string password) {

                var user = new Context.Users();
                user.login = login;
                user.password = password;
                int maxId = context.Users.Max(x => x.id);
                user.id = maxId + 1;
                context.Users.Add(user);
                context.SaveChanges();
             
            return true;
        }
    }
}
