using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet
{
    public class InternetProvider
    {
        private event EventHandler<InternetArgs> excess_traffic;
        public InternetProvider()
        {
            this.excess_traffic = OverUse;
        }
        protected void OverUse(object _sender, InternetArgs _args)
        {
            if (_args != null && _sender != null)
            {
                Console.WriteLine();

                Console.WriteLine("User {0}:", _args.Name);
                if (_args.ExcessTraffic != 0)
                {
                    Console.WriteLine("You have exceeded the traffic of the selected tariff model by {0:0.00} mb.", _args.ExcessTraffic);
                }
                if (_args.Duty != default)
                {
                    Console.WriteLine("There is a debt on your account {0:0.00}.", _args.Duty);
                }

            }
            else
            {
                Console.WriteLine("Error. There are no arguments.");
            }
        }
        public void Initiate(object _sender, InternetArgs _args)
        {
            this.excess_traffic.Invoke(_sender, _args);
        }
    }
}
