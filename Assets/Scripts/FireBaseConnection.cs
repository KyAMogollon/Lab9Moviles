using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBaseConnection : MonoBehaviour
{
    [SerializeField] public DataBaseManager dataBaseManager;
    private static FireBaseConnection instance;
    public static FireBaseConnection Instance { get { return instance; } }
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        dataBaseManager.AwakeID();
        dataBaseManager.StartFireBase();

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    public void Upload()
    {
        Debug.Log("Subiendo al firebase");
        dataBaseManager.UploadDataBase();
    }
    public void DescargarPlayer(Action onCallbacks)
    {
        StartCoroutine(dataBaseManager.GetName(onCallbacks));
    }
}
