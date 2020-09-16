using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoenniyOkrug.Dao
{
    /// <summary>
    ///Интерфейс доступа к базе данных 
    /// </summary>
    class DataProvider
    {
        private Context.voenniy_okrugEntities context;
        private CRUD.List list;
        private CRUD.Update update;
        private CRUD.Create create;
        private CRUD.Delete delete;

        public DataProvider() {
            this.context = new Context.voenniy_okrugEntities();
            list = new CRUD.List(context);
            update = new CRUD.Update(context);
            create = new CRUD.Create(context);
            delete = new CRUD.Delete(context);

    }
    /// <summary>
    /// Возвращает страницу данных по Транспортной технике, осуществляет поиск по id,названию,подразделению
    /// </summary>
    /// <param name="id">Уникальный идентификатор записи в журнале</param>
    /// <param name="tipTransportnoyTehniki">Название вида транспортной техники</param>
    /// <param name="podrazdelenieId">Подразделение,к которому относится транспортная техника</param>
    /// <param name="fromRow">Номер ряда, с которого передавать данные</param>
    /// <param name="pageLimit">Колличество строк,которые необходимо передать</param>
    /// <returns></returns>
    public List<String[]> GetListTransportnayaTehnika(string id, string tipTransportnoyTehniki, string podrazdelenieId, int fromRow, int pageLimit){
            return list.GetListTransportnayaTehnika(id,tipTransportnoyTehniki,podrazdelenieId, fromRow, pageLimit) ;
        }

        /// <summary>
        /// Возвращает страницу данных по Боевой технике из базы, осуществляет поиск по id,названию,подразделению
        /// </summary>
        /// <param name="id">Уникальный идетификатор записи в журнале</param>
        /// <param name="tipBoevoyTehniki">Название вида боевой техники</param>
        /// <param name="podrazdelenieId">Подразделение,к которому прикреплена боевая техника</param>
        /// <param name="fromRow">Номер ряда, с которого передавать данные</param>
        /// <param name="pageLimit">Колличество строк,которые необходимо передать</param>
        /// <returns></returns>
        public List<String[]> GetListBoevayaTehnika(string id, string tipBoevoyTehniki, string podrazdelenieId, int fromRow, int pageLimit){
            return list.GetListBoevayaTehnika(id, tipBoevoyTehniki, podrazdelenieId, fromRow, pageLimit);
        }

        /// <summary>
        /// Возвращает страницу данных по списку Сооружений, осуществляет поиск по id,названию,подразделению
        /// </summary>
        /// <param name="id">Уникальный идетификатор </param>
        /// <param name="nazvanie">Название сооружения</param>
        /// <param name="podrazdelenieId">Подразделение, к которому относится сооружение</param>
        /// <param name="fromRow">Номер ряда, с которого передавать данные</param>
        /// <param name="pageLimit">Колличество строк,которые необходимо передать</param>
        /// <returns></returns>
        public List<string[]> GetListSooruzhenie(string id, string nazvanie, string podrazdelenieId, int fromRow, int pageLimit){
            return list.GetListSooruzhenie(id, nazvanie, podrazdelenieId, fromRow, pageLimit);
        }

        /// <summary>
        /// Возвращает страницу данных по списку Обьединений, осуществляет поиск по id,названию,типу обьединения
        /// </summary>
        /// <param name="id">Уникальный идетификатор </param>
        /// <param name="nazvanie">Название обьединения</param>
        /// <param name="tipObiedineniya">Тип обьединения(Дивизия,Бригада,Корпус)</param>
        /// <param name="fromRow">Номер ряда, с которого передавать данные</param>
        /// <param name="pageLimit">Колличество строк,которые необходимо передать</param>
        /// <returns></returns>
        public List<string[]> GetListObiedinenie(string id, string nazvanie, string tiObiedineniya, int fromRow, int pageLimit){
            return list.GetListObiedinenie(id, nazvanie, tiObiedineniya,fromRow, pageLimit);
        }


        /// <summary>
        /// Возвращает страницу данных по списку Подразделений, осуществляет поиск по id,названию,типу подразделения
        /// </summary>
        /// <param name="id">Уникальный идетификатор </param>
        /// <param name="nazvanie">Название подразделения</param>
        /// <param name="tipPodrazdeleniya">Тип подразделения(Взвод,Рота,Часть)</param>
        /// <param name="fromRow">Номер ряда, с которого передавать данные</param>
        /// <param name="pageLimit">Колличество строк,которые необходимо передать</param>
        /// <returns></returns>
        public List<string[]> GetListPodrazdelenie(string id, string nazvanie, string tipPodrazdeleniya, int fromRow, int pageLimit){           
            return list.GetListPodrazdelenie(id, nazvanie, tipPodrazdeleniya,fromRow,pageLimit);
        }

        /// <summary>
        /// Возвращает страницу данных по списку Служащих, осуществляет поиск по id, ФИО
        /// </summary>
        /// <param name="id">Уникальный идентификатор служащего</param>
        /// <param name="imya">Имя служащего</param>
        /// <param name="otchestvo">Отчество служащего</param>
        /// <param name="familiya">Фамилия служащего</param>
        /// <param name="fromRow">Номер ряда, с которого передавать данные</param>
        /// <param name="pageLimit">Колличество строк,которые необходимо передать</param>
        /// <returns></returns>
        public List<string[]> GetListSluzhaschie(string id, string imya, string otchestvo, string familiya, int fromRow, int pageLimit){
            return list.GetListSluzhaschie(id, imya, otchestvo, familiya,fromRow, pageLimit);
        }

        /// <summary>
        ///Обновляет информацию о Служащем
        /// </summary>
        /// <param name="id">Уникальный идентификатор служащего</param>
        /// <param name="imya">Имя служащего</param>
        /// <param name="otchestvo">Отчество служащего</param>
        /// <param name="familiya">Фамилия служащего</param>
        /// <param name="idStarshego">Уникальный идентификатор старшего над служащим</param>
        /// <param name="mladshiyZvanie">Звание младшего состава(если есть)</param>
        /// <param name="starchiyZvanie">Звание старшего состава(если есть)</param>
        /// <returns></returns>
        public string UpdateSluzhaschie(string id, string imya, string otchestvo, string familiya, string idStarshego, string mladshiyZvanie, string starshiyZvanie)
        {
            return update.UpdateSluzhaschie(id, imya, otchestvo,familiya, idStarshego, mladshiyZvanie, starshiyZvanie);
        }

        /// <summary>
        /// Обновляет информацию о Подразделении 
        /// /// </summary>
        /// <param name="id">Уникальный идетификатор </param>
        /// <param name="nazvanie">Название подразделения</param>
        /// <param name="tipPodrazdeleniya">Тип подразделения(Взвод,Рота,Часть)</param>
        /// <param name="idStarshegoPodrazdeleniya">Уникальный идентификатор главенствующего подразделения</param>
        /// <param name="komandirId">Уникальный идентификатор служащего-командира в подразделении</param>
        /// <param name="location">Месторасположение подразделения</param>
        /// <returns></returns>
        public string UpdatePodrazdelenie(string id, string tipPodrazdeleniya, string nazvanie, string idStarshegoPodrazdeleniya, string komandirId, string location){
            return update.UpdatePodrazdelenie(id, tipPodrazdeleniya, nazvanie, idStarshegoPodrazdeleniya, komandirId, location);
        }


        /// <summary>
        /// Обновляет информацию о Обьединении 
        /// </summary>
        /// <param name="id">Уникальный идетификатор </param>
        /// <param name="nazvanie">Название обьединения</param>
        /// <param name="tipObiedineniya">Тип обьединения(Дивизия,Бригада,Корпус)</param>
        /// <param name="sostav">Уникальные идентификаторы  частей,входящие в состав обьединения</param>
        /// <returns></returns>
        public string UpdateObiedinenie(string id, string tipObiedineniya, string nazvanie, List<string> sostav){
            return update.UpdateObiedinenie(id, tipObiedineniya, nazvanie,sostav);
        }

        /// <summary>
        /// Обновляет информацию о Сооружении
        /// </summary>
        /// <param name="id">Уникальный идетификатор </param>
        /// <param name="nazvanie">Название сооружения</param>
        /// <param name="podrazdelenieId">Подразделение, к которому относится сооружение</param>
        /// <returns></returns>
        public string UpdateSooruzhenie(string id, string nazvanie, string podrazdelenieId){
            return update.UpdateSooruzhenie(id, nazvanie, podrazdelenieId);
         }

        /// <summary>
        /// Обновляет запись о Боевой технике
        /// </summary>
        /// <param name="id">Уникальный идетификатор записи в журнале</param>
        /// <param name="tipBoevoyTehniki">Название вида боевой техники</param>
        /// <param name="podrazdelenieId">Подразделение,к которому прикреплена боевая техника</param>
        /// <param name="kolichestvo">Количество едениц боевой техники</param>
        /// <returns></returns>
        public string UpdateBoevayaTehnika(string id, string tipBoevoyTehniki, string kolichestvo, string podrazdelenieId) {
            return update.UpdateBoevayaTehnika(id, tipBoevoyTehniki, kolichestvo, podrazdelenieId);
        }


        /// <summary>
        /// Обновляет запись о Транспортной технике
        /// </summary>
        /// <param name="id">Уникальный идентификатор записи в журнале</param>
        /// <param name="tipTransportnoyTehniki">Название вида транспортной техники</param>
        /// <param name="podrazdelenieId">Подразделение,к которому относится транспортная техника</param>
        /// <param name="kolichestvo">Количество едениц транспортной техники</param>
        /// <returns></returns>
        public string UpdateTransportnayaTehnika(string id, string tipTransportnoyTehniki, string kolichestvo, string podrazdelenieId){
            return update.UpdateTransportnayaTehnika(id, tipTransportnoyTehniki, kolichestvo, podrazdelenieId);
        }

        /// <summary>
        ///Удаляет  обьект Служащий 
        /// </summary>
        /// <param name="id">Уникальный идентификатор служащего</param>
        /// <param name="imya">Имя служащего</param>
        /// <param name="otchestvo">Отчество служащего</param>
        /// <param name="familiya">Фамилия служащего</param>
        /// <returns></returns>
        public string DeleteSluzhashchie(string id, string imya, string otchestvo, string familiya){
            return delete.DeleteSluzhashchie(id, imya, otchestvo, familiya);
        }

        /// <summary>
        ///Удаляет  Подразделение(Часть,Рота,Взвод)
        /// </summary>
        /// <param name="id">Уникальный идентификатор подразделения</param>
        /// <param name="tipPodrazdeleniya">Тип подразделения(Часть,Рота,Взвод)</param>
        /// <param name="nazvanie">Газвание подразделения</param>
        /// <returns></returns>
        public string DeletePodrazdelenie(string id, string tipPodrazdeleniya, string nazvanie){
            return delete.DeletePodrazdelenie(id, tipPodrazdeleniya, nazvanie);
        }

        /// <summary>
        /// Удаляет Обьединение(Дивизия,Корпус,Бригада) 
        /// </summary>
        /// <param name="id">Уникальный идентификатор обьединения</param>
        /// <param name="tipObiedineniya">Тип обьединения(Дивизия,Корпус,Бригада)</param>
        /// <param name="nazvanie">Название обьединения</param>
        /// <returns></returns>
        public string DeleteObiedinenie(string id, string tipObiedineniya, string nazvanie){
            return delete.DeleteObiedinenie(id, tipObiedineniya, nazvanie);
        }

        /// <summary>
        /// Удаляет Сооружение у указанного подразделения
        /// </summary>
        /// <param name="id">Уникальный идентификатор сооружения</param>
        /// <param name="nazvanie">Название сооружения</param>
        /// <param name="podrazdelenieId">Подразделение,к которому прикреплено сооружение</param>
        /// <returns></returns>
        public string DeleteSooruzhenie(string id, string nazvanie, string podrazdelenieId){            
                return delete.DeleteSooruzhenie(id, nazvanie, podrazdelenieId);
        }

        /// <summary>
        /// Удаляет запись  о Боевой технике 
        /// </summary>
        /// <param name="id">Уникальный идентификатор  записи в журнале</param>
        /// <param name="tipBoevoyTehniki">Тип боевой техники</param>
        /// <param name="kolichestvo">Количество едениц боевой техники</param>
        /// <param name="podrazdelenieId">Подразделение,к которому относится беовая техника</param>
        /// <returns></returns>
        public string DeleteBoevayaTehnika(string id, string tipBoevoyTehniki, string kolichestvo, string podrazdelenieId){
            return delete.DeleteBoevayaTehnika(id, tipBoevoyTehniki, kolichestvo, podrazdelenieId);
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
            return delete.DeleteTransportnayaTehnika(id, tipTransportnoyTehniki, kolichestvo, podrazdelenieId);
        }

        /// <summary>
        /// Создает новый обьект Служащий
        /// </summary>
        /// <param name="id">Уникальный идентификатор служащего</param>
        /// <param name="imya">Имя служащего</param>
        /// <param name="otchestvo">Отчество служащего</param>
        /// <param name="familiya">Фамилия служащего</param>
        /// <returns></returns>
        public string CreateSluzhashchie(string id, string imya, string otchestvo, string familiya){
            return create.CreateSluzhashchie(id, imya, otchestvo, familiya);
            
        }
        /// <summary>
        /// Создает новое Подразделение(Часть,Рота,Взвод)
        /// </summary>
        /// <param name="id">Уникальный идентификатор подразделения</param>
        /// <param name="tipPodrazdeleniya">Тип подразделения(Часть,Рота,Взвод)</param>
        /// <param name="nazvanie">Газвание подразделения</param>
        /// <returns></returns>
        public string CreatePodrazdelenie(string id, string tipPodrazdeleniya, string nazvanie){
            return create.CreatePodrazdelenie(id, tipPodrazdeleniya, nazvanie);
        }


        /// <summary>
        /// Создает новое Обьединение(Дивизия,Корпус,Бригада) 
        /// </summary>
        /// <param name="id">Уникальный идентификатор обьединения</param>
        /// <param name="nazvanie">Название обьединения</param>
        /// <param name="tipObiedineniya">Тип обьединения(Дивизия,Корпус,Бригада)</param>
        /// <returns></returns>
        public string CreateObiedinenie(string id, string nazvanie, string tipObiedineniya){
            return create.CreateObiedinenie(id, tipObiedineniya, nazvanie);
        }

        /// <summary>
        /// Создает новое Сооружение у указанного подразделения в базе
        /// </summary>
        /// <param name="id">Уникальный идентификатор сооружения</param>
        /// <param name="nazvanie">Название сооружения</param>
        /// <param name="podrazdelenieId">Подразделение,к которому прикреплено сооружение</param>
        /// <returns></returns>
        public string CreateSooruzhenie(string id, string nazvanie, string podrazdelenieId){
            return create.CreateSooruzhenie(id, nazvanie,podrazdelenieId);

        }
        /// <summary>
        /// Создает новую запись  о Боевой технике
        /// </summary>
        /// <param name="id">Уникальный идентификатор  записи в журнале</param>
        /// <param name="podrazdelenieId">Подразделение,к которому относится беовая техника</param>
        /// <param name="tipBoevoyTehniki">Тип боевой техники</param>
        /// <returns></returns>
        public string CreateBoevayaTehnika(string id, string podrazdelenieId, string tipBoevoyTehniki){
            return create.CreateBoevayaTehnika(id, podrazdelenieId, tipBoevoyTehniki);

        }
        /// <summary>
        /// Создает новую запись о Транспортной технике в базе
        /// </summary>
        /// <param name="id">Уникальный идентификатор записи в журнале</param>
        /// <param name="podrazdelenieId">Подразделение,к которому относится транспортная техника</param>
        /// <param name="tipTransportnoyTehniki">Тип транспортной техники</param>
        /// <returns></returns>
        public string CreateTransportnayaTehnika(string id, string podrazdelenieId, string tipTransportnoyTehniki){
            return create.CreateTransportnayaTehnika(id, podrazdelenieId, tipTransportnoyTehniki);

        }




        /// <summary>
        /// Возвращает имена столбцов для DataGridView Служащие
        /// </summary>
        /// <returns></returns>
        public string[] GetDgvFormatSluzhashie() {          
            return list.GetDgvFormatSluzhashie();
        }

        /// <summary>
        ///  Возвращает имена столбцов для DataGridView Подразделение
        /// </summary>
        /// <returns></returns>
        public string[] GetDgvFormatPodrazdelenie() {
            return list.GetDgvFormatPodrazdelenie();
        }

        /// <summary>
        ///  Возвращает имена столбцов для DataGridView Обьединение
        /// </summary>
        /// <returns></returns>
        public string[] GetDgvFormatObiedinenie() {

            return list.GetDgvFormatObiedinenie();
        }

        /// <summary>
        ///  Возвращает имена столбцов для DataGridView Сооружение
        /// </summary>
        /// <returns></returns>
        public string[] GetDgvFormatSooruzhenie() {
            return list.GetDgvFormatSooruzhenie();
        }

        /// <summary>
        ///  Возвращает имена столбцов для DataGridView Боевая техника
        /// </summary>
        /// <returns></returns>
        public string[] GetDgvFormatBoevayaTehnika() {
            return list.GetDgvFormatBoevayaTehnika();
        }

        /// <summary>
        ///  Возвращает имена столбцов для DataGridView Транспортная техника
        /// </summary>
        /// <returns></returns>
        public string[] GetDgvFormatTransportnayaTehnika()
        {
            return list.GetDgvFormatTransportnayaTehnika();
        }


        /// <summary>
        /// Выполнение свободного SQL-запроса в базе
        /// </summary>
        /// <param name="command_string">Строка запроса</param>
        /// <returns></returns>
        public List<string[]> ExecuteCommand(string command_string) {
            try{
                List<string[]> data = new List<string[]>();

                string separator = ",";
                int argumentNumber = (command_string.Length - command_string.Replace(separator, "").Length) / separator.Length;

                var result = new Context.voenniy_okrugEntities().Database.SqlQuery<string[][]>(command_string);

             
                foreach (var row in result){
                           data.Add(new string[argumentNumber]);
                           for (int i = 0; i < argumentNumber; i++)
                           {
                               data[data.Count - 1][i] = row[i].ToString();
                           }
                }
                return data;
                
            }
            catch (Exception ex){
                List<String[]> data = new List<string[]>();
                data.Add(new string[1]);
                data[data.Count - 1][0] = ex.Message.ToString();
                return data;
            }
            
        }
        

    }
}

