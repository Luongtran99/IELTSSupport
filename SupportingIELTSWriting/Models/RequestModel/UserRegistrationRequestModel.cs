using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models.RequestModel
{
    
    public class UserRegistrationRequestModel
    { 
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRegistrationRequestModel()
        {
            // init
            // check password

        }

        public bool RegisterRequestValidation()
        {
            string bufEmail = "";
            string bufPassword = "";

            bufEmail = Email;
            bufPassword = Password;

            // validation return;
            // email regex

            return false;

        }

    }
}
