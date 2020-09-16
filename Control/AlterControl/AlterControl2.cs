using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoenniyOkrug.Dao
{
    class AlternativeAlterControl
    {
        /// <summary>
        ///
        /// </summary>
            private Context.voenniy_okrugEntities context;
            private Dao.CRUD.List list;
            
            private Entities.Sluzhaschiy sluzhaschiy;
            private Entities.Podrazdelenie podrazdelenie;
            private Entities.Obiedinenie obiedinenie;
            private Entities.Sooruzhenie sooruzhenie;
            private Entities.BoevayaTehnika boevayaTehnika;
            private Entities.TransportnayaTehnika transportnayaTehnika;

            public AlternativeAlterControl()
            {
                this.context = new Context.voenniy_okrugEntities();

                this.list = new Dao.CRUD.List(context);              
                this.sluzhaschiy = new Entities.Sluzhaschiy(context);
                this.podrazdelenie = new Entities.Podrazdelenie(context);
                this.obiedinenie = new Entities.Obiedinenie(context);
                this.sooruzhenie = new Entities.Sooruzhenie(context);
                this.boevayaTehnika = new Entities.BoevayaTehnika(context);
                this.transportnayaTehnika = new Entities.TransportnayaTehnika(context);
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
            public List<String[]> GetListTransportnayaTehnika(string id, string tipTransportnoyTehniki, string podrazdelenieId, int fromRow, int pageLimit)
            {
                return list.GetListTransportnayaTehnika(id, tipTransportnoyTehniki, podrazdelenieId, fromRow, pageLimit);
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
            public List<String[]> GetListBoevayaTehnika(string id, string tipBoevoyTehniki, string podrazdelenieId, int fromRow, int pageLimit)
            {
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
            public List<string[]> GetListSooruzhenie(string id, string nazvanie, string podrazdelenieId, int fromRow, int pageLimit)
            {
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
            public List<string[]> GetListObiedinenie(string id, string nazvanie, string tiObiedineniya, int fromRow, int pageLimit)
            {
                return list.GetListObiedinenie(id, nazvanie, tiObiedineniya, fromRow, pageLimit);
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
            public List<string[]> GetListPodrazdelenie(string id, string nazvanie, string tipPodrazdeleniya, int fromRow, int pageLimit)
            {
                return list.GetListPodrazdelenie(id, nazvanie, tipPodrazdeleniya, fromRow, pageLimit);
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
            public List<string[]> GetListSluzhaschie(string id, string imya, string otchestvo, string familiya, int fromRow, int pageLimit)
            {
                return list.GetListSluzhaschie(id, imya, otchestvo, familiya, fromRow, pageLimit);
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
                var parameters = new Entities.Sluzhaschiy.Parameters(id, imya, otchestvo, familiya, idStarshego, mladshiyZvanie, starshiyZvanie);
                return this.sluzhaschiy.Update(parameters);
            }

        /// <summary>
        /// Обновляет информацию о Подразделении 
        /// /// </summary>
        /// <param name="id">Уникальный идетификатор </param>
        /// <param name="tipPodrazdeleniya">Тип подразделения(Взвод,Рота,Часть)</param>
        /// <param name="nazvanie">Название подразделения</param>
        /// <param name="idStarshegoPodrazdeleniya">Уникальный идентификатор главенствующего подразделения</param>
        /// <param name="komandirId">Уникальный идентификатор служащего-командира в подразделении</param>
        /// <param name="location">Месторасположение подразделения</param>
        /// <returns></returns>
        public string UpdatePodrazdelenie(string id, string tipPodrazdeleniya, string nazvanie, string idStarshegoPodrazdeleniya, string komandirId, string location)
        {
           var parameters = new Entities.Podrazdelenie.Parameters(id, tipPodrazdeleniya, nazvanie, idStarshegoPodrazdeleniya, komandirId, location);
           return this.podrazdelenie.Update(parameters);
         }


            /// <summary>
            /// Обновляет информацию о Обьединении 
            /// </summary>
            /// <param name="id">Уникальный идетификатор </param>
            /// <param name="nazvanie">Название обьединения</param>
            /// <param name="tipObiedineniya">Тип обьединения(Дивизия,Бригада,Корпус)</param>
            /// <param name="sostav">Уникальные идентификаторы  частей,входящие в состав обьединения</param>
            /// <returns></returns>
            public string UpdateObiedinenie(string id, string tipObiedineniya, string nazvanie, List<string> sostav)
            {
            var parameters = new Entities.Obiedinenie.Parameters(id, tipObiedineniya, nazvanie, sostav);
            return obiedinenie.Update(parameters);
            }

            /// <summary>
            /// Обновляет информацию о Сооружении
            /// </summary>
            /// <param name="id">Уникальный идетификатор </param>
            /// <param name="nazvanie">Название сооружения</param>
            /// <param name="podrazdelenieId">Подразделение, к которому относится сооружение</param>
            /// <returns></returns>
            public string UpdateSooruzhenie(string id, string nazvanie, string podrazdelenieId)
            {
            var parameters = new Entities.Sooruzhenie.Parameters(id, podrazdelenieId, nazvanie);
            return this.sooruzhenie.Update(parameters);
            }

            /// <summary>
            /// Обновляет запись о Боевой технике
            /// </summary>
            /// <param name="id">Уникальный идетификатор записи в журнале</param>
            /// <param name="tipBoevoyTehniki">Название вида боевой техники</param>
            /// <param name="podrazdelenieId">Подразделение,к которому прикреплена боевая техника</param>
            /// <param name="kolichestvo">Количество едениц боевой техники</param>
            /// <returns></returns>
            public string UpdateBoevayaTehnika(string id, string tipBoevoyTehniki, string kolichestvo, string podrazdelenieId)
            {
            var parameters = new Entities.BoevayaTehnika.Parameters(id, tipBoevoyTehniki, kolichestvo, podrazdelenieId);
            return this.boevayaTehnika.Update(parameters);
            }


            /// <summary>
            /// Обновляет запись о Транспортной технике
            /// </summary>
            /// <param name="id">Уникальный идентификатор записи в журнале</param>
            /// <param name="tipTransportnoyTehniki">Название вида транспортной техники</param>
            /// <param name="podrazdelenieId">Подразделение,к которому относится транспортная техника</param>
            /// <param name="kolichestvo">Количество едениц транспортной техники</param>
            /// <returns></returns>
            public string UpdateTransportnayaTehnika(string id, string tipTransportnoyTehniki, string kolichestvo, string podrazdelenieId)
            {
            var parameters = new Entities.TransportnayaTehnika.Parameters(id, tipTransportnoyTehniki, kolichestvo, podrazdelenieId);
            return transportnayaTehnika.Update(parameters);
            }

            /// <summary>
            ///Удаляет  обьект Служащий 
            /// </summary>
            /// <param name="id">Уникальный идентификатор служащего</param>
            /// <param name="imya">Имя служащего</param>
            /// <param name="otchestvo">Отчество служащего</param>
            /// <param name="familiya">Фамилия служащего</param>
            /// <returns></returns>
            public string DeleteSluzhashchie(string id, string imya, string otchestvo, string familiya)
            {
            var parameters = new Entities.Sluzhaschiy.Parameters(id, imya, otchestvo, familiya,string.Empty,string.Empty,string.Empty);
            return sluzhaschiy.Delete(parameters);
            }

            /// <summary>
            ///Удаляет  Подразделение(Часть,Рота,Взвод)
            /// </summary>
            /// <param name="id">Уникальный идентификатор подразделения</param>
            /// <param name="tipPodrazdeleniya">Тип подразделения(Часть,Рота,Взвод)</param>
            /// <param name="nazvanie">Газвание подразделения</param>
            /// <returns></returns>
            public string DeletePodrazdelenie(string id, string tipPodrazdeleniya, string nazvanie)
            {
            var parameters = new Entities.Podrazdelenie.Parameters(id,nazvanie, tipPodrazdeleniya, string.Empty, string.Empty, string.Empty);
            return this.podrazdelenie.Delete(parameters);
            }

            /// <summary>
            /// Удаляет Обьединение(Дивизия,Корпус,Бригада) 
            /// </summary>
            /// <param name="id">Уникальный идентификатор обьединения</param>
            /// <param name="tipObiedineniya">Тип обьединения(Дивизия,Корпус,Бригада)</param>
            /// <param name="nazvanie">Название обьединения</param>
            /// <returns></returns>
            public string DeleteObiedinenie(string id, string tipObiedineniya, string nazvanie)
            {
            var parameters = new Entities.Obiedinenie.Parameters(id, nazvanie, tipObiedineniya, new List<string>());
            return this.obiedinenie.Delete(parameters);
            }

            /// <summary>
            /// Удаляет Сооружение у указанного подразделения
            /// </summary>
            /// <param name="id">Уникальный идентификатор сооружения</param>
            /// <param name="nazvanie">Название сооружения</param>
            /// <param name="podrazdelenieId">Подразделение,к которому прикреплено сооружение</param>
            /// <returns></returns>
            public string DeleteSooruzhenie(string id, string nazvanie, string podrazdelenieId)
            {
            var parameters = new Entities.Sooruzhenie.Parameters(id, nazvanie, podrazdelenieId);
            return this.sooruzhenie.Delete(parameters);
            }

            /// <summary>
            /// Удаляет запись  о Боевой технике 
            /// </summary>
            /// <param name="id">Уникальный идентификатор  записи в журнале</param>
            /// <param name="tipBoevoyTehniki">Тип боевой техники</param>
            /// <param name="kolichestvo">Количество едениц боевой техники</param>
            /// <param name="podrazdelenieId">Подразделение,к которому относится беовая техника</param>
            /// <returns></returns>
            public string DeleteBoevayaTehnika(string id, string tipBoevoyTehniki, string kolichestvo, string podrazdelenieId)
            {
            var parameters = new Entities.BoevayaTehnika.Parameters(id, tipBoevoyTehniki, kolichestvo, podrazdelenieId);
            return boevayaTehnika.Delete(parameters);
            }


            /// <summary>
            /// Создает новую запись о Транспортной технике в базе
            /// </summary>
            /// <param name="id">Уникальный идентификатор записи в журнале</param>
            /// <param name="tipTransportnoyTehniki">Тип транспортной техники</param>
            /// <param name="kolichestvo">Количество едениц транспортной техники</param>
            /// <param name="podrazdelenieId">Подразделение,к которому относится транспортная техника</param>
            /// <returns></returns>
            public string DeleteTransportnayaTehnika(string id, string tipTransportnoyTehniki, string kolichestvo, string podrazdelenieId)
            {
            var parameters = new Entities.TransportnayaTehnika.Parameters(id, tipTransportnoyTehniki, kolichestvo, podrazdelenieId);
            return transportnayaTehnika.Delete(parameters);
            }

            /// <summary>
            /// Создает новый обьект Служащий
            /// </summary>
            /// <param name="id">Уникальный идентификатор служащего</param>
            /// <param name="imya">Имя служащего</param>
            /// <param name="otchestvo">Отчество служащего</param>
            /// <param name="familiya">Фамилия служащего</param>
            /// <returns></returns>
            public string CreateSluzhashchie(string id, string imya, string otchestvo, string familiya)
            {
            var parameters = new Entities.Sluzhaschiy.Parameters(id, imya, otchestvo, familiya, string.Empty, string.Empty, string.Empty);
            return this.sluzhaschiy.Create(parameters);
        }
            /// <summary>
            /// Создает новое Подразделение(Часть,Рота,Взвод)
            /// </summary>
            /// <param name="id">Уникальный идентификатор подразделения</param>
            /// <param name="tipPodrazdeleniya">Тип подразделения(Часть,Рота,Взвод)</param>
            /// <param name="nazvanie">Газвание подразделения</param>
            /// <returns></returns>
            public string CreatePodrazdelenie(string id, string tipPodrazdeleniya, string nazvanie)
            {
            var parameters = new Entities.Podrazdelenie.Parameters(id, tipPodrazdeleniya, nazvanie, string.Empty, string.Empty, string.Empty);
            return this.podrazdelenie.Create(parameters);
            }


            /// <summary>
            /// Создает новое Обьединение(Дивизия,Корпус,Бригада) 
            /// </summary>
            /// <param name="id">Уникальный идентификатор обьединения</param>
            /// <param name="nazvanie">Название обьединения</param>
            /// <param name="tipObiedineniya">Тип обьединения(Дивизия,Корпус,Бригада)</param>
            /// <returns></returns>
            public string CreateObiedinenie(string id, string nazvanie, string tipObiedineniya)
            {
            var parameters = new Entities.Obiedinenie.Parameters(id, tipObiedineniya, nazvanie,new List<string>());
            return obiedinenie.Create(parameters);
        }

            /// <summary>
            /// Создает новое Сооружение у указанного подразделения в базе
            /// </summary>
            /// <param name="id">Уникальный идентификатор сооружения</param>
            /// <param name="nazvanie">Название сооружения</param>
            /// <param name="podrazdelenieId">Подразделение,к которому прикреплено сооружение</param>
            /// <returns></returns>
            public string CreateSooruzhenie(string id, string nazvanie, string podrazdelenieId)
            {
            var parameters = new Entities.Sooruzhenie.Parameters(id, nazvanie, podrazdelenieId);
            return sooruzhenie.Create(parameters);
            }
            /// <summary>
            /// Создает новую запись  о Боевой технике
            /// </summary>
            /// <param name="id">Уникальный идентификатор  записи в журнале</param>
            /// <param name="podrazdelenieId">Подразделение,к которому относится беовая техника</param>
            /// <param name="tipBoevoyTehniki">Тип боевой техники</param>
            /// <returns></returns>
            public string CreateBoevayaTehnika(string id, string podrazdelenieId, string tipBoevoyTehniki)
            {
            var parameters = new Entities.BoevayaTehnika.Parameters(id, podrazdelenieId,string.Empty, string.Empty );
            return this.boevayaTehnika.Create(parameters);
        }
            /// <summary>
            /// Создает новую запись о Транспортной технике в базе
            /// </summary>
            /// <param name="id">Уникальный идентификатор записи в журнале</param>
            /// <param name="podrazdelenieId">Подразделение,к которому относится транспортная техника</param>
            /// <param name="tipTransportnoyTehniki">Тип транспортной техники</param>
            /// <returns></returns>
            public string CreateTransportnayaTehnika(string id, string podrazdelenieId, string tipTransportnoyTehniki)
            {
            var parameters = new Entities.TransportnayaTehnika.Parameters(id, podrazdelenieId, string.Empty, string.Empty );
            return this.transportnayaTehnika.Create(parameters);
        }




            /// <summary>
            /// Возвращает имена столбцов для DataGridView Служащие
            /// </summary>
            /// <returns></returns>
            public string[] GetDgvFormatSluzhashie()
            {
                return list.GetDgvFormatSluzhashie();
            }

            /// <summary>
            ///  Возвращает имена столбцов для DataGridView Подразделение
            /// </summary>
            /// <returns></returns>
            public string[] GetDgvFormatPodrazdelenie()
            {
                return list.GetDgvFormatPodrazdelenie();
            }

            /// <summary>
            ///  Возвращает имена столбцов для DataGridView Обьединение
            /// </summary>
            /// <returns></returns>
            public string[] GetDgvFormatObiedinenie()
            {

                return list.GetDgvFormatObiedinenie();
            }

            /// <summary>
            ///  Возвращает имена столбцов для DataGridView Сооружение
            /// </summary>
            /// <returns></returns>
            public string[] GetDgvFormatSooruzhenie()
            {
                return list.GetDgvFormatSooruzhenie();
            }

            /// <summary>
            ///  Возвращает имена столбцов для DataGridView Боевая техника
            /// </summary>
            /// <returns></returns>
            public string[] GetDgvFormatBoevayaTehnika()
            {
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
            public List<string[]> ExecuteCommand(string command_string)
            {
                try
                {
                    List<string[]> data = new List<string[]>();

                    string separator = ",";
                    int argumentNumber = (command_string.Length - command_string.Replace(separator, "").Length) / separator.Length;

                    var result = new Context.voenniy_okrugEntities().Database.SqlQuery<string[][]>(command_string);


                    foreach (var row in result)
                    {
                        data.Add(new string[argumentNumber]);
                        for (int i = 0; i < argumentNumber; i++)
                        {
                            data[data.Count - 1][i] = row[i].ToString();
                        }
                    }
                    return data;

                }
                catch (Exception ex)
                {
                    List<String[]> data = new List<string[]>();
                    data.Add(new string[1]);
                    data[data.Count - 1][0] = ex.Message.ToString();
                    return data;
                }

            }

        }
    }
