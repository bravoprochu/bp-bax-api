using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bax.api.Models
{
    public class MaszynyNowe : MaszynyNoweList
    {
        public List<string> BranzaList
        {
            get
            {
                var res = new List<string>();
                if (!string.IsNullOrWhiteSpace(this.branza))
                {
                    var found = branza.IndexOf(';');
                    var arr = found > -1 ? branza.Split(';') : branza.Split('/');
                    res = arr.OrderBy(o => o).ToList();
                }
                return res;
            }
        }

        public List<string> ZasilanieList
        {
            get
            {
                var res = new List<string>();
                if (!string.IsNullOrWhiteSpace(this.zasilanie))
                {
                    var found = zasilanie.IndexOf(';');
                    var arr = found > -1 ? zasilanie.Split(';') : zasilanie.Split('/');
                    res = arr.OrderBy(o => o).ToList();
                }
                return res;
            }
        }

    }



}
