using RideShare.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RideShare.Views
{
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
            this.BindingContext = new RegisterViewModel();
        }

        public Register(string userType)
        {
            InitializeComponent();
            this.BindingContext = new RegisterViewModel(userType);
        }
    }
}
