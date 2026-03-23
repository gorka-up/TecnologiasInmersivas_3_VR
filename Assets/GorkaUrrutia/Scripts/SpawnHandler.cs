using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    GameObject block;

    float offsetRange = 5;

    Vector3 spawnPos;

    void Start()
    {
        
    }

    void SpawnBlocks()
    {
        float offSet = Random.Range(-offsetRange, offsetRange);
        Vector3 direction = (new Vector3(Camera.main.transform.position.x + offSet, Camera.main.transform.position.y, Camera.main.transform.position.z) -  spawnPos).normalized;
    }
}
