using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Pages.Handheld
{
    [INotifyPropertyChanged]
    [QueryProperty("Order", "Order")]
    public partial class ReceiptViewModel
    {
        [ObservableProperty]
        Order order;

        [RelayCommand]
        async void Done()
        {
            await Shell.Current.GoToAsync("///orders");
        }
    }
}
