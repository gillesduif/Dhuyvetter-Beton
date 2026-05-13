using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace BL
{
    [FirestoreData]
    public class SMS
    {
        [FirestoreProperty]
        public string id { get; set; }
        [FirestoreProperty]
        public string bericht { get; set; }
        public override string ToString()
        {
            return "SMS bericht";
        }
    }
}
