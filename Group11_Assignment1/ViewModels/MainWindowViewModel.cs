using Group11_Assignment1.Models;
using Group11_Assignment1.ViewModels;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Group11_Assignment1
{
    public class MainWindowViewModel : BindableBase
    {
        private ObservableCollection<DebitersCreditors> debitersCreditors;


        public MainWindowViewModel()
        {
            debitersCreditors = new ObservableCollection<DebitersCreditors>
            {

                new DebitersCreditors("Lucas", 500),
                new DebitersCreditors("Caroline", 300)
            };
            CurentDebitersCreditors = null;

            IsDebiterOrCreditor = new ObservableCollection<string>
            {
                "Is a debitor",
                "Is a creditor"
            };
        }
       
        #region Properties
        public ObservableCollection<DebitersCreditors> Debiters
        {
            get { return debitersCreditors; }
            set { SetProperty(ref debitersCreditors, value); }
        }

        DebitersCreditors curentDebitersCreditors = null;

        public DebitersCreditors CurentDebitersCreditors
        {
            get 
            { 
                return CurentDebitersCreditors; 
            }
            set
            {
                SetProperty(ref curentDebitersCreditors, value);
            }
        }

        ObservableCollection<string> isDebiterOrCreditor;
        public ObservableCollection<string> IsDebiterOrCreditor
        {
            get { return isDebiterOrCreditor; }
            set
            {
                SetProperty(ref isDebiterOrCreditor, value);
            }
        }

        #endregion

        #region commands
        ICommand newDebitersCreditorsCommand;
        public ICommand AddDebitersCreditorsCommand
        {

            get
            {
                return newDebitersCreditorsCommand ?? (newDebitersCreditorsCommand = new DelegateCommand(() =>
                {
                 var newDebitersCreditors = new DebitersCreditors();
                    var debitersCreditersView = new DebtorsCreditorsView(DateTime.Now, "amount", newDebitersCreditors)
                    {
                        IsDebiterOrCreditor = isDebiterOrCreditor                
                    };

                 var dlg = new DebitersWindow
                    {
                        DataContext = debitersCreditersView
                    };
                if (dlg.ShowDialog() == true)
                {
                    Debiters.Add(newDebitersCreditors);
                    CurentDebitersCreditors = newDebitersCreditors;
                }
            }));
            }
        }

        #endregion
    }
}
