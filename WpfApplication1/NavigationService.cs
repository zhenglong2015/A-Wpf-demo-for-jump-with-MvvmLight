﻿// ==========================================
// Author                  :  ZTB 
// Create Time           :    2016/8/4 10:40:33
// ==========================================
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;

namespace WpfApplication1
{
    public class NavigationService : ViewModelBase, IFreamNavigationService
    {
        private readonly Dictionary<string, Uri> pagesByKey;
        private readonly List<string> historic;
        private string currentPageKey;
        #region Properties
        public string CurrentPageKey
        {
            get
            {
                return currentPageKey;
            }

            private set
            {
                Set(() => CurrentPageKey, ref currentPageKey, value);
            }
        }

        public object Parameter { get; set; }

        #endregion
        #region Ctors and Methods
        public NavigationService()
        {
            pagesByKey = new Dictionary<string, Uri>();
            historic = new List<string>();
        }
        public void GoBack()
        {
            if (historic.Count > 1)
            {
                historic.RemoveAt(historic.Count - 1);

                NavigateTo(historic.Last(), "Back");
            }
        }
        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, "Next");
        }

        public virtual void NavigateTo(string pageKey, object parameter)
        {
            lock (pagesByKey)
            {
                if (!pagesByKey.ContainsKey(pageKey))
                {
                    throw new ArgumentException(string.Format("No such page: {0} ", pageKey), "pageKey");
                }

                var frame = GetDescendantFromName(Application.Current.MainWindow, "MainFrame") as Frame;

                if (frame != null)
                {
                    frame.Source = pagesByKey[pageKey];
                }
                Parameter = parameter;
                if (parameter.ToString().Equals("Next"))
                {
                    historic.Add(pageKey);
                }
                CurrentPageKey = pageKey;
            }
        }

        public void Configure(string key, Uri pageType)
        {
            lock (pagesByKey)
            {
                if (pagesByKey.ContainsKey(key))
                {
                    pagesByKey[key] = pageType;
                }
                else
                {
                    pagesByKey.Add(key, pageType);
                }
            }
        }

        private static FrameworkElement GetDescendantFromName(DependencyObject parent, string name)
        {
            var count = VisualTreeHelper.GetChildrenCount(parent);

            if (count < 1)
            {
                return null;
            }

            for (var i = 0; i < count; i++)
            {
                var frameworkElement = VisualTreeHelper.GetChild(parent, i) as FrameworkElement;
                if (frameworkElement != null)
                {
                    if (frameworkElement.Name == name)
                    {
                        return frameworkElement;
                    }

                    frameworkElement = GetDescendantFromName(frameworkElement, name);
                    if (frameworkElement != null)
                    {
                        return frameworkElement;
                    }
                }
            }
            return null;
        }


        #endregion
    }
}
