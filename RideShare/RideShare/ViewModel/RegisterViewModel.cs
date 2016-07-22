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
    public class RegisterViewModel : ViewModelBase
    {
        /// <summary>
		/// Expose the '' via a property so that Xaml can bind to it
		/// </summary>
        private string _firstName;
        private string _lastName;
        private string _userName;
        private string _email;
        private string _password;
        private string _userType;

        public ICommand CreateCommand { get; set; }
        private INavigation _navigation;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyPropertyChaged("FirstName");
            }

        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyPropertyChaged("LastName");
            }

        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyPropertyChaged("UserName");
            }

        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                NotifyPropertyChaged("Email");
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

        public RegisterViewModel(INavigation navigation)
        {
            _navigation = navigation;
            CreateCommand = new Command(UserRegister);
        }

        public RegisterViewModel(string info, INavigation navigation)
        {
            _navigation = navigation;
            _userType = info;
            CreateCommand = new Command(UserRegister);
        }

        public async void UserRegister()
        {
            var user = new User()
            {
                UserName = this.UserName,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                Password = this.Password,
                UserType = this._userType
            };

            Response rs = ServiceRequest.Register(user);
            if (!String.IsNullOrEmpty(rs.message))
            {
                await _navigation.PushAsync(new TestView(rs.message));
            }
            else
            {
                await _navigation.PushAsync(new TestView(rs.Token));
            }
        }

    }
}
