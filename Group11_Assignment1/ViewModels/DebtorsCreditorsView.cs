using Group11_Assignment1.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Input;

namespace Group11_Assignment1.ViewModels 
{
    class DebtorsCreditorsView : BindableBase
    {

        public DebtorsCreditorsView(DateTime date, double amount, DebtersCreditors debtersCreditors)
        {
            Date = date;
            Amount = amount;
            CurrentDebtersCreditors = debtersCreditors; 
        }

        #region Properties
        
        DateTime date;
        public DateTime Date
        {
            get 
            {
                return date;
            }
            set 
            { 
                SetProperty(ref date, value); 
            }
        }

        double amout;
        public double Amount
        {
            get
            {
                return amout;
            }
            set
            {
                SetProperty(ref amout, value);
            }
        }

        DebtersCreditors debtersCreditors;
        public DebtersCreditors CurrentDebtersCreditors
        {
            get
            {
                return debtersCreditors;
            }
            set
            {
                SetProperty(ref debtersCreditors, value);
            }
        }
        #endregion Properties
    }
}
