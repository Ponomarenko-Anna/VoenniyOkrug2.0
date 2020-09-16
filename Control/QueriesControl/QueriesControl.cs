using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace VoenniyOkrug.Control.QureriesControl
{
    /// <summary>
    /// 
    /// </summary>
    class QueriesControl
    {
       /// <summary>
       /// Хранит ссылку на базу,из которой достаёт данные
       /// </summary>
       private Context.voenniy_okrugEntities context;
        private  List list;

        public QueriesControl() {
            context = new Context.voenniy_okrugEntities();
            this.list = new List(context);
        }

       public  List<String[]> GetListSluzhaschie( String zvanie,int fromRow, int pageLimit)
        {
            List<String[]> data = list.GetListSluzhaschie("","","","",zvanie,fromRow,pageLimit);       
            return data;
        }

        public List<String> GetZvanieSluzhaschie() {
            return list.GetZvanieSluzhashie();
        }

        public List<String[]> GetListStarshiySluzhaschiy(String id,int fromRow, int pageLimit)
        {            
            List<String[]> data = list.GetListStarshiy(id,  fromRow, pageLimit);      
            return data;
        }

        public List<string[]> GetListChast(string soorSign,string soorLimit,string btSign, string btLimit,string ttSign, string ttLimit,int fromRow,int pageLimit)
        {
            List<string[]> data = list.GetListPodrazdelenie(soorSign, soorLimit, btSign, btLimit, ttSign, ttLimit, fromRow, pageLimit);
            return data;
        }

        
        public List<string[]> GetListSooruzheniya(string podr_id,  int fromRow, int pageLimit)
        {         
            List<String[]> data = list.GetListSooruzhenie("", "", podr_id,  fromRow, pageLimit);         
            return data;
        }

        public List<String[]> GetListBoevayaTehnika(String podr_id, String obiedinenie, String tip, int fromRow, int pageLimit)
        {
            List<String[]> data = list.GetListBoevayaTehnika("",tip,podr_id ,fromRow, pageLimit);
            
            return data;
        }

        public List<String[]> GetListTransportnayaTehnika(String podr_id, String obiedinenie, String tip,int fromRow, int pageLimit)
        {
            List<String[]> data = list.GetListTransportnayaTehnika("", tip, podr_id, fromRow, pageLimit);

            return data;
        }

        public List<String[]> GetListSostavObiedineniya(String obiedinenie, int fromRow, int pageLimit)
        {
            List<String[]> data = list.GetListObiedinenie("", obiedinenie, "",  fromRow, pageLimit);
          
            return data;

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
        public string[] GetDgvFormatChasti()
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
        /// Возвращает имена столбцов для DataGridView Состав обьединений
        /// </summary>
        /// <returns></returns>
        public string[] GetDgvFormatSostavObiedineniy() {
            return list.GetDgvFormatSostavObiedineniy();
        }

        /// <summary>
        /// Возвращает имена столбцов для DataGridView Найти всех страших служащих
        /// </summary>
        /// <returns></returns>
        public string[] GetDgvFormatStarshiySluzhaschiy() {
            return list.GetDgvFormatStarshiySluzhaschiy();
        }
    }
}
