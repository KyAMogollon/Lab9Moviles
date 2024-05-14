using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class PuntajeController : MonoBehaviour
{
    [SerializeField] PlayerSO player;
    [SerializeField] TMP_Text currentPointsText;
    [SerializeField] TMP_Text PointsText1;
    [SerializeField] TMP_Text PointsText2;
    [SerializeField] TMP_Text PointsText3;
    [SerializeField] TMP_Text PointsText4;
    [SerializeField] TMP_Text PointsText5;
    [SerializeField] TMP_Text NuevoRecordText;
    // Start is called before the first frame update
    void Start()
    {
        currentPointsText.text = "Puntaje Actual: " + player.puntajeActual;
        Debug.Log(player.nuevoRecord);
        if (player.nuevoRecord == 0 || player.puntajeActual > player.nuevoRecord)
        {
            NuevoRecordText.gameObject.SetActive(true);
            player.nuevoRecord = player.puntajeActual;
            NuevoRecordText.text = "NuevoRecord: " + player.nuevoRecord;
            
        }
        FireBaseConnection.Instance.Upload();
        FireBaseConnection.Instance.DescargarPlayer(PrintPlayer);
    }
    private void PrintPlayer()
    {
        PointsText1.text = "Nombre: " + FireBaseConnection.Instance.dataBaseManager.dataSave.NickName + " tiene " + FireBaseConnection.Instance.dataBaseManager.dataSave.nuevoRecord;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
