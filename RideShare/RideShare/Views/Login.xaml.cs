using RideShare.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RideShare.Views
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel(this.Navigation);
        }
    }
}
