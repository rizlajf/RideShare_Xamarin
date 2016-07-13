using RideShare.Models;
using RideShare.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RideShare.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {

        public enum UserTypeEnum
        {
            driver,
            rider
        }

        /// <summary>
		/// Expose the '' via a property so that Xaml can bind to it
		/// </summary>
        private string _userName;
        private string _password;
        private string _userType;

        public ImageSource RiderImageSource { get; private set; }
        public ImageSource DriverImageSource { get; private set; }

        /// <summary>
		/// Expose the Commands via a property so that Xaml can bind to it
		/// </summary>
        public ICommand TapCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        //private INavigation navigation;

        public string UserName
        {
            get { return _userName; }
            set {
                _userName = value;
                NotifyPropertyChaged("UserName");
            }
            
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyPropertyChaged("Password");
            }

        }     

        
        public LoginViewModel()
        {
            _userType = Convert.ToString(UserTypeEnum.rider);
            RiderImageSource = ImageSource.FromResource("RideShare.Assets.login.userLogActive_icon.png");
            DriverImageSource = ImageSource.FromResource("RideShare.Assets.login.driverLog_icon.png");
            TapCommand = new Command<string>(OnTapped);
            LoginCommand = new Command(UserLogin);
            RegisterCommand = new Command(UserRegister);

        }

        /// <summary>
		/// Called whenever TapCommand is executed (because it was wired up in the constructor)
		/// </summary>
        public void OnTapped(string info)
        {
            if (info == "Rider")
            {
                RiderImageSource = ImageSource.FromResource("RideShare.Assets.login.userLogActive_icon.png");
                DriverImageSource = ImageSource.FromResource("RideShare.Assets.login.driverLog_icon.png");
                _userType = Convert.ToString(UserTypeEnum.rider);
            }
            else
            {
                RiderImageSource = ImageSource.FromResource("RideShare.Assets.login.userLog_icon.png");
                DriverImageSource = ImageSource.FromResource("RideShare.Assets.login.driverLogActive_icon.png");
                _userType = Convert.ToString(UserTypeEnum.driver);
            }
            NotifyPropertyChaged("RiderImageSource");
            NotifyPropertyChaged("DriverImageSource");
        }

        public void UserLogin()
        {
            var user = new User()
            {
                UserName = this.UserName,
                Password = this.Password,
                UserType = this._userType
            };
        }

        public async void UserRegister()
        {
            //NavigationPage NavigationPage = new NavigationPage(new Register());
            await Navigation.PushAsync(new Register());
        }
    }
}
