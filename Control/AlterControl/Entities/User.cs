using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoenniyOkrug.Dao.Entities
{
    class User : Entity
    {
        public User(Context.voenniy_okrugEntities context) : base(context)
        {
        }

        public class Parameters
        {
            public string id { get;  set; }
            public string login { get; set; }
            public string password { get; set; }
            public string changeRights { get; set; }

            /// <summary>
            /// Нетривиальный конструктор для передачи параметров элемента пользователь
            /// </summary>
            /// <param name="id"></param>
            /// <param name="login"></param>
            /// <param name="password"></param>
            /// <param name="changeRights"></param>
            public Parameters(string id, string login, string password, string changeRights) {
                this.id = id;
                this.login = login;
                this.password = password;
                this.changeRights = changeRights;
            }
        }

        public string Create(Parameters parameters)
        {
            var user = new Context.Users();
            user.id = int.Parse(parameters.id);
            user.login = parameters.login;
            user.password = parameters.password;

            context.Users.Add(user);
            context.SaveChanges();
            return "Успешно добавлено";
        }

        public string Delete(Parameters parameters)
        {
            var user = context.Users.Where(x => ((parameters.id == string.Empty || parameters.id == x.id.ToString()) &&
                                                                      (parameters.login == string.Empty || parameters.login == x.login))).FirstOrDefault();
            if (user == null)
            {
                return "Таикого пользователя  не существует";
            }
            context.Users.Remove(user);
            context.SaveChanges();
            return "Данные удалены";
        }

        public string Update(Parameters parameters)
        {

            var user = context.Users.Where(x => (parameters.id == string.Empty || parameters.id == x.id.ToString())).FirstOrDefault();
            if (user == null)
            {
                return "Таикого пользователя  не существует";
            }
            user.login = parameters.login;
            user.password = parameters.password;
            user.change_rights = parameters.changeRights;

            context.SaveChanges();
            return "Изменения сохраены";
        }
    }
}
