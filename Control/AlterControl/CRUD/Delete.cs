using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoenniyOkrug.Dao.CRUD
{/// <summary>
/// Класс,позволяющий удалять,любые сущности из базы
/// </summary>
    class Delete
    { /// <summary>
      /// Хранит ссылку на базу,с которой взаимодействует
      /// </summary>
           private Context.voenniy_okrugEntities context;

        public Delete(Context.voenniy_okrugEntities context_){
            context = context_;
        }

        /// <summary>
        ///Удаляет  обьект Служащий из базы
        /// </summary>
        /// <param name="id">Уникальный идентификатор служащего</param>
        /// <param name="imya">Имя служащего</param>
        /// <param name="otchestvo">Отчество служащего</param>
        /// <param name="familiya">Фамилия служащего</param>
        /// <returns></returns>
        public string DeleteSluzhashchie(string id, string imya, string otchestvo, string familiya){
            try
            { var sl = context.Sluzhashchie.Where(x => ((id == string.Empty || id == x.id.ToString()) && (imya == string.Empty || imya == x.imya) && (otchestvo == string.Empty || otchestvo == x.otchestvo) && (familiya == string.Empty || familiya == x.familiya))).FirstOrDefault();
            if (sl == null) return "Такого служащего не существует";

            var podch = context.Sluzhashchie.Where(x => (id == string.Empty || id == x.id_starshego.ToString()));
            foreach (var pod_sl in podch) { pod_sl.id_starshego = null; }

            context.Sluzhashchie.Remove(sl);
            context.SaveChanges();
            return "Данные удалены";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        /// <summary>
        ///Удаляет  Подразделение(Часть,Рота,Взвод) из базы
        /// </summary>
        /// <param name="id">Уникальный идентификатор подразделения</param>
        /// <param name="tipPodrazdeleniya">Тип подразделения(Часть,Рота,Взвод)</param>
        /// <param name="nazvanie">Газвание подразделения</param>
        /// <returns></returns>
        public string DeletePodrazdelenie(string id, string tipPodrazdeleniya, string nazvanie){
            try
            {
                var podr = context.Podrazdelenie.Where(x => ((id == string.Empty || id == x.id.ToString()) && (tipPodrazdeleniya == string.Empty || tipPodrazdeleniya == x.Tip_podrazdeleniya.nazvanie) && (nazvanie == string.Empty || nazvanie == x.nazvanie))).FirstOrDefault();
                if (podr == null) return "Такого подразделения не существует";
                context.Podrazdelenie.Remove(podr);

                var podch = context.Podrazdelenie.Where(x => (id == string.Empty || id == x.id_starshego.ToString()));
                foreach (var pod_sl in podch) { pod_sl.id_starshego = null; }

                var soor = context.Sooruzhenie.Where(x => (id == string.Empty || id == x.podrazdelenie.ToString()));
                foreach (var s in soor) { s.podrazdelenie = null; }

                var bt = context.Boevaya_tehnika.Where(x => (id == string.Empty || id == x.podrazdelenie.ToString()));
                foreach (var s in bt) { s.podrazdelenie = null; }


                var tt = context.Transportnaya_tehnika.Where(x => (id == string.Empty || id == x.podrazdelenie.ToString()));
                foreach (var s in tt) { s.podrazdelenie = null; }

                context.SaveChanges();
                return "Данные удалены";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        /// <summary>
        /// Удаляет Обьединение(Дивизия,Корпус,Бригада) из базы
        /// </summary>
        /// <param name="id">Уникальный идентификатор обьединения</param>
        /// <param name="tipObiedineniya">Тип обьединения(Дивизия,Корпус,Бригада)</param>
        /// <param name="nazvanie">Название обьединения</param>
        /// <returns></returns>
        public string DeleteObiedinenie(string id, string tipObiedineniya, string nazvanie){
            try { 
            var ob = context.Obiedinenie.Where(x => ((id == string.Empty || id == x.id.ToString()) && (tipObiedineniya == string.Empty || tipObiedineniya == x.Tip_obiedineniya.nazvanie) && (nazvanie == string.Empty || nazvanie == x.nazvanie))).FirstOrDefault();
            if (ob == null) return "Такого обьединения  не существует";
            context.Obiedinenie.Remove(ob);
            context.SaveChanges();
            return "Данные удалены";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        /// <summary>
        /// Удаляет Сооружение у указанного подразделения из базы
        /// </summary>
        /// <param name="id">Уникальный идентификатор сооружения</param>
        /// <param name="nazvanie">Название сооружения</param>
        /// <param name="podrazdelenieId">Подразделение,к которому прикреплено сооружение</param>
        /// <returns></returns>
        public string DeleteSooruzhenie(string id, string nazvanie, string podrazdelenieId){
            try
            { var soor = context.Sooruzhenie.Where(x => ((id == string.Empty || id == x.id.ToString()) && (nazvanie == string.Empty || nazvanie == x.nazvanie.ToString()) && (podrazdelenieId == string.Empty || podrazdelenieId == x.podrazdelenie.ToString()))).FirstOrDefault();
            if (soor == null) return "Такого сооружения не существует";
            context.Sooruzhenie.Remove(soor);
            context.SaveChanges();
            return "Данные удалены";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        /// <summary>
        /// Удаляет запись  о Боевой технике из базы
        /// </summary>
        /// <param name="id">Уникальный идентификатор  записи в журнале</param>
        /// <param name="tipBoevoyTehniki">Тип боевой техники</param>
        /// <param name="kolichestvo">Количество едениц боевой техники</param>
        /// <param name="podrazdelenieId">Подразделение,к которому относится беовая техника</param>
        /// <returns></returns>
        public string DeleteBoevayaTehnika(string id, string tipBoevoyTehniki, string kolichestvo, string podrazdelenieId){
            try
            {
                var bt = context.Boevaya_tehnika.Where(x => ((id == string.Empty || id == x.id.ToString()) && (tipBoevoyTehniki == string.Empty || tipBoevoyTehniki == x.Tip_boevoy_tehniki.nazvanie) && (kolichestvo == string.Empty || kolichestvo == x.kolichestvo.ToString()) && (podrazdelenieId == string.Empty || podrazdelenieId == x.podrazdelenie.ToString()))).FirstOrDefault();
                if (bt == null) return "Такой записи не существует";
                context.Boevaya_tehnika.Remove(bt);
                context.SaveChanges();
                return "Данные удалены";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
}


        /// <summary>
        /// Создает новую запись о Транспортной технике в базе
        /// </summary>
        /// <param name="id">Уникальный идентификатор записи в журнале</param>
        /// <param name="tipTransportnoyTehniki">Тип транспортной техники</param>
        /// <param name="kolichestvo">Количество едениц транспортной техники</param>
        /// <param name="podrazdelenieId">Подразделение,к которому относится транспортная техника</param>
        /// <returns></returns>
        public string DeleteTransportnayaTehnika(string id, string tipTransportnoyTehniki, string kolichestvo, string podrazdelenieId){
            try
            {
                var tt = context.Transportnaya_tehnika.Where(x => ((id == string.Empty || id == x.id.ToString()) && (tipTransportnoyTehniki == string.Empty || tipTransportnoyTehniki == x.Tip_transportnoy_tehniki.nazvanie) && (kolichestvo == string.Empty || kolichestvo == x.kolichestvo.ToString()) && (podrazdelenieId == string.Empty || podrazdelenieId == x.podrazdelenie.ToString()))).FirstOrDefault();
                if (tt == null) return "Такой записи не существует";
                context.Transportnaya_tehnika.Remove(tt);
                context.SaveChanges();
                return "Данные удалены";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

    }
}
