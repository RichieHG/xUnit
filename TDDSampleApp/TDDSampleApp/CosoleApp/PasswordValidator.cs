using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CosoleApp
{
    public class PasswordValidator : IPasswordValidator
    {
        public bool Validate(string password)
        {
            if (password.Length >= 8 && password.Any(x => char.IsUpper(x))) return true;
            else return false;
        }
    }
}
