using bax.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bax.api.Services
{
    public class MaszynyNoweService
    {
        private readonly DataFactoryService _baxDataFactoryService;

        public MaszynyNoweService(DataFactoryService baxDataFactoryService)
        {
            _baxDataFactoryService = baxDataFactoryService;
        }

        public List<MaszynyNowe> GetMaszynyNoweList()
        {
            return this._baxDataFactoryService.GetMaszynyNoweList().OrderBy(o=>o.Marka).ThenByDescending(o => o.NazwaModelu).ToList();
        }

        public MaszynyNowe GetMaszynyNoweById(string id)
        {
            return this.GetMaszynyNoweList().Find(w => w.Id.ToLower() == id.ToLower());
        }



    }
}
