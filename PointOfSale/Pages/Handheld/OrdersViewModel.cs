using CommunityToolkit.Mvvm.ComponentModel;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Pages.Handheld
{
    [INotifyPropertyChanged]
    public partial class OrdersViewModel
    {
        [ObservableProperty]
        private ObservableCollection<Order> _orders;
        public OrdersViewModel()
        {
            _orders = new ObservableCollection<Order>(AppData.Orders);
        }
    }
}
