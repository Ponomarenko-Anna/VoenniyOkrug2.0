using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoenniyOkrug.Dao.CRUD
{/// <summary>
/// Класс, позволяющий обновлять все сущности в базе
/// </summary>
    class Update
    {
        /// <summary>
        /// Хранит ссылку на базу,с которой взаимодействует
        /// </summary>
        private Context.voenniy_okrugEntities context ;

        public Update(Context.voenniy_okrugEntities context_)
        {
            context = context_;
        }

        /// <summary>
        ///Обновляет информацию о Служащем в базе
        /// </summary>
        /// <param name="id">Уникальный идентификатор служащего</param>
        /// <param name="imya">Имя служащего</param>
        /// <param name="otchestvo">Отчество служащего</param>
        /// <param name="familiya">Фамилия служащего</param>
        /// <param name="idStarshego">Уникальный идентификатор старшего над служащим</param>
        /// <param name="mladshiyZvanie">Звание младшего состава(если есть)</param>
        /// <param name="starshiyZvanie">Звание старшего состава(если есть)</param>
        /// <returns></returns>
        public string UpdateSluzhaschie(string id, string imya, string otchestvo, string familiya, string idStarshego, string mladshiyZvanie, string starshiyZvanie)
        {
            try
            {
                var sluzhaschiy = context.Sluzhashchie.Where(x => (x.id.ToString() == id)).FirstOrDefault();
                if (sluzhaschiy == null)
                {
                    return "Служащий с таким id уже существует ";
                }

                sluzhaschiy.imya = imya;
                sluzhaschiy.otchestvo = otchestvo;
                sluzhaschiy.familiya = familiya;

                if (idStarshego != string.Empty)
                {
                    var id_st = context.Sluzhashchie.Where(x => (x.id.ToString() == idStarshego)).FirstOrDefault();
                    sluzhaschiy.Sluzhashchie2= id_st;
                    sluzhaschiy.id_starshego = id_st.id;
                }
                else
                {
                    sluzhaschiy.Sluzhashchie2 = null;
                }

                if ((mladshiyZvanie != string.Empty) && (starshiyZvanie == string.Empty))
                {
                    var ms_sluzhaschiy = this.context.Mladshiy_sostav.Where(x => (x.id.ToString() == id)).FirstOrDefault();
                    var zvanie = this.context.Mladshiy_zvanie.Where(x => (x.zvanie == mladshiyZvanie)).FirstOrDefault();
                    ms_sluzhaschiy.zvanie = zvanie.id;
                }

                if ((mladshiyZvanie == string.Empty) && (starshiyZvanie != string.Empty))
                {
                    var ss_sluzhaschiy = context.Starshiy_sostav.Where(x => (x.id.ToString() == id)).FirstOrDefault();
                    var zvanie = context.Starshiy_zvanie.Where(x => (x.zvanie == mladshiyZvanie)).FirstOrDefault();
                    ss_sluzhaschiy.zvanie = zvanie.id;
                }

                context.SaveChanges();
                return "Изменения сохраены";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        /// <summary>
        /// Обновляет информацию о Подразделении в базе
        /// /// </summary>
        /// <param name="id">Уникальный идетификатор </param>
        /// <param name="nazvanie">Название подразделения</param>
        /// <param name="tipPodrazdeleniya">Тип подразделения(Взвод,Рота,Часть)</param>
        /// <param name="idStarshegoPodrazdeleniya">Уникальный идентификатор главенствующего подразделения</param>
        /// <param name="komandirId">Уникальный идентификатор служащего-командира в подразделении</param>
        /// <param name="location">Месторасположение подразделения</param>
        /// <returns></returns>
        public string UpdatePodrazdelenie(string id, string tipPodrazdeleniya, string nazvanie, string idStarshegoPodrazdeleniya, string komandirId, string location)
        {
            try
            { 
            var obiedinenie = context.Podrazdelenie.Where(x => (x.id.ToString() == id)).FirstOrDefault();
                if (obiedinenie == null)
                {
                    return "Подразделение с таким id уже  существует";
                }

            var tip_id = context.Tip_podrazdeleniya.Where(x => (x.nazvanie == tipPodrazdeleniya)).FirstOrDefault();
            obiedinenie.tip = tip_id.id;

            obiedinenie.nazvanie = nazvanie;

            if (idStarshegoPodrazdeleniya != string.Empty)
            {
                var podr_id_st = context.Podrazdelenie.Where(x => (x.id.ToString() == idStarshegoPodrazdeleniya)).FirstOrDefault();

                obiedinenie.id_starshego = podr_id_st.id;
            }
            else
            {
                obiedinenie.id_starshego = null;
                obiedinenie.Podrazdelenie1 = null;
            }

            var id_kom = context.Sluzhashchie.Where(x => (x.id.ToString() == komandirId)).FirstOrDefault();
            obiedinenie.komandir = id_kom.id;
            obiedinenie.location = location;

            context.SaveChanges();
                return "Изменения сохраены";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        /// <summary>
        /// Обновляет информацию о Обьединении в базе
        /// </summary>
        /// <param name="id">Уникальный идетификатор </param>
        /// <param name="nazvanie">Название обьединения</param>
        /// <param name="tipObiedineniya">Тип обьединения(Дивизия,Бригада,Корпус)</param>
        /// <param name="sostav">Уникальные идентификаторы  частей,входящие в состав обьединения</param>
        /// <returns></returns>
        public string UpdateObiedinenie(string id, string tipObiedineniya, string nazvanie, List<string> sostav)
        {
            try
            { 
            var obiedinenie = context.Obiedinenie.Where(x => (x.id.ToString() == id)).FirstOrDefault();


            var tip_id = context.Tip_obiedineniya.Where(x => (x.nazvanie == tipObiedineniya)).FirstOrDefault();
            obiedinenie.tip = tip_id.id;

            obiedinenie.nazvanie = nazvanie;

            var ob_ch = context.Obiedinenie_chast.Where(x => (x.obiedinenie.ToString() == id));
            foreach (var o_c in ob_ch)
            {
                if (!sostav.Contains(o_c.chast.ToString()))
                {
                    context.Obiedinenie_chast.Remove(o_c);
                    sostav.Remove(o_c.chast.ToString());
                }
            }
            foreach (var chast in sostav)
            {
                var o_c = new Context.Obiedinenie_chast();
                o_c.id = context.Obiedinenie_chast.Max(x => x.id) + 1;
                o_c.obiedinenie = obiedinenie.id;
                o_c.chast = int.Parse(chast.ToString());
            }

            context.SaveChanges();
                return "Изменения сохраены";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        /// <summary>
        /// Обновляет информацию о Сооружении в базе
        /// </summary>
        /// <param name="id">Уникальный идетификатор </param>
        /// <param name="nazvanie">Название сооружения</param>
        /// <param name="podrazdelenieId">Подразделение, к которому относится сооружение</param>
        /// <returns></returns>
        public string UpdateSooruzhenie(string id, string nazvanie, string podrazdelenieId)
        {
            try
            { 
            var context = new Context.voenniy_okrugEntities();
            var sooruzhenie = context.Sooruzhenie.Where(x => (x.id.ToString() == id)).FirstOrDefault();
                if (sooruzhenie == null)
                {
                    return "Соружение с таким id уже существует";
                }

            sooruzhenie.nazvanie = nazvanie;

            var podr = context.Podrazdelenie.Where(x => (x.id.ToString() == podrazdelenieId)).FirstOrDefault();
            sooruzhenie.podrazdelenie = podr.id;

            context.SaveChanges();
                return "Изменения сохраены";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        /// <summary>
        /// Обновляет запись о Боевой технике в базе
        /// </summary>
        /// <param name="id">Уникальный идетификатор записи в журнале</param>
        /// <param name="tipBoevoyTehniki">Название вида боевой техники</param>
        /// <param name="podrazdelenieId">Подразделение,к которому прикреплена боевая техника</param>
        /// <param name="kolichestvo">Количество едениц боевой техники</param>
        /// <returns></returns>
        public string UpdateBoevayaTehnika(string id, string tipBoevoyTehniki, string kolichestvo, string podrazdelenieId)
        {
            try
            { 
            var boevaya_tehnika = context.Boevaya_tehnika.Where(x => (x.id.ToString() == id)).FirstOrDefault();
                if (boevaya_tehnika == null)
                {
                    return "Такой id уже есть";
                }

            var tip = context.Tip_boevoy_tehniki.Where(x => (x.nazvanie == tipBoevoyTehniki)).FirstOrDefault();
            boevaya_tehnika.podrazdelenie = tip.id;

            boevaya_tehnika.kolichestvo = int.Parse(kolichestvo);

            var podr = context.Podrazdelenie.Where(x => (x.id.ToString() == podrazdelenieId)).FirstOrDefault();
            boevaya_tehnika.podrazdelenie = podr.id;

            context.SaveChanges();
                return "Изменения сохраены";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }


        /// <summary>
        /// Обновляет запись о Транспортной технике в базе
        /// </summary>
        /// <param name="id">Уникальный идентификатор записи в журнале</param>
        /// <param name="tipTransportnoyTehniki">Название вида транспортной техники</param>
        /// <param name="podrazdelenieId">Подразделение,к которому относится транспортная техника</param>
        /// <param name="kolichestvo">Количество едениц транспортной техники</param>
        /// <returns></returns>
        public string UpdateTransportnayaTehnika(string id, string tipTransportnoyTehniki, string kolichestvo, string podrazdelenieId)
        {
            try
            { 
            var transportnaya_tehnika = context.Transportnaya_tehnika.Where(x => (x.id.ToString() == id)).FirstOrDefault();
                if (transportnaya_tehnika == null)
                {
                    return "Такой id уже есть";
                }

            var tip = context.Tip_transportnoy_tehniki.Where(x => (x.nazvanie == tipTransportnoyTehniki)).FirstOrDefault();
            transportnaya_tehnika.podrazdelenie = tip.id;

            transportnaya_tehnika.kolichestvo = int.Parse(kolichestvo);

            var podr = context.Podrazdelenie.Where(x => (x.id.ToString() == podrazdelenieId)).FirstOrDefault();
            transportnaya_tehnika.podrazdelenie = podr.id;

            context.SaveChanges();
                return "Изменения сохраены";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

    }
}
