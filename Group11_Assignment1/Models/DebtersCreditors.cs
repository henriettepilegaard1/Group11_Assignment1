using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;

namespace Group11_Assignment1.Models
{
    public class DebtersCreditors : BindableBase
    {
        private string name;
        private Double amount;
        
        public DebtersCreditors(string name, double amount)
        {
            name = this.name;
            amount = this.amount;
        }

        public DebtersCreditors Clone()
        {
            return this.MemberwiseClone() as DebtersCreditors;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                SetProperty(ref name, value);
            }
        }

        public double Amount
        {
            get
            {
                return amount;
            }
            set
            {
                SetProperty(ref amount, value);
            }
        }
    }
}
