using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolDinamic : ObjectPool
{
    // Start is called before the first frame update
    public override void Awake()
    {
        base.Awake();
    }

    public void GetObject(Vector3 origin)
    {
        GameObject tmp;
        if (objectsPool.Count > 0)
        {
            tmp = objectsPool[0];
            objectsPool.Remove(tmp);
            tmp.transform.position = origin + Vector3.right * 0.7f;
            tmp.SetActive(true);
        }
        else
        {
            tmp = Instantiate(objPref[Random.Range(0, objPref.Length)], origin + Vector3.right * 0.7f, Quaternion.identity);
            //tmp.GetComponent<BulletController>().SetDinamicPool(this);
            tmp.transform.SetParent(this.transform);
            tmp.SetActive(true);
        }
    }
    public void SetObject(GameObject obj)
    {
        obj.SetActive(false);
        objectsPool.Add(obj);
    }
}
