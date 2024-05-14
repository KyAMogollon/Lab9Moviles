using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandController : MonoBehaviour
{
    [SerializeField] Transform[] target; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateANewPlatform()
    {
        GameObject platform = ObjectPoolStatic.Instance.RequestBullet();
        platform.transform.position = target[Random.Range(0, target.Length)].position;
    } 
}
