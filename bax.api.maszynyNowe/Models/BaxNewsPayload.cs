using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bax.api.Models
{
    public class BaxNewsPayload
    {
        public BaxNews News { get; set; }
        public bool IsNext { get {
                return string.IsNullOrWhiteSpace(this.NextId) ? false : true;
            } }
        public bool isPrev { get {
                return string.IsNullOrWhiteSpace(this.PrevId) ? false : true;
            } }
        public string NextId { get; set; }
        public string PrevId { get; set; }
    }
}
