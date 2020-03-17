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
        private Person newPerson;
        private string newAmount;

        public AddPersonViewModel() : this(new Person(), String.Empty) { }

        public AddPersonViewModel( Person newPerson, string newAmount)
        {
            this.newPerson = newPerson;
            this.newAmount = newAmount;
             
            
        }

        #region Properties

        //Person newPerson;

        public Person NewPerson
        {
            get => newPerson;
            set => SetProperty(ref newPerson, value);
        }
        public string Name => newPerson.Name;
        public double Amount => newPerson.Amount;

        public string NewAmount
        {
            get => newAmount;
            set => SetProperty(ref newAmount, value);
        }

        public bool IsValid
        {
            get
            {
                IsValid = true;
                if (String.IsNullOrWhiteSpace(newPerson.Name))
                    IsValid = false;
                if (Double.IsNaN(newPerson.Amount))
                    IsValid = false;
                return IsValid;
            }
            set => throw new NotImplementedException();
        }

        #endregion

        #region Commands

        ICommand _saveBtnCommand;

        public ICommand SaveBtnCommand
        {
            get
            {
                return _saveBtnCommand ?? (_saveBtnCommand = new DelegateCommand(
                    SaveBtnCommand_Execute, SaveBtnCommand_CanExecute)
                    .ObservesProperty(() => newPerson.Name)
                    .ObservesProperty(() => NewPerson.Amount));
            }
        }

        private void SaveBtnCommand_Execute()
        {
            //can be left empty
        }


        private bool SaveBtnCommand_CanExecute()
        {
            return IsValid;
        }

        ICommand _cancelBtnCommand;

        public ICommand CancelBtnCommand
        {
            get
            {
                return _cancelBtnCommand ?? (_cancelBtnCommand = new DelegateCommand(() =>
                {
                    Application.Current.MainWindow.Close();
                }));
            }
        }
    
    #endregion


}

}
