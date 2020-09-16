using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoenniyOkrug.Dao.Entities
{
    class Entity
    {
        /// <summary>
        /// Хранит ссылку на базу,с которой взаимодействует
        /// </summary>
        protected Context.voenniy_okrugEntities context;

        public Entity(Context.voenniy_okrugEntities context_)
        {
            context = context_;
        }      
       /*
        /// <summary>
        ///Создает  обьект в базе
        /// </summary>
        public virtual string Create()
        {
            return "";
        }

        /// <summary>
        ///Удаляет  обьект  из базы
        /// </summary>
        public virtual string Delete()
        {
            return "";
        }
        
        /// <summary>
        ///Обновляет  обьект в базе
        /// </summary>
        public virtual string Update()
        {
            return "";
        }
        */
    }
}
