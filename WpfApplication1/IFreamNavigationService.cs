// ==========================================
// Author                  :    WIN-JH13BJM99UM 
// Create Time           :    2016/8/4 13:22:44
// Update Time          :    2016/8/4 13:22:44
// ==========================================
// Class Description     :    
// ==========================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;

namespace WpfApplication1
{
    public interface IFreamNavigationService : INavigationService
    {
        object Parameter { get; set; }
    }
}
