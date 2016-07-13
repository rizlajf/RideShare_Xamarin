using RideShare.Models;
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

        public RegisterViewModel()
        {
            CreateCommand = new Command(UserRegister);
        }

        public RegisterViewModel(string info)
        {
            _userType = info;
            CreateCommand = new Command(UserRegister);
        }

        public void UserRegister()
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
        }

    }
}
