using Google.Cloud.Firestore;
using System;

public class MixedBoolConverter : FirestoreConverter<bool?>
{
    // Called when reading Firestore data --> C# property
    public override bool? FromFirestore(object value)
    {
        // Firestore might give us a bool or a string
        if (value is bool b)
        {
            return b; // no conversion needed
        }
        if (value is string s)
        {
            // handle "Yes"/"No" or "True"/"False"
            if (s.Equals("Yes", StringComparison.OrdinalIgnoreCase)) return true;
            if (s.Equals("No", StringComparison.OrdinalIgnoreCase)) return false;

            // also handle "true"/"false" if that might appear
            if (bool.TryParse(s, out bool boolResult))
            {
                return boolResult;
            }
        }
        // If it's not a bool or recognized string, return null
        return null;
    }

    // Called when saving the C# property --> Firestore
    public override object ToFirestore(bool? value)
    {
        // If we prefer always storing a real Boolean in Firestore:
        // If the property is null, store null; else store a bool
        if (value == null)
            return null; // Firestore will store null
        else
            return value.Value; // store it as a bool
    }
}
