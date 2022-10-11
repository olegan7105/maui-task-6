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
    public partial class PayViewModel
    {
        [ObservableProperty]
        Order order;

        [RelayCommand]
        async void Pay()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                {"Order", order }
            };
            await Shell.Current.GoToAsync($"{nameof(SignaturePage)}", navigationParameter)
        }
    }
}
