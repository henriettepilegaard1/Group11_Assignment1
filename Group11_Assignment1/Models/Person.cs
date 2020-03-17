using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;

namespace Group11_Assignment1.Models
{
    public class Person : BindableBase
    {
        private String name;
        private Double amount;
        private ObservableCollection<Transaction> transactions;

        public Person()
        {
            transactions = new ObservableCollection<Transaction>();
        }

        public Person Clone()
        {
            return MemberwiseClone() as Person;
        }

        public String Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public Double Amount
        {
            get => amount;
            set => SetProperty(ref amount, value);
        }

        public ObservableCollection<Transaction> Transactions
        {
            get => transactions;
            set => SetProperty(ref transactions, value); 
        }

        public void AddTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
            Amount += transaction.Amount;
        }

        public void RemoveTransaction(Transaction transaction)
        {
            transactions.Remove(transaction);
            Amount -= transaction.Amount;
        }

        public bool IsValid
        {
            get
            {
                // If amount is not valid return false
                if (Double.IsNaN(Amount))
                    return false;
                // If name is not valid return false
                if (string.IsNullOrWhiteSpace(Name))
                    return false;
                // Return true if all fields are valid
                return true;
            }
        }
        
    }
}
