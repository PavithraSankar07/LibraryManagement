using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Models;

namespace LibraryManagement
{
    public class UserStateService
    {
        public UserDetails? CurrentUser { get; set; }

        public void SetUser(UserDetails user) => CurrentUser = user;

        public void ClearUser() => CurrentUser = null;
        public bool IsLoggedIn => CurrentUser != null;
    }
}