using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace Group11_Assignment1.Models
{
    public class Transaction : BindableBase
    {
        private DateTime date;
        private Double amount;

        public Transaction Clone()
        {
            return MemberwiseClone() as Transaction;
        }

        public DateTime Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }

        public Double Amount
        {
            get => amount;
            set => SetProperty(ref amount, value);
        }
    }
}
