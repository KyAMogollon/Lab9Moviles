using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolStatic : ObjectPool
{
    public int maxQuantity;
    private static ObjectPoolStatic instance;
    public static ObjectPoolStatic Instance {  get { return instance; } }
    public override void Awake()
    {
        base.Awake();
        if (instance == null)
        {
            instance = this;
        }else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        InstantiateObjects();
    }

    public void InstantiateObjects()
    {
        GameObject tmp;
        for (int i = 0; i < maxQuantity; i++)
        {
            tmp = Instantiate(objPref[Random.Range(0,objPref.Length)], transform.position, Quaternion.identity);
            objectsPool.Add(tmp);
            tmp.transform.SetParent(this.transform);
            tmp.SetActive(false);
        }
    }
    public GameObject RequestBullet()
    {
        for (int i = 0; i < objectsPool.Count; i++)
        {
            if (!objectsPool[i].activeSelf)
            {
                objectsPool[i].SetActive(true);
                return objectsPool[i];
            }
        }
        return null;
    }
}
