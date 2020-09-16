using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoenniyOkrug.Dao.Entities
{
    class Podrazdelenie : Entity
    {
        public Podrazdelenie(Context.voenniy_okrugEntities context) : base(context)
        {
        }

        public class Parameters
        {
            public string id;
            public string tipPodrazdeleniya;
            public string nazvanie;
            public string idStarshegoPodrazdeleniya;
            public string komandir;
            public string location;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="id"></param>
            /// <param name="nazvanie"></param>
            /// <param name="tipPodrazdeleniya"></param>
            /// <param name="idStarshegoPodrazdeleniya"></param>
            /// <param name="komandir"></param>
            /// <param name="location"></param>
            public Parameters(string id, string nazvanie, string tipPodrazdeleniya, string idStarshegoPodrazdeleniya, string komandir, string location)
            {
                this.id = id;
                this.nazvanie = nazvanie;
                this.tipPodrazdeleniya = tipPodrazdeleniya;
                this.idStarshegoPodrazdeleniya = idStarshegoPodrazdeleniya;
                this.komandir = komandir;
                this.location = location;
            }
        }

        public   string Create(Parameters parameters)
        {
            var podr = new Context.Podrazdelenie();
            podr.id = int.Parse(parameters.id);
            podr.tip = context.Tip_podrazdeleniya.Where(x => (x.nazvanie == parameters.tipPodrazdeleniya)).FirstOrDefault().id;
            podr.nazvanie = parameters.nazvanie;
            context.SaveChanges();
            return "Успешно добавлено";
        }

        public   string Delete(Parameters parameters)
        {
            var podr = context.Podrazdelenie.Where(x => ((parameters.id == string.Empty || parameters.id == x.id.ToString()) &&
                                                                                        (parameters.tipPodrazdeleniya == string.Empty || parameters.tipPodrazdeleniya == x.Tip_podrazdeleniya.nazvanie) &&
                                                                                        (parameters.nazvanie == string.Empty || parameters.nazvanie == x.nazvanie))).FirstOrDefault();
            if (podr == null) return "Такого подразделения не существует";
            context.Podrazdelenie.Remove(podr);

            var podch = context.Podrazdelenie.Where(x => (parameters.id == string.Empty || parameters.id == x.id_starshego.ToString()));
            foreach (var pod_sl in podch) { pod_sl.id_starshego = null; }

            var soor = context.Sooruzhenie.Where(x => (parameters.id == string.Empty || parameters.id == x.podrazdelenie.ToString()));
            foreach (var s in soor) { s.podrazdelenie = null; }

            var bt = context.Boevaya_tehnika.Where(x => (parameters.id == string.Empty || parameters.id == x.podrazdelenie.ToString()));
            foreach (var s in bt) { s.podrazdelenie = null; }


            var tt = context.Transportnaya_tehnika.Where(x => (parameters.id == string.Empty || parameters.id == x.podrazdelenie.ToString()));
            foreach (var s in tt) { s.podrazdelenie = null; }

            context.SaveChanges();
            return "Данные удалены";
        }

        public  string Update(Parameters parameters)
        {
            var obiedinenie = context.Podrazdelenie.Where(x => (x.id.ToString() == parameters.id)).FirstOrDefault();
            if (obiedinenie == null)
            {
                return "Подразделение с таким id уже  существует";
            }

            var tip_id = context.Tip_podrazdeleniya.Where(x => (x.nazvanie == parameters.tipPodrazdeleniya)).FirstOrDefault();
            obiedinenie.tip = tip_id.id;

            obiedinenie.nazvanie = parameters.nazvanie;

            if (parameters.idStarshegoPodrazdeleniya != string.Empty)
            {
                var podr_id_st = context.Podrazdelenie.Where(x => (x.id.ToString() == parameters.idStarshegoPodrazdeleniya)).FirstOrDefault();

                obiedinenie.id_starshego = podr_id_st.id;
            }
            else
            {
                obiedinenie.id_starshego = null;
                obiedinenie.Podrazdelenie1 = null;
            }

            var id_kom = context.Sluzhashchie.Where(x => (x.id.ToString() == parameters.komandir)).FirstOrDefault();
            obiedinenie.komandir = id_kom.id;
            obiedinenie.location = parameters.location;

            context.SaveChanges();
            return "Изменения сохраены";
        }

    }
}
