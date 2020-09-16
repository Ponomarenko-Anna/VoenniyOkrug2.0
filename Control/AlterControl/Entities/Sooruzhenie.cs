using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoenniyOkrug.Dao.Entities
{
    class Sooruzhenie : Entity
    {
        public Sooruzhenie(Context.voenniy_okrugEntities context) : base(context)
        {
        }

        public class Parameters
        {
            public string id;
            public string nazvanie;
            public string podrazdelenieId;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="id"></param>
            /// <param name="podrazdelenieId"></param>
            /// <param name="nazvanie"></param>
            public Parameters(string id, string podrazdelenieId, string nazvanie)
            {
                this.id = id;
                this.podrazdelenieId = podrazdelenieId;
                this.nazvanie = nazvanie;
               }
        }

        public   string Create(Parameters parameters)
        {
            var soor = new Context.Sooruzhenie();
            soor.id = int.Parse(parameters.id);
            soor.nazvanie = parameters.nazvanie;
            soor.podrazdelenie = context.Podrazdelenie.Where(x => (x.id.ToString() == parameters.podrazdelenieId)).FirstOrDefault().id;
            context.Sooruzhenie.Add(soor);
            context.SaveChanges();
            return "Успешно добавлено";
        }

        public   string Delete(Parameters parameters)
        {
            var soor = context.Sooruzhenie.Where(x => ((parameters.id == string.Empty || parameters.id == x.id.ToString()) && 
                                                                                    (parameters.nazvanie == string.Empty || parameters.nazvanie == x.nazvanie.ToString()) && 
                                                                                    (parameters.podrazdelenieId == string.Empty || parameters.podrazdelenieId == x.podrazdelenie.ToString()))).FirstOrDefault();
            if (soor == null) return "Такого сооружения не существует";
            context.Sooruzhenie.Remove(soor);
            context.SaveChanges();
            return "Данные удалены";
        }

        public   string Update(Parameters parameters)
        {
            var context = new Context.voenniy_okrugEntities();
            var sooruzhenie = context.Sooruzhenie.Where(x => (x.id.ToString() == parameters.id)).FirstOrDefault();
            if (sooruzhenie == null)
            {
                return "Соружение с таким id уже существует";
            }

            sooruzhenie.nazvanie = parameters.nazvanie;

            var podr = context.Podrazdelenie.Where(x => (x.id.ToString() == parameters.podrazdelenieId)).FirstOrDefault();
            sooruzhenie.podrazdelenie = podr.id;

            context.SaveChanges();
            return "Изменения сохраены";
        }

    }
}
