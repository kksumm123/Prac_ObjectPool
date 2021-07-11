using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    GameObject sphere;
    BoxCollider boxCol;
    [SerializeField] string sphereString = "Sphere";
    [SerializeField] float randX = 10;
    [SerializeField] float calcY = -5;
    [SerializeField] float randZ = 10;
    void Start()
    {
        sphere = (GameObject)Resources.Load(sphereString);
        boxCol = GetComponent<BoxCollider>();
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            Vector3 pos = transform.position;
            pos.x += Random.Range(-randX, randX);
            pos.y += calcY;
            pos.z += Random.Range(-randZ, randZ);
            ObjectPool.instance.InstantiateOP(sphere, pos, transform.rotation);
        }
    }
}
