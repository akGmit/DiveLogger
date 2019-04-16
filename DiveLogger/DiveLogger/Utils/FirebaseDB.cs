using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiveLogger.Utils
{
    
    class FirebaseDB
    {
        private const string BaseDBUri = "https://diveloggerapp.firebaseio.com";

        public FirebaseClient InitFirebaseClient()
        {
            return new FirebaseClient(BaseDBUri, new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => AuthAsync()
            });
        }

        private Task<string> AuthAsync()
        {
            FireBaseAuthUtil auth = new FireBaseAuthUtil();
            return auth.Login("inti", "init");
        }
    }
}
