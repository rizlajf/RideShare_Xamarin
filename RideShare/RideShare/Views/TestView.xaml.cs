using RideShare.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RideShare.Views
{
    public partial class TestView : ContentPage
    {
        //public TestView()
        //{
        //    InitializeComponent();
        //    this.BindingContext = new TestViewModel(this.Navigation);
        //}

        public TestView(string msg)
        {
            InitializeComponent();
            this.BindingContext = new TestViewModel(msg);
        }
    }
}
