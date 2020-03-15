using Group11_Assignment1.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Windows.Input;

namespace Group11_Assignment1.ViewModels 
{
    class PersonViewModel : BindableBase
    {
        private Person person;
        private String amount;


        public PersonViewModel()
        {
            AddTransActionCommand = new DelegateCommand(AddTransActionCommand_Execute, AddTransActionCommand_CanExecute)
                .ObservesProperty(() => Amount)
                .ObservesProperty(() => Person);
        }

        #region Properties

        public ObservableCollection<Transaction> Transactions => Person.Transactions;
        
        public Person Person
        {
            get => person;
            set => SetProperty(ref person, value);
        }

        public String Amount
        {
            get => amount;
            set => SetProperty(ref amount, value);
        }

        private Boolean IsValidPerson
        {
            get
            {
                if (Person is null)
                    return false;
                return Person.IsValid;
            }
        }

        private Boolean IsValidAmount
        {
            get
            {
                try
                {
                    Convert.ToDouble(Amount);
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }

        #endregion Properties

        #region Commands

        public ICommand AddTransActionCommand { get; private set; }

        private void AddTransActionCommand_Execute()
        {
            var transaction = new Transaction
            {
                Amount = Convert.ToDouble(Amount),
                Date = DateTime.Now
            };
            Person.AddTransaction(transaction);
        }

        private bool AddTransActionCommand_CanExecute()
        {
            return IsValidPerson && IsValidAmount;
        }


        ICommand cancelBtnCommand;

        public ICommand CancelBtnCommand
        {
            get
            {
                return cancelBtnCommand ?? (cancelBtnCommand = new DelegateCommand(
                   CancelBtnCommand_Execute, CancelBtnCommand_CanExecute)
                  .ObservesProperty(() => Person.Name)
                  .ObservesProperty(() => Person.Amount));
            }
        }

        private void CancelBtnCommand_Execute()
        {
            // Can be left empty
        }

        private bool CancelBtnCommand_CanExecute()
        {
            return IsValidPerson;
        }
        #endregion Commands
    }
}
