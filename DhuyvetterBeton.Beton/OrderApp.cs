using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhuyvetterBeton.Beton
{
    [FirestoreData]
    public class OrderApp
    {
        [FirestoreProperty]
        public string klant { get; set; }
        [FirestoreProperty]
        public string werf { get; set; }
        [FirestoreProperty]
        public string product { get; set; }
        [FirestoreProperty]
        public string aantal { get; set; }
        [FirestoreProperty]
        public int datum { get; set; }
        [FirestoreProperty]
        public string leveringMethode{ get; set; }
        [FirestoreProperty]
        public string losMethode { get; set; }
        [FirestoreProperty]
        public string opmerking { get; set; }
    }
}
