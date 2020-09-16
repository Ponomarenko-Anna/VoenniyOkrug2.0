using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoenniyOkrug.Dao.CRUD
{/// <summary>
/// Класс,позволяющий создавать любые сущности в базе
/// </summary>
    class Create
    {
        /// <summary>
        /// Хранит ссылку на базу,с которой взаимодействует
        /// </summary>
        private Context.voenniy_okrugEntities context ;
        

    public Create(Context.voenniy_okrugEntities context) {
            this.context = context;
     }

        /// <summary>
        /// Создает новый обьект Служащий в базе
        /// </summary>
        /// <param name="id">Уникальный идентификатор служащего</param>
        /// <param name="imya">Имя служащего</param>
        /// <param name="otchestvo">Отчество служащего</param>
        /// <param name="familiya">Фамилия служащего</param>
        /// <returns></returns>
        public string CreateSluzhashchie(string id, string imya, string otchestvo, string familiya){
            try
            {
                var Sl = new Context.Sluzhashchie();
                Sl.id = int.Parse(id);
                Sl.imya = imya;
                Sl.otchestvo = otchestvo;
                Sl.familiya = familiya;

                context.Sluzhashchie.Add(Sl);
                context.SaveChanges();
                return "Успешно добавлено";
               }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }

        /// <summary>
        /// Создает новое Подразделение(Часть,Рота,Взвод) в базе
        /// </summary>
        /// <param name="id">Уникальный идентификатор подразделения</param>
        /// <param name="tipPodrazdeleniya">Тип подразделения(Часть,Рота,Взвод)</param>
        /// <param name="nazvanie">Газвание подразделения</param>
        /// <returns></returns>
        public string CreatePodrazdelenie(string id, string tipPodrazdeleniya, string nazvanie){
            try
            {
                var podr = new Context.Podrazdelenie();
                podr.id = int.Parse(id);

                podr.Tip_podrazdeleniya = context.Tip_podrazdeleniya.Where(x => (x.nazvanie == tipPodrazdeleniya)).FirstOrDefault();
                podr.tip = podr.Tip_podrazdeleniya.id;
                podr.nazvanie = nazvanie;
                podr.location = "";
                context.Podrazdelenie.Add(podr);

                context.SaveChanges();
                return "Успешно добавлено";
            }
            catch(Exception ex)
            {
                return ex.ToString();

            }
        }


        /// <summary>
        /// Создает новое Обьединение(Дивизия,Корпус,Бригада) в базе
        /// </summary>
        /// <param name="id">Уникальный идентификатор обьединения</param>
        /// <param name="nazvanie">Название обьединения</param>
        /// <param name="tipObiedineniya">Тип обьединения(Дивизия,Корпус,Бригада)</param>
        /// <returns></returns>
        public string CreateObiedinenie(string id, string nazvanie, string tipObiedineniya){
            try
            {
                var ob = new Context.Obiedinenie();
                ob.id = int.Parse(id);
                var tip = context.Tip_obiedineniya.Where(x => (x.nazvanie == tipObiedineniya)).FirstOrDefault();
                ob.Tip_obiedineniya =  tip;
                ob.nazvanie = nazvanie;

                context.Obiedinenie.Add(ob);
                context.SaveChanges();
                return "Успешно добавлено";
            }
            catch(Exception ex)
            {
                return  ex.ToString();
            }
        }


        /// <summary>
        /// Создает новое Сооружение у указанного подразделения в базе
        /// </summary>
        /// <param name="id">Уникальный идентификатор сооружения</param>
        /// <param name="nazvanie">Название сооружения</param>
        /// <param name="podrazdelenieId">Подразделение,к которому прикреплено сооружение</param>
        /// <returns></returns>
        public string CreateSooruzhenie(string id, string nazvanie, string podrazdelenieId){
            try
            {
                var soor = new Context.Sooruzhenie();
                soor.id = int.Parse(id);
                soor.nazvanie = nazvanie;
                soor.podrazdelenie = context.Podrazdelenie.Where(x => (x.id.ToString() == podrazdelenieId)).FirstOrDefault().id;
                context.Sooruzhenie.Add(soor);
                context.SaveChanges();
                return "Успешно добавлено";
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }


        /// <summary>
        /// Создает новую запись  о Боевой технике базе
        /// </summary>
        /// <param name="id">Уникальный идентификатор  записи в журнале</param>
        /// <param name="podrazdelenieId">Подразделение,к которому относится беовая техника</param>
        /// <param name="tipBoevoyTehniki">Тип боевой техники</param>
        /// <returns></returns>
        public string CreateBoevayaTehnika(string id, string podrazdelenieId, string tipBoevoyTehniki){
            try
            {
                var bt = new Context.Boevaya_tehnika();
                bt.id = int.Parse(id);
                bt.Podrazdelenie1 = context.Podrazdelenie.Where(x => (x.id.ToString() == podrazdelenieId)).FirstOrDefault();
                bt.tip = context.Tip_boevoy_tehniki.Where(x => (x.nazvanie == tipBoevoyTehniki)).FirstOrDefault().id;
                context.Boevaya_tehnika.Add(bt);
                context.SaveChanges();
                return "Успешно добавлено";
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }


        /// <summary>
        /// Создает новую запись о Транспортной технике в базе
        /// </summary>
        /// <param name="id">Уникальный идентификатор записи в журнале</param>
        /// <param name="podrazdelenieId">Подразделение,к которому относится транспортная техника</param>
        /// <param name="tipTransportnoyTehniki">Тип транспортной техники</param>
        /// <returns></returns>
        public string CreateTransportnayaTehnika(string id, string podrazdelenieId, string tipTransportnoyTehniki){
            try
            {
                var bt = new Context.Transportnaya_tehnika();
                bt.id = int.Parse(id);
                bt.Podrazdelenie1 = context.Podrazdelenie.Where(x => (x.id.ToString() == podrazdelenieId)).FirstOrDefault();
                bt.tip = context.Tip_transportnoy_tehniki.Where(x => (x.nazvanie == tipTransportnoyTehniki)).FirstOrDefault().id;
                context.Transportnaya_tehnika.Add(bt);
                context.SaveChanges();
                return "Успешно добавлено";
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }

    }
}
