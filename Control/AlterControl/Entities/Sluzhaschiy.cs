using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoenniyOkrug.Dao.Entities
{
    class Sluzhaschiy : Entity
    {
        public Sluzhaschiy(Context.voenniy_okrugEntities context) 
            : base(context)
        {              
        }

        public class Parameters
        {
            public string id;
            public string imya;
            public string otchestvo;
            public string familiya;
            public string idStarshego;
            public string mladshiyZvanie;
            public string starshiyZvanie;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="id"></param>
            /// <param name="imya"></param>
            /// <param name="otchestvo"></param>
            /// <param name="familiya"></param>
            /// <param name="idStarshego"></param>
            /// <param name="mladshiyZvanie"></param>
            /// <param name="starshiyZvanie"></param>
            public Parameters(string id  ,string imya, string otchestvo, string familiya, string idStarshego, string mladshiyZvanie, string starshiyZvanie)
            {
                this.id = id;
                this.imya = imya;
                this.otchestvo = otchestvo;
                this.familiya = familiya;
                this.idStarshego = otchestvo;
                this.mladshiyZvanie = mladshiyZvanie;
                this.starshiyZvanie = starshiyZvanie;
        }
    }

        public   string Create(Parameters parameters)
        {
            var Sl = new Context.Sluzhashchie();
            Sl.id = int.Parse(parameters.id);
            Sl.imya = parameters.imya;
            Sl.otchestvo = parameters.otchestvo;
            Sl.familiya = parameters.familiya;

            base.context.Sluzhashchie.Add(Sl);
            base.context.SaveChanges();
            return "Успешно добавлено";
        }
        public  string Delete(Parameters parameters)
        {
            var sl = context.Sluzhashchie.Where(x => ((parameters.id == string.Empty || parameters.id == x.id.ToString()) && 
                                                                                (parameters.imya == string.Empty || parameters.imya == x.imya) &&
                                                                                (parameters.otchestvo == string.Empty || parameters.otchestvo == x.otchestvo) &&
                                                                                (parameters.familiya == string.Empty || parameters.familiya == x.familiya))).FirstOrDefault();
            if (sl == null) return "Такого служащего не существует";

            var podch = context.Sluzhashchie.Where(x => (parameters.id == string.Empty || parameters.id == x.id_starshego.ToString()));
            foreach (var pod_sl in podch) { pod_sl.id_starshego = null; }

            context.Sluzhashchie.Remove(sl);
            context.SaveChanges();
            return "Данные удалены";
        }

        public  string Update(Parameters parameters)
        {

            var sluzhaschiy = context.Sluzhashchie.Where(x => (x.id.ToString() == parameters.id)).FirstOrDefault();
            if (sluzhaschiy == null)
            {
                return "Служащий с таким id уже существует ";
            }

            sluzhaschiy.imya = parameters.imya;
            sluzhaschiy.otchestvo = parameters.otchestvo;
            sluzhaschiy.familiya = parameters.familiya;

            if (parameters.idStarshego != string.Empty)
            {
                var id_st = context.Sluzhashchie.Where(x => (x.id.ToString() == parameters.idStarshego)).FirstOrDefault();
                sluzhaschiy.id_starshego = id_st.id;
            }
            else
            {
                sluzhaschiy.id_starshego = null;
            }

            if ((parameters.mladshiyZvanie != string.Empty) && (parameters.starshiyZvanie == string.Empty))
            {
                var ms_sluzhaschiy = context.Mladshiy_sostav.Where(x => (x.id.ToString() == parameters.id)).FirstOrDefault();
                var zvanie = context.Mladshiy_zvanie.Where(x => (x.zvanie == parameters.mladshiyZvanie)).FirstOrDefault();
                ms_sluzhaschiy.zvanie = zvanie.id;
            }
            if ((parameters.mladshiyZvanie == string.Empty) && (parameters.starshiyZvanie != string.Empty))
            {
                var ss_sluzhaschiy = context.Starshiy_sostav.Where(x => (x.id.ToString() == parameters.id)).FirstOrDefault();
                var zvanie = context.Starshiy_zvanie.Where(x => (x.zvanie == parameters.mladshiyZvanie)).FirstOrDefault();
                ss_sluzhaschiy.zvanie = zvanie.id;
            }

            context.SaveChanges();
            return "Изменения сохраены";
        }

    }
}
