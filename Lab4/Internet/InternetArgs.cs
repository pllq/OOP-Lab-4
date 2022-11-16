using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet
{
    public class InternetArgs
    {
        public string Name { get; private set; }
        public ulong ExcessTraffic { get; private set; }
        public double Duty { get; private set; }
        protected InternetArgs() { }
        public InternetArgs(string _name, ulong _excesstraffic)
        {
            this.Name = _name;
            this.ExcessTraffic = _excesstraffic;
        }
        public InternetArgs(string _name, ulong _excesstraffic, double _duty)
        {
            this.Name = _name;
            this.ExcessTraffic = _excesstraffic;
            this.Duty = _duty;
        }


    }
}
