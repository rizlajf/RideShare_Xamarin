using RideShare.Models;
using RideShare.Views;
using System;
using RideShare;
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
        public ICommand OnLabelClickedCommand { get; set; }
        private INavigation _navigation;

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

        
        public LoginViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _userType = Convert.ToString(UserTypeEnum.rider);
            RiderImageSource = ImageSource.FromResource("RideShare.Assets.login.userLogActive_icon.png");
            DriverImageSource = ImageSource.FromResource("RideShare.Assets.login.driverLog_icon.png");
            TapCommand = new Command<string>(OnTapped);
            LoginCommand = new Command(UserLogin);
            RegisterCommand = new Command(UserRegister);
            OnLabelClickedCommand = new Command(OnLabelClick);

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

            test(user);
            
        }

        public async void UserRegister()
        {
            await _navigation.PushAsync(new Register(_userType));
        }

        public void OnLabelClick()
        {
            
        }

        public IList<User> userList { get; set; }

        public async void test(User user)
        {
            List<dynamic> responses = ServiceRequest.GetUsers();
           
            foreach (dynamic response in responses)
            {
                User us = new User();
                //us = response.users;
                userList.Add(us);
            }

            var stringList = userList.OfType<string>();
            string stringlist = stringList.ToString();
            //string msg = ServiceRequest.gettestResponse(user);

            // string msg = ServiceRequest.Login(user);

            //Response rs = ServiceRequest.Login(user);
            //string msg = rs.Token;

            if (!String.IsNullOrEmpty(stringlist))
            {
                await _navigation.PushAsync(new TestView(stringlist));
            }
        }

    }
}
