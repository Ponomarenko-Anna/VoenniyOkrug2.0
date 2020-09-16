using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoenniyOkrug.Dao.Entities
{
    class TransportnayaTehnika : Entity
    {
        public TransportnayaTehnika(Context.voenniy_okrugEntities context) : base(context)
        {
        }
        public class Parameters
        {
            public string id;
            public string podrazdelenieId;
            public string kolichestvo;
            public string tipTransportnoyTehniki;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="id"></param>
            /// <param name="podrazdelenieId"></param>
            /// <param name="kolichestvo"></param>
            /// <param name="tipTransportnoyTehniki"></param>
            public Parameters(string id, string podrazdelenieId, string kolichestvo, string tipTransportnoyTehniki)
            {
                this.id = id;
                this.podrazdelenieId = podrazdelenieId;
                this.kolichestvo = kolichestvo;
                this.tipTransportnoyTehniki = tipTransportnoyTehniki;
            }
        }

        public   string Create(Parameters parameters)
        {
            var tt = new Context.Transportnaya_tehnika();
            tt.id = int.Parse(parameters.id);
            tt.kolichestvo = context.Podrazdelenie.Where(x => (x.id.ToString() == parameters.podrazdelenieId)).FirstOrDefault().id;
            tt.tip = context.Tip_transportnoy_tehniki.Where(x => (x.nazvanie == parameters.tipTransportnoyTehniki)).FirstOrDefault().id;
            context.Transportnaya_tehnika.Add(tt);
            context.SaveChanges();
            return "Успешно добавлено";
        }

        public   string Delete(Parameters parameters)
        {
            var tt = context.Transportnaya_tehnika.Where(x => ((parameters.id == string.Empty || parameters.id == x.id.ToString()) &&
                                                                                               (parameters.tipTransportnoyTehniki == string.Empty || parameters.tipTransportnoyTehniki == x.Tip_transportnoy_tehniki.nazvanie) && 
                                                                                               (parameters.kolichestvo == string.Empty || parameters.kolichestvo == x.kolichestvo.ToString()) && 
                                                                                               (parameters.podrazdelenieId == string.Empty || parameters.podrazdelenieId == x.podrazdelenie.ToString()))).FirstOrDefault();
            if (tt == null) return "Такой записи не существует";
            context.Transportnaya_tehnika.Remove(tt);
            context.SaveChanges();
            return "Данные удалены";
        }

        public   string Update(Parameters parameters)
        {
            var transportnaya_tehnika = context.Transportnaya_tehnika.Where(x => (x.id.ToString() == parameters.id)).FirstOrDefault();

            if (transportnaya_tehnika == null)
            {
                return "Такой id уже есть";
            }

            var tip = context.Tip_transportnoy_tehniki.Where(x => (x.nazvanie == parameters.tipTransportnoyTehniki)).FirstOrDefault();
            transportnaya_tehnika.podrazdelenie = tip.id;

            transportnaya_tehnika.kolichestvo = int.Parse(parameters.kolichestvo);

            var podr = context.Podrazdelenie.Where(x => (x.id.ToString() == parameters.podrazdelenieId)).FirstOrDefault();
            transportnaya_tehnika.podrazdelenie = podr.id;

            context.SaveChanges();
            return "Изменения сохраены";
        }

    }
}
