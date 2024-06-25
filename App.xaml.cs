﻿using DevExpress.Xpf.Grid;
using System.Configuration;
using System.Data;
using System.Windows;
using Application = System.Windows.Application;

namespace CRM_App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            GridControl.AllowInfiniteGridSize = true;
        }
    }

}
