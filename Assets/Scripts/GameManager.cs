using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] PlayerSO player;
    [SerializeField] TMP_Text tmp_text;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        tmp_text.text = "Puntaje: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetNickName()
    {
        player.NickName = textMeshProUGUI.text;
        FireBaseConnection.Instance.Upload();
    }
    public void NewScore()
    {
        player.puntajeActual = score;
        FireBaseConnection.Instance.Upload();
    }
    public void SetScore(int puntaje)
    {
        score += puntaje;
        tmp_text.text = "Puntaje: " + score; 
    }
}
