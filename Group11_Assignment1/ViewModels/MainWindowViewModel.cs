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
using Group11_Assignment1.Models;

namespace Group11_Assignment1
{
    public class MainWindowViewModel : BindableBase
    {
        private ObservableCollection<DebtersCreditors> debtersCreditors;
        private readonly string AppTitle = "The Dept Book";


        public MainWindowViewModel()
        {
            debtersCreditors = new ObservableCollection<DebtersCreditors>
            {
                new DebtersCreditors("Lucas", 500),
                new DebtersCreditors("Caroline", -240)
            };
            CurentDebtersCreditors = null;
        }


        DebtersCreditors curentDebtersCreditors;
        
        

        public DebtersCreditors CurentDebtersCreditors
        {
            get { return CurentDebtersCreditors; }
            set
            {
                SetProperty(ref curentDebtersCreditors, value);
            }
        }
    }
}
