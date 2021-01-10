using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamicForms.Web.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsInvalid { get; set; }

    }
}