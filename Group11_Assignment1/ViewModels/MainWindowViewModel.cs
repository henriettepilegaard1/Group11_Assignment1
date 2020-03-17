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
        private Person newPerson = null;

        public MainWindowViewModel()
        {
            EditPersonCommand = new DelegateCommand(EditPersonCommand_Execute, EditPersonCommand_CanExecute)
                .ObservesProperty(() => CurrentPerson);

            AddPersonCommand = new DelegateCommand(AddPersonCommand_Execute, AddPersonCommand_CanExecute);
            
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
        
        public ICommand AddPersonCommand { get; private set; }


        private bool AddPersonCommand_CanExecute() => true;

        private void AddPersonCommand_Execute()

        {

            var model = new Person();

            var viewmodel = new AddPersonViewModel(model, "", "");

            var view = new AddPersonView()
            {
                DataContext = viewmodel
            };
            
            if (view.ShowDialog() == true)
            {
                Persons.Add(model);
                CurrentPerson = model;
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
