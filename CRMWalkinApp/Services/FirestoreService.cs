using Google.Cloud.Firestore;
using CRMWalkinApp.Models;
using CRMWalkinApp.Services;

public class FirestoreService: IFirestoreService
{
    private readonly FirestoreDb _db;

    public FirestoreService(string projectId, string serviceAccountPath)
    {
        if (!string.IsNullOrWhiteSpace(serviceAccountPath))
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", serviceAccountPath);
        }

        _db = FirestoreDb.Create(projectId);
    }

    public async Task AddEntryAsync(CustomerModel entry)
    {
        var collection = _db.Collection("CustomerCollection");
        await collection.AddAsync(entry);
    }

    public async Task<List<CustomerModel>> GetAllEntriesAsync()
    {
        var collection = _db.Collection("CustomerCollection");
        var snapshot = await collection.GetSnapshotAsync();
        return snapshot.Documents
                       .Select(d => d.ConvertTo<CustomerModel>())
                       .ToList();
    }

    public async Task<CustomerModel> GetByIdAsync(string docId)
    {
        var docRef = _db.Collection("CustomerCollection").Document(docId);
        var snapshot = await docRef.GetSnapshotAsync();
        return snapshot.Exists ? snapshot.ConvertTo<CustomerModel>() : null;
    }

    public async Task UpdateEntryAsync(CustomerModel entry)
    {
        if (string.IsNullOrEmpty(entry.Id)) return;
        var docRef = _db.Collection("CustomerCollection").Document(entry.Id);
        await docRef.SetAsync(entry, SetOptions.Overwrite);
    }

    public async Task DeleteEntryAsync(string docId)
    {
        var docRef = _db.Collection("CustomerCollection").Document(docId);
        await docRef.DeleteAsync();
    }

}
