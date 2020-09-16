using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoenniyOkrug.Dao.Entities
{
    class Obiedinenie : Entity
    {
        public Obiedinenie(Context.voenniy_okrugEntities context) : base(context)
        {
        }

        public class Parameters
        {
           public  string id;
           public  string nazvanie;
           public  string tipObiedineniya;
           public List<string> sostav;

           /// <summary>
           /// 
           /// </summary>
           /// <param name="id"></param>
           /// <param name="nazvanie"></param>
           /// <param name="tipObiedineniya"></param>
           /// <param name="sostav"></param>
           public Parameters(string id, string nazvanie, string tipObiedineniya, List<string> sostav)
            {
                this.id = id;
                this.nazvanie = nazvanie;
                this.tipObiedineniya = tipObiedineniya;
                this.sostav = sostav;
            }
        }

        public  string Create(Parameters parameters)
        {
            var ob = new Context.Obiedinenie();
            ob.id = int.Parse(parameters.id);
            var tip_ = context.Tip_obiedineniya.Where(x => (x.nazvanie == parameters.tipObiedineniya)).FirstOrDefault();
            ob.tip = (tip_ == null) ? 0 : tip_.id;
            ob.nazvanie = parameters.nazvanie;

            context.Obiedinenie.Add(ob);
            context.SaveChanges();
            return "Успешно добавлено";
        }

        public   string Delete(Parameters parameters)
        {
            var ob = context.Obiedinenie.Where(x => ((parameters.id == string.Empty || parameters.id == x.id.ToString()) && 
                                                                      (parameters.tipObiedineniya == string.Empty || parameters.tipObiedineniya == x.Tip_obiedineniya.nazvanie) &&
                                                                      (parameters.nazvanie == string.Empty || parameters.nazvanie == x.nazvanie))).FirstOrDefault();
            if (ob == null) return "Такого обьединения  не существует";
            context.Obiedinenie.Remove(ob);
            context.SaveChanges();
            return "Данные удалены";
        }

        public   string Update(Parameters parameters)
        {

            var obiedinenie = context.Obiedinenie.Where(x => (x.id.ToString() == parameters.id)).FirstOrDefault();


            var tip_id = context.Tip_obiedineniya.Where(x => (x.nazvanie == parameters.tipObiedineniya)).FirstOrDefault();
            obiedinenie.tip = tip_id.id;

            obiedinenie.nazvanie = parameters.nazvanie;

            var ob_ch = context.Obiedinenie_chast.Where(x => (x.obiedinenie.ToString() == parameters.id));
            foreach (var o_c in ob_ch)
            {
                if (!parameters.sostav.Contains(o_c.chast.ToString()))
                {
                    context.Obiedinenie_chast.Remove(o_c);
                    parameters.sostav.Remove(o_c.chast.ToString());
                }
            }
            foreach (var chast in parameters.sostav)
            {
                var o_c = new Context.Obiedinenie_chast();
                o_c.id = context.Obiedinenie_chast.Max(x => x.id) + 1;
                o_c.obiedinenie = obiedinenie.id;
                o_c.chast = int.Parse(chast.ToString());
            }

            context.SaveChanges();
            return "Изменения сохраены";
        }
    }
}
