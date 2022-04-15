using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Assignment
{
    internal class ClassIC
    {
        private string _name;
        private string _sum;
        private string _income;

        public ClassIC(string name, string sum, string income, string v)
        {

            this._name = name;
            this._sum = sum;
            this._sum = income;
        }

        public string getName()
        {
            return _name;
        }
        public string getSum()
        {
            return _sum;
        }
        public string getIncome()
        {
            return _income;
        }
    }
}
