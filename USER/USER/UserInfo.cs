using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USER
{
    class UserInfo
    {
        private List<String> userName = new List<string>();
        private List<String> userAddress = new List<string>();
        private List<String> userEmail = new List<string>();
        private List<String> userPassword = new List<string>();
        public List<String> checkUserName = new List<string>();

        public UserInfo(List<String> _userName, List<String> _userAddress, List<String> _userPassword, List<String> _userEmail)
        {
            this.userName = _userName;
            this.userAddress = _userAddress;
            this.userPassword = _userPassword;
            this.userEmail = _userEmail;
        }


        public List<string> _userName
        {
            get
            {
                return userName;
            }

        }
        public List<string> _userAddress
        {
            get
            {
                return userAddress;
            }

        }
        public List<string> _userPassword
        {
            get
            {
                return userPassword;
            }

        }
        public List<string> _userEmail
        {
            get
            {
                return userEmail;
            }

        }



    }
}
