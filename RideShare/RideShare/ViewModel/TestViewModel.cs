using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.ViewModel
{
    public class TestViewModel
    {
        private string _msg { get; set; }

        public string msg
        {
            get { return _msg; }
            set
            {
                _msg = value;
            }
        }

        //public TestViewModel()
        //{

        //}

        public TestViewModel(string mSg)
        {
            _msg = mSg;
        }
    }
}
