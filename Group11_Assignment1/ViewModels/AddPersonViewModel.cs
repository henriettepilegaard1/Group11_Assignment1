using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Group11_Assignment1.Models;
using Prism.Commands;

namespace Group11_Assignment1.ViewModels
{
    public class AddPersonViewModel : BindableBase
    {
        private readonly Person newPerson;
        private string newAmount;
        private string newName;

        public AddPersonViewModel() : this(new Person(), String.Empty, String.Empty)
        {
        }

        public AddPersonViewModel(Person newPerson, string newName, string newAmount)
        {
            this.newName = newName;
            this.newPerson = newPerson;
            this.newAmount = newAmount;

            this.SaveBtnCommand = new DelegateCommand(SaveBtnCommand_Execute, SaveBtnCommand_CanExecute)
                .ObservesProperty(() => NewName)
                .ObservesProperty(() => NewAmount);


        }

        #region Properties

        public string NewName
        {
            get => newName;
            set => SetProperty(ref newName, value);
        }
        //Person newPerson;


        public string NewAmount
        {
            get => newAmount;
            set => SetProperty(ref newAmount, value);
        }

        public bool IsValid
        {
            get
            {
                if (String.IsNullOrWhiteSpace(NewName))
                    return false;
                if (string.IsNullOrWhiteSpace(NewAmount))
                    return false;
                return IsValidAmount;
            }
        }

        private Boolean IsValidAmount
        {
            get
            {
                try
                {
                    Convert.ToDouble(NewAmount);
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }
        }

        #endregion

        #region Commands

        public ICommand SaveBtnCommand { get; private set; }

        private void SaveBtnCommand_Execute()
        {
            // Set name on save
            newPerson.Name = NewName;

            // Add first transaction on save
            newPerson.AddTransaction(new Transaction
            {
                Date = DateTime.Now,
                Amount = Convert.ToDouble(NewAmount),
            });
        }

        private bool SaveBtnCommand_CanExecute() => IsValid;


        #endregion

    }

    public class AddPersonViewModelDesign : AddPersonViewModel
    {
        // Dummy values for deign

        public AddPersonViewModelDesign() : base(new Person(), "Eigil", "200")
        {
        }

    }
}
