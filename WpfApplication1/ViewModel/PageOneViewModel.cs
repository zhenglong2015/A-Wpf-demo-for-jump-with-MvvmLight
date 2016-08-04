// ==========================================
// Author                  :  ZTB 
// Create Time           :    2016/8/4 11:59:02
// ==========================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Views;

namespace WpfApplication1.ViewModel
{
    public class PageOneViewModel 
    {

        public PageOneViewModel(IFreamNavigationService navigationService)
        {
            var aa = navigationService.Parameter;

        }
    }
}
