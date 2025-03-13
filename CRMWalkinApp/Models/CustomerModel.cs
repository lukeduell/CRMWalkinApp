using Google.Cloud.Firestore;

namespace CRMWalkinApp.Models
{
    [FirestoreData]
    public class CustomerModel
    {
        [FirestoreDocumentId]
        public string Id { get; set; }

        [FirestoreProperty("firstandlast")]
        public string FirstAndLast { get; set; }

        [FirestoreProperty("phonenum")]
        public string PhoneNumber { get; set; }

        [FirestoreProperty("date")]
        public DateTime DateArrived { get; set; }

        [FirestoreProperty("blast", ConverterType = typeof(MixedBoolConverter))]
        public bool? Blast { get; set; }

        [FirestoreProperty("color")]
        public string Color { get; set; }

        [FirestoreProperty("description")]
        public string Description { get; set; }

        [FirestoreProperty("notes")]
        public string Notes { get; set; }

        [FirestoreProperty("prime")]
        public string Prime { get; set; }

        [FirestoreProperty("status")]
        public bool Status { get; set; }
    }

}
