using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using System;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/Firebase")]
public class DataBaseManager : ScriptableObject
{
    [SerializeField] private string userID;
    [SerializeField] PlayerSO player;
    private DatabaseReference reference;
    public SaveData dataSave;
    public void AwakeID()
    {
        userID = SystemInfo.deviceUniqueIdentifier;
    }
    public void StartFireBase()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        dataSave = new SaveData();
    }
    public void UploadDataBase()
    {
        string json = JsonUtility.ToJson(player);
        reference.Child("Jugador").Child(userID).Child(player.NickName).SetRawJsonValueAsync(json);
    }
    public IEnumerator GetName(Action onCallback)
    {
        var studentNameData = reference.Child("Jugador").Child(userID).Child(player.NickName).GetValueAsync();
        yield return new WaitUntil(predicate: () => studentNameData.IsCompleted);
        Debug.Log("FUNCIONA");
        DataSnapshot snapshot = studentNameData.Result;
        string json = snapshot.GetRawJsonValue();
        if(json != null)
        {
            dataSave= JsonUtility.FromJson<SaveData>(json);
            onCallback?.Invoke();
        }
    }

}
[System.Serializable]
public class SaveData
{
    public string NickName;
    public int puntajeActual;
    public int nuevoRecord;
    public SaveData()
    {
        NickName = "A";
        puntajeActual = 4;
        nuevoRecord = 5;
    }
}

