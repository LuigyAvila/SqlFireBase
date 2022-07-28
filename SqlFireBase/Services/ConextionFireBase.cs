using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;

namespace SqlFireBase.Services
{
    public class ConextionFireBase
    {
        public static FirebaseClient firebase = new FirebaseClient("https://usuarios-6f699-default-rtdb.europe-west1.firebasedatabase.app/");
    }
}
