using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/Jugador")]
public class PlayerSO : ScriptableObject
{
    public string NickName;
    public int puntajeActual;
    public int nuevoRecord;
}
