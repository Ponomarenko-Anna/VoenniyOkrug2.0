using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoenniyOkrug.Dao.Entities
{
    class BoevayaTehnika : Entity
    {
        public BoevayaTehnika(Context.voenniy_okrugEntities context) : base(context)
        {
        }
        public class Parameters
        {
            public string id;
            public string podrazdelenieId;
            public string tipBoevoyTehniki;
            public string kolichestvo;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="id"></param>
            /// <param name="podrazdelenieId"></param>
            /// <param name="kolichestvo"></param>
            /// <param name="tipBoevoyTehniki"></param>
            public Parameters(string id, string podrazdelenieId, string kolichestvo, string tipBoevoyTehniki)
            {
                this.id = id;
                this.podrazdelenieId = podrazdelenieId;
                this.kolichestvo = kolichestvo;
                this.tipBoevoyTehniki = tipBoevoyTehniki;
            }
        }

        public   string Create(Parameters parameters)
        {
            var bt = new Context.Boevaya_tehnika();
            bt.id = int.Parse(parameters.id);
            bt.kolichestvo = context.Podrazdelenie.Where(x => (x.id.ToString() == parameters.podrazdelenieId)).FirstOrDefault().id;
            bt.tip = context.Tip_boevoy_tehniki.Where(x => (x.nazvanie ==parameters. tipBoevoyTehniki)).FirstOrDefault().id;
            context.Boevaya_tehnika.Add(bt);
            context.SaveChanges();
            return "Успешно добавлено";
        }

        public   string Delete(Parameters parameters)
        {
            var bt = context.Boevaya_tehnika.Where(x => ((parameters.id == string.Empty || parameters.id == x.id.ToString()) && 
                                                                                      (parameters.tipBoevoyTehniki == string.Empty || parameters.tipBoevoyTehniki == x.Tip_boevoy_tehniki.nazvanie) &&
                                                                                      (parameters.kolichestvo == string.Empty || parameters.kolichestvo == x.kolichestvo.ToString()) && 
                                                                                      (parameters.podrazdelenieId == string.Empty || parameters.podrazdelenieId == x.podrazdelenie.ToString()))).FirstOrDefault();
            if (bt == null) return "Такой записи не существует";
            context.Boevaya_tehnika.Remove(bt);
            context.SaveChanges();
            return "Данные удалены";
        }

        public   string Update(Parameters parameters)
        {
            var boevaya_tehnika = context.Boevaya_tehnika.Where(x => (x.id.ToString() == parameters.id)).FirstOrDefault();
            if (boevaya_tehnika == null)
            {
                return "Такой id уже есть";
            }

            var tip = context.Tip_boevoy_tehniki.Where(x => (x.nazvanie == parameters.tipBoevoyTehniki)).FirstOrDefault();
            boevaya_tehnika.podrazdelenie = tip.id;

            boevaya_tehnika.kolichestvo = int.Parse(parameters.kolichestvo);

            var podr = context.Podrazdelenie.Where(x => (x.id.ToString() == parameters.podrazdelenieId)).FirstOrDefault();
            boevaya_tehnika.podrazdelenie = podr.id;

            context.SaveChanges();
            return "Изменения сохраены";
        }

    }
}
