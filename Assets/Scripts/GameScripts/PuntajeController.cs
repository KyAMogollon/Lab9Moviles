using Firebase.Database;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
    private DatabaseReference databaseReference;

    void Start()
    {
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void SaveScore(string playerName, int score)
    {
        string key = databaseReference.Child("scores").Push().Key;
        ScoreEntry scoreEntry = new ScoreEntry(playerName, score);
        string json = JsonUtility.ToJson(scoreEntry);
        databaseReference.Child("scores").Child(key).SetRawJsonValueAsync(json);
    }

    public void GetTopScores(int topN)
    {
        databaseReference.Child("scores").OrderByChild("score").LimitToLast(topN).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                List<ScoreEntry> topScores = new List<ScoreEntry>();
                foreach (DataSnapshot data in snapshot.Children)
                {
                    string json = data.GetRawJsonValue();
                    ScoreEntry scoreEntry = JsonUtility.FromJson<ScoreEntry>(json);
                    topScores.Add(scoreEntry);
                }
                topScores = topScores.OrderByDescending(x => x.score).ToList();
                foreach (var score in topScores)
                {
                    Debug.Log($"Jugador: {score.playerName}, Puntuación: {score.score}");
                }
            }
        });
    }
}

[System.Serializable]
public class ScoreEntry
{
    public string playerName;
    public int score;

    public ScoreEntry(string playerName, int score)
    {
        this.playerName = playerName;
        this.score = score;
    }
}
