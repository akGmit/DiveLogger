using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiveLogger.Utils
{
    class FireBaseAuthUtil
    {
        private FirebaseAuthLink _authLink;
        private const string FireBaseApiKey = "AIzaSyBAIgNK3AWlsBYjEeGOuqBiDiy001ue_cU";
        private FirebaseAuthProvider authProvider;

        private void InitFirebaseAuth()
        {
            authProvider = new FirebaseAuthProvider(new FirebaseConfig(FireBaseApiKey));
        }
        /// <summary>
        /// FireBase authentication.
        /// Initialize Auth Provider, check if auth token is in local storage.
        /// If yes, get FireBaseAuth link, recieve fresh token and return.
        /// </summary>
        /// <param name="email">String representing users email</param>
        /// <param name="pass">String representing user password</param>
        /// <returns></returns>
        public async Task<string> Login(string email, string pass)
        {
            InitFirebaseAuth();
            //Check if token is available
            FirebaseAuth auth = LoadFirebaseAuth();
            if (auth != null)
            {
                _authLink = new FirebaseAuthLink(authProvider, auth);
            }
            else
            {
                // If not, login and save it locally for next time.
                _authLink = await authProvider.SignInWithEmailAndPasswordAsync(email, pass);
                SaveFirebaseAuth(_authLink);
            }

            // Save the auth object/token every time it's refreshed.
            _authLink.FirebaseAuthRefreshed += (s, e) => SaveFirebaseAuth(e.FirebaseAuth);

            _authLink = await _authLink.GetFreshAuthAsync();

            return _authLink.FirebaseToken;
        }
        /// <summary>
        /// Register with FireBase Auth method.
        /// Initialize FireBase Auth provider.
        /// Create user with provided email and password.
        /// Save response, get fresh token and return it.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public async Task<string> Register(string email, string pass)
        {
            InitFirebaseAuth();

            _authLink = await authProvider.CreateUserWithEmailAndPasswordAsync(email, pass);
            SaveFirebaseAuth(_authLink);

            _authLink.FirebaseAuthRefreshed += (s, e) => SaveFirebaseAuth(e.FirebaseAuth);

            _authLink = await _authLink.GetFreshAuthAsync();

            return _authLink.FirebaseToken;
        }

        private FirebaseAuth LoadFirebaseAuth()
        {
            string json = Settings.FirebaseAuthJson;
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<FirebaseAuth>(json);
            }
        }

        private void SaveFirebaseAuth(FirebaseAuth auth)
        {
            string json = JsonConvert.SerializeObject(auth);
            Settings.FirebaseAuthJson = json;
        }
    }
}
