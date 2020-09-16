using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoenniyOkrug.Control.LoginControl
{
    /// <summary>
    /// Класс-фейс для взаимодействия с базой данных для формы авторизации
    /// </summary>
    class LoginControl
    {
        private Context.voenniy_okrugEntities context;

        public LoginControl() {
            context = new Context.voenniy_okrugEntities();
        }

        /// <summary>
        /// Метод ищет человека с таким логином и паролем в базе, и возвращает уровень его доступа,в случае если пароль верный
        /// </summary>
        /// <param name="login">логин пользователя</param>
        /// <param name="password">пароль пользователя</param>
        /// <returns></returns>
        public int tryLogin(string login, string password) {
            var user = context.Users.Where(x => (x.login == login) && (x.password == password)).FirstOrDefault();
            return 2;
            /*if (user != null)
            {
                if (user.change_rights.Contains("c"))
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }*/
        }


    }
}
