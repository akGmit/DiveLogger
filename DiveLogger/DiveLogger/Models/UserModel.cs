using DiveLogger.Models;
using DiveLogger.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace DiveLogger.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<DiveLogModel> DiveLogs { get; set; } = new List<DiveLogModel>();
        public DiveLogModel[] userDiveLogsArrr { get; set; }
        public static UserModel user = new UserModel(UserName, Password, DiveLogs);

        //public UserModel(string userName, string password)
        //{
        //    UserName = userName;
        //    Password = password;

        //}

        public UserModel(string UserName, string Password, List<DiveLogModel> diveLogs)
        {
            this.UserName = UserName;
            this.Password = Password;
            DiveLogs = diveLogs;
            //this.userDiveLogsArrr = DiveLogs;
        }

        public void StoreUserDetails()
        {
            user = new UserModel(UserName, Password, DiveLogs);
            Preferences.Set("UserName", UserName);
            Preferences.Set("Password", Password);
            Preferences.Set("Valid", "true");
        }

        public static void SetUserDiveLog(DiveLogModel diveLog)
        {
            user = DBCollection.GetUserDocFromDB(user);
            user.DiveLogs.Add(diveLog);
            DBCollection.UpdateUser(user);
        }
    }
}
