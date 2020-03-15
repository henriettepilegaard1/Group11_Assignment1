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
using Group11_Assignment1.Views;

namespace Group11_Assignment1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private ObservableCollection<Person> persons = new ObservableCollection<Person> {};
        private Person currentPerson = null;

        public MainWindowViewModel()
        {
            EditPersonCommand = new DelegateCommand(EditPersonCommand_Execute, EditPersonCommand_CanExecute)
                .ObservesProperty(() => CurrentPerson);
        }

        #region Properties
        public ObservableCollection<Person> Persons
        {
            get { return persons; }
            set { SetProperty(ref persons, value); }
        }

        public Person CurrentPerson
        {
            get => currentPerson;
            set => SetProperty(ref currentPerson, value);
        }

        #endregion

        #region commands

        private bool EditPersonCommand_CanExecute()
        {
            return CurrentPerson.IsValid;
        }

        private void EditPersonCommand_Execute()
        {
            
            var dialog = new PersonView()
            {
                DataContext = new PersonViewModel
                {
                    Amount = string.Empty,
                    Person = CurrentPerson,
                },
            };

            dialog.ShowDialog();
        }

        public ICommand EditPersonCommand { get; private set; }
        
        ICommand newPersonCommand;
        public ICommand AddPersonCommand
        {

            get
            {
                return newPersonCommand ?? (newPersonCommand = new DelegateCommand(() =>
                {
                    var person = new Person();
                    var personViewModel = new PersonViewModel()
                    {
                                 
                    };

                 var dlg = new MainWindow()
                    {
                        DataContext = personViewModel
                    };
                if (dlg.ShowDialog() == true)
                {
                    Persons.Add(person);
                    CurrentPerson = person;
                }
                }));
            }
        }

        #endregion
    }

    public class MainWindowViewModelDesign : MainWindowViewModel
    {
        public MainWindowViewModelDesign() : base()
        {
            var person = new Person { Name = "Demo 1" };
            person.AddTransaction(new Transaction { Date = DateTime.Now.AddDays(-10), Amount = 30 });
            person.AddTransaction(new Transaction { Date = DateTime.Now.AddDays(-5), Amount = -750 });
            person.AddTransaction(new Transaction { Date = DateTime.Now.AddDays(-2), Amount = 512 });
            Persons.Add(person);

            person = new Person { Name = "Demo 2" };
            person.AddTransaction(new Transaction { Date = DateTime.Now.AddDays(-11), Amount = 330 });
            person.AddTransaction(new Transaction { Date = DateTime.Now.AddDays(-3), Amount = -50 });
            person.AddTransaction(new Transaction { Date = DateTime.Now.AddDays(-1), Amount = 12 });
            Persons.Add(person);
        }
    }
}
