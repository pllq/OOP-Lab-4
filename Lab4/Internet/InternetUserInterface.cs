using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet
{
    public class InternetUserInterface
    {
        private string name;
        private ulong traffic = 0;
        private string password;
        private bool access = false;
        private ulong used_traffic = 0;
        private double payment = 0; //1.5 for 1 GB


        public InternetUserInterface(string _name, string _password)
        {
            this.name = _name;
            this.password = _password;
        }

        public void SetTraffic(ulong _traffic)
        {
            if (this.access)
            {
                if (this.traffic == 0)
                {
                    if (_traffic % 1024 == 0)
                    {
                        this.traffic = _traffic;
                    }
                    else
                    {
                        this.traffic = (_traffic / 1024 + 1) * 1024;
                    }
                    this.payment = -(this.traffic / 1024 * 1.5);
                }
                else
                {
                    if (_traffic >= this.traffic)
                    {
                        ulong __traffic = _traffic - this.traffic;
                        double _payment = 0;
                        if (__traffic % 1024 == 0)
                        {
                            _payment = __traffic / 1024 * 1.5;
                        }
                        else
                        {
                            _payment = (__traffic / 1024 + 1) * 1.5;
                        }
                        this.payment -= _payment;
                        this.traffic = _traffic;
                    }
                    else
                    {
                        ulong __traffic = this.traffic - _traffic;
                        double _payment = 0;
                        if (__traffic % 1024 == 0)
                        {
                            _payment = __traffic / 1024 * 1.5;
                        }
                        else
                        {
                            _payment = (__traffic / 1024 + 1) * 1.5;
                        }
                        this.payment += _payment;
                        this.traffic = _traffic;
                    }
                }
            }
            else
            {
                ConsoleMessages.NoAccess(this.name);
            }
        }

        public void EnterPassword(string _password)
        {
            if (this.password.CompareTo(_password) == 0)
            {
                this.access = true;
                ConsoleMessages.RightPassword(this.name);
            }
            else
            {
                ConsoleMessages.WrongPassword(this.name);
            }
        }

        public void UseInternet(ulong _used_traffic)
        {
            if (this.access)
            {
                if (this.traffic != 0)
                {
                    this.used_traffic += _used_traffic;
                    if (this.used_traffic > this.traffic)
                    {
                        //обработка события
                        InternetProvider _provider = new InternetProvider();
                        _provider.Initiate(this, this.OverUse());
                    }
                }
                else
                {
                    ConsoleMessages.NoTraffic();
                }
            }
            else
            {
                ConsoleMessages.NoAccess(this.name);
            }
        }

        public void Pay(double _payment)
        {
            if (this.access)
            {
                if (_payment > 0)
                {
                    this.payment += _payment;
                }
                else
                {
                    ConsoleMessages.WrongPayment();
                }
            }
            else
            {
                ConsoleMessages.NoAccess(this.name);
            }
        }

        public void EndMonth()
        {
            if (this.used_traffic > this.traffic)
            {
                this.payment -= Convert.ToDouble(this.used_traffic - this.traffic) / 1024 * 1.5;
            }
            this.payment -= (this.traffic / 1024 * 1.5);
            this.used_traffic = 0;
            if (this.payment < 0)
            {
                InternetProvider _provider = new InternetProvider();
                _provider.Initiate(this, this.OverUse());
            }
        }
        protected InternetArgs OverUse()
        {
            if (this.used_traffic <= this.traffic && this.payment >= 0)
            {
                return null;
            }
            else
            {
                string _name = this.name;
                ulong _excesstraffic = 0;
                if (this.used_traffic > this.traffic)
                {
                    _excesstraffic = this.used_traffic - this.traffic;
                }
                if (this.payment < 0)
                {
                    return new InternetArgs(_name, _excesstraffic, this.payment);
                }
                else
                {
                    return new InternetArgs(_name, _excesstraffic);
                }
            }
        }
    }
}
