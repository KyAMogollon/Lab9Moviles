using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    protected List<GameObject> objectsPool;
    public GameObject[] objPref;
    // Start is called before the first frame update
    public virtual void Awake()
    {
        objectsPool = new List<GameObject>();
    }
}
