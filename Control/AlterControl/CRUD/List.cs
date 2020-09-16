using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoenniyOkrug.Dao.CRUD
{
    class List
    {/// <summary>
     /// Хранит ссылку на базу,с которой взаимодействует
     /// </summary>
        private Context.voenniy_okrugEntities context;

        public List(Context.voenniy_okrugEntities context_){
            context = context_;
        }

        /// <summary>
        /// Возвращает страницу данных по Транспортной технике из базы, осуществляет поиск по id,названию,подразделению
        /// </summary>
        /// <param name="id">Уникальный идентификатор записи в журнале</param>
        /// <param name="tipTransportnoyTehniki">Название вида транспортной техники</param>
        /// <param name="podrazdelenieId">Подразделение,к которому относится транспортная техника</param>
        /// <param name="fromRow">Номер ряда, с которого передавать данные</param>
        /// <param name="limit">Колличество строк,которые необходимо передать</param>
        /// <returns></returns>
        public List<String[]> GetListTransportnayaTehnika(string id, string tipTransportnoyTehniki, string podrazdelenieId, int fromRow, int limit){

            List<String[]> data = new List<string[]>();
            var transportnaya_technika = context.Transportnaya_tehnika.Where(tt => ((id == "" || id == tt.id.ToString()) && (tipTransportnoyTehniki == "" || tt.Tip_transportnoy_tehniki.nazvanie == tipTransportnoyTehniki) && (podrazdelenieId == "" || podrazdelenieId == tt.podrazdelenie.ToString()))).OrderBy(x => x.id).Skip(fromRow).Take(limit).ToList();

            foreach (var tt in transportnaya_technika)
            {
                var tip_tt = context.Tip_transportnoy_tehniki.Where(x => (x.id == tt.tip)).FirstOrDefault();

                    data.Add(new string[5]);
                    data[data.Count - 1][0] = tt.id.ToString();
                    data[data.Count - 1][1] = tip_tt.nazvanie;
                    data[data.Count - 1][2] = tt.kolichestvo.ToString();
                    data[data.Count - 1][3] = tt.podrazdelenie.ToString();
                    data[data.Count - 1][4] = tt.dop_info;
                
            }

            return data;
        }
        /// <summary>
        /// Возвращает имена колонок для вывода данных о Боевой технике
        /// 
        /// </summary>
        /// <returns></returns>
        public string[] GetDgvFormatTransportnayaTehnika()
        {
            string[] columns = new string[5];

            columns[0] = "Id";
            columns[1] = "Название";
            columns[2] = "Количество";
            columns[3] = "Подразделение";
            columns[4] = "Информация";

            return columns;
        }


        /// <summary>
        /// Возвращает страницу данных по Боевой технике из базы, осуществляет поиск по id,названию,подразделению
        /// </summary>
        /// <param name="id">Уникальный идетификатор записи в журнале</param>
        /// <param name="tipBoevoyTehniki">Название вида боевой техники</param>
        /// <param name="podrazdelenieId">Подразделение,к которому прикреплена боевая техника</param>
        /// <param name="fromRow">Номер ряда, с которого передавать данные</param>
        /// <param name="limit">Колличество строк,которые необходимо передать</param>
        /// <returns></returns>
        public List<String[]> GetListBoevayaTehnika(string id, string tipBoevoyTehniki, string podrazdelenieId, int fromRow, int limit){
            List<String[]> data = new List<string[]>();
            var boevaya_technika = context.Boevaya_tehnika.Where(bt  => ((id == "" || id == bt.id.ToString()) && (tipBoevoyTehniki == "" || bt.Tip_boevoy_tehniki.nazvanie == tipBoevoyTehniki) && (podrazdelenieId == "" || podrazdelenieId == bt.podrazdelenie.ToString()))).OrderBy(x => x.id).Skip(fromRow).Take(limit).ToList();

            foreach (var bt in boevaya_technika)
            {
                var tip_tt = context.Tip_boevoy_tehniki.Where(x => (x.id == bt.tip)).FirstOrDefault();

                    data.Add(new string[5]);
                    data[data.Count - 1][0] = bt.id.ToString();
                    data[data.Count - 1][1] = tip_tt.nazvanie;
                    data[data.Count - 1][2] = bt.kolichestvo.ToString();
                    data[data.Count - 1][3] = bt.podrazdelenie.ToString();
                    data[data.Count - 1][4] = bt.dop_info;
               
            }

            return data;
        }
        /// <summary>
        /// Возвращает имена колонок для вывода данных о Боевой технике
        /// 
        /// </summary>
        /// <returns></returns>
        public string[] GetDgvFormatBoevayaTehnika()
        {
            string[] columns = new string[5];

            columns[0] = "Id";
            columns[1] = "Название";
            columns[2] = "Количество";
            columns[3] = "Подразделение";
            columns[4] = "Информация";

            return columns;
        }


        /// <summary>
        /// Возвращает страницу данных по списку Сооружений из базы, осуществляет поиск по id,названию,подразделению
        /// </summary>
        /// <param name="id">Уникальный идетификатор </param>
        /// <param name="nazvanie">Название сооружения</param>
        /// <param name="podrazdelenieId">Подразделение, к которому относится сооружение</param>
        /// <param name="fromRow">Номер ряда, с которого передавать данные</param>
        /// <param name="limit">Колличество строк,которые необходимо передать</param>
        /// <returns></returns>
        public List<string[]> GetListSooruzhenie(string id, string nazvanie, string podrazdelenieId, int fromRow, int limit){

            List<String[]> data = new List<string[]>();
            var sooruzhenies = context.Sooruzhenie.Where(so => ((id == "" || id == so.id.ToString()) && (nazvanie == "" || nazvanie == so.nazvanie.ToString()) && (podrazdelenieId == "" || podrazdelenieId == so.podrazdelenie.ToString()))).OrderBy(x => x.id).Skip(fromRow).Take(limit).ToList();

            foreach (var so in sooruzhenies)
            {
                    data.Add(new string[3]);
                    data[data.Count - 1][0] = so.id.ToString();
                    data[data.Count - 1][1] = so.nazvanie;
                    data[data.Count - 1][2] = so.podrazdelenie.ToString();

               

            }

            return data;
        }
        /// <summary>
        /// Возвращает имена колонок для вывода данных о Сооружениях
        /// 
        /// </summary>
        /// <returns></returns>
        public string[] GetDgvFormatSooruzhenie()
        {
            string[] columns = new string[3];

            columns[0] = "Id";
            columns[1] = "Название";
            columns[2] = "Подразделение";
            
            return columns;
        }

        /// <summary>
        /// Возвращает страницу данных по списку Обьединений из базы, осуществляет поиск по id,названию,типу обьединения
        /// </summary>
        /// <param name="id">Уникальный идетификатор </param>
        /// <param name="nazvanie">Название обьединения</param>
        /// <param name="tipObiedineniya">Тип обьединения(Дивизия,Бригада,Корпус)</param>
        /// <param name="fromRow">Номер ряда, с которого передавать данные</param>
        /// <param name="limit">Колличество строк,которые необходимо передать</param>
        /// <returns></returns>
        public List<string[]> GetListObiedinenie(string id, string nazvanie, string tipObiedineniya, int fromRow, int limit){

            List<String[]> data = new List<string[]>();

            var obiedinenies = context.Obiedinenie.Where(ob =>((id == "" || id == ob.id.ToString()) && (nazvanie == "" || nazvanie == ob.nazvanie.ToString()) && (tipObiedineniya == "" || tipObiedineniya == ob.Tip_obiedineniya.nazvanie))).OrderBy(x => x.id).Skip(fromRow).Take(limit).ToList();

            foreach (var ob in obiedinenies)
            {
                    data.Add(new string[4]);
                    data[data.Count - 1][0] = ob.id.ToString();
                    data[data.Count - 1][1] = (ob.Tip_obiedineniya == null )? "" : ob.Tip_obiedineniya.nazvanie;
                    data[data.Count - 1][2] = ob.nazvanie;
                    data[data.Count - 1][3] = String.Join(",", ob.Obiedinenie_chast.Select(x => x.chast));

               
            }

            return data;
        }
        /// <summary>
        /// Возвращает имена колонок для вывода данных о Обьединениях
        /// 
        /// </summary>
        /// <returns></returns>
        public string[] GetDgvFormatObiedinenie()
        {
            string[] columns = new string[4];

            columns[0] = "Id";
            columns[1] = "Тип обьединения";
            columns[2] = "Название";
            columns[3] = "Состав";

            return columns;
        }

        /// <summary>
        /// Возвращает страницу данных по списку Подразделений из базы, осуществляет поиск по id,названию,типу подразделения
        /// </summary>
        /// <param name="id">Уникальный идетификатор </param>
        /// <param name="nazvanie">Название подразделения</param>
        /// <param name="tipPodrazdeleniya">Тип подразделения(Взвод,Рота,Часть)</param>
        /// <param name="fromRow">Номер ряда, с которого передавать данные</param>
        /// <param name="limit">Колличество строк,которые необходимо передать</param>
        /// <returns></returns>
        public List<string[]> GetListPodrazdelenie(string id, string nazvanie, string tipPodrazdeleniya, int fromRow, int limit){

            List<String[]> data = new List<string[]>();

            var podrazdelenies = context.Podrazdelenie.Where(podr => ((id == "" || id == podr.id.ToString()) && (nazvanie == "" || nazvanie == podr.nazvanie.ToString()) && (tipPodrazdeleniya == "" || tipPodrazdeleniya == podr.Tip_podrazdeleniya.nazvanie))).OrderBy(x => x.id).Skip(fromRow).Take(limit).ToList();

            foreach (var podr in podrazdelenies)
            {

                data.Add(new string[6]);
                    data[data.Count - 1][0] = podr.id.ToString();
                    data[data.Count - 1][1] = podr.Tip_podrazdeleniya.nazvanie;
                    data[data.Count - 1][2] = podr.nazvanie;
                    data[data.Count - 1][3] = podr.id_starshego.ToString();
                    data[data.Count - 1][4] = (podr.komandir == null) ? "" : (podr.komandir.ToString() + " " + podr.Sluzhashchie.familiya);
                    data[data.Count - 1][5] = podr.location.ToString();

              
            }

            return data;
        }

        /// <summary>
        /// Возвращает имена колонок для вывода данных о Подразделениях
        /// 
        /// </summary>
        /// <returns></returns>
        public string[] GetDgvFormatPodrazdelenie()
        {
            string[] columns = new string[6];

            columns[0] = "Id";
            columns[1] = "Тип подразделения";
            columns[2] = "Название";
            columns[3] = "Старшее подразделение";
            columns[4] = "Командир";
            columns[5] = "Локация";
            
            return columns;
        }


        /// <summary>
        /// Возвращает страницу данных по списку Служащих из базы, осуществляет поиск по id, ФИО
        /// </summary>
        /// <param name="id">Уникальный идентификатор служащего</param>
        /// <param name="imya">Имя служащего</param>
        /// <param name="otchestvo">Отчество служащего</param>
        /// <param name="familiya">Фамилия служащего</param>
        /// <param name="fromRow">Номер ряда, с которого передавать данные</param>
        /// <param name="limit">Колличество строк,которые необходимо передать</param>
        /// <returns></returns>
        public List<string[]> GetListSluzhaschie(string id, string imya, string otchestvo, string familiya, int fromRow, int limit){ 

            List<String[]> data = new List<string[]>();

            var sluzhaschie = context.Sluzhashchie.Where(sl => ((id == "" || id == sl.id.ToString()) && (imya == "" || imya == sl.imya) && (otchestvo == "" || otchestvo == sl.otchestvo) && (familiya == "" || familiya == sl.familiya))).OrderBy(x => x.id).Skip(fromRow).Take(limit);
            
            foreach (var sl in sluzhaschie)
            {
                    data.Add(new string[7]);
                    data[data.Count - 1][0] = sl.id.ToString();
                    data[data.Count - 1][1] = sl.imya;
                    data[data.Count - 1][2] = sl.otchestvo;
                    data[data.Count - 1][3] = sl.familiya;
                    data[data.Count - 1][4] = sl.id_starshego.ToString();
                    data[data.Count - 1][5] = (sl.Starshiy_sostav == null) ? "" : sl.Starshiy_sostav.Starshiy_zvanie.zvanie;
                    data[data.Count - 1][6] = (sl.Mladshiy_sostav == null) ? "" : sl.Mladshiy_sostav.Mladshiy_zvanie.zvanie;
                
            }
            return data;
        }

/// <summary>
/// Возвращает имена колонок для вывода данных Служащие
/// </summary>
/// <returns></returns>
public string[] GetDgvFormatSluzhashie(){
            string[] columns = new string[7];

            columns[0] = "Id";
            columns[1] = "Имя";
            columns[2] = "Отчество";
            columns[3] = "Фамилия";
            columns[4] = "Старший";
            columns[5] = "Звание в старшем составе";
            columns[6] = "Звание в младшем составе";
            
            return columns;
        }


    }
}
