using bax.api.maszynyNowe.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bax.api.Services
{
    public class MaszynyNoweService
    {
        private readonly dataFactoryService _baxDataFactoryService;

        public MaszynyNoweService(dataFactoryService baxDataFactoryService)
        {
            _baxDataFactoryService = baxDataFactoryService;
        }

        public List<MaszynyNoweList> GetMaszynyNoweList()
        {
            return this._baxDataFactoryService.GetMaszynyNoweList().OrderByDescending(o => o.nazwaModelu).ToList();
        }

        public MaszynyNoweList GetMaszynyNoweById(string id)
        {
            return this.GetMaszynyNoweList().Find(w => w.id.ToLower() == id.ToLower());
        }



    }
}
