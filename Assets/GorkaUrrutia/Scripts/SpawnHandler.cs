using System.Collections;
using UnityEngine;
using static GameManager;

public class SpawnHandler : MonoBehaviour
{
    [Header("Type of Blocks")]
    [SerializeField] GameObject normalBlock;
    [SerializeField] GameObject badBlock;
    [SerializeField] GameObject upBlock;
    [SerializeField] GameObject downBlock;
    [SerializeField] GameObject leftBlock;
    [SerializeField] GameObject rigthBlock;


    [Header("Spawn parameters")]
    [SerializeField] public float offsetRange;
    [SerializeField] public float spawnDistance;

    [Header("Block Spawn Parameters")]
    [SerializeField] public float speed;
    [SerializeField] public float genTime;

    private float accumTime;

    private void Start()
    {
        accumTime = 0.0f;
        GetDificulty();
    }
    public void SpawnBlocks()
    {
        accumTime += Time.deltaTime;
        while (accumTime >= genTime)
        {
            float random = Random.value;

            if (random < 0.8f)
            {
                GenerateBlock(normalBlock);
            }
            else
            {
                GenerateBlock(badBlock);
            }
            accumTime -= genTime;
        }
    }

    public  void SpawnBlocks2()
    {
        accumTime += Time.deltaTime;
        while (accumTime >= genTime)
        {
            float random = Random.value;

            if (random < 0.65f)
            {
                GenerateBlock(normalBlock);
            }
            else
            {
                GenerateBlock(badBlock);
            }
            accumTime -= genTime;
        }
    }

    public void SpawnBlocks3()
    {
        accumTime += Time.deltaTime;
        while (accumTime >= genTime)
        {
            float random = Random.value;

            if (random < 0.27f)
            {
                GenerateBlock(badBlock);
            }
            else if (random < 0.27f)
            {
                GenerateBlock(upBlock);
            }
            else if (random < 0.52f)
            {
                GenerateBlock(downBlock);
            }
            else if (random < 0.77f)
            {
                GenerateBlock(leftBlock);
            }
            else
            {
                GenerateBlock(rigthBlock);
            }
            accumTime -= genTime;
        }
    }

    public void GenerateBlock(GameObject block)
    {
        Transform cam = Camera.main.transform;

        float offset = Random.Range(-offsetRange, offsetRange);

        Vector3 forward = cam.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 spawnPos = cam.position + forward * spawnDistance;

        spawnPos += cam.right * offset;
        spawnPos.y = cam.position.y;

        GameObject cloneBlock = Instantiate(block, spawnPos, Quaternion.identity);

        cloneBlock.transform.LookAt(cam.position);

        Vector3 dir = cam.position - spawnPos;
        dir.y = 0;
        dir.Normalize();

        cloneBlock.GetComponent<Rigidbody>().linearVelocity = dir * speed;

        StartCoroutine(DestroyMyBlock(cloneBlock));
    }

    IEnumerator DestroyMyBlock(GameObject block, int time = 10)
    {
        yield return new WaitForSeconds(time);
        if (block != null ) Destroy(block);
    }

    public void GetDificulty()
    {
        switch (PlayerPrefs.GetInt("dificulty"))
        {
            case 0:
                speed = 5;
                genTime = 2.0f;
                offsetRange = 6;
                spawnDistance = 10;
                break;
            case 1:
                speed = 6;
                genTime = 1.5f;
                offsetRange = 8;
                spawnDistance = 10;
                break;
            case 2:
                speed = 6;
                genTime = 1f;
                offsetRange = 10;
                spawnDistance = 10;
                break;
            default:
                speed = 5;
                genTime = 2.0f;
                offsetRange = 6;
                spawnDistance = 10;
                break;
        }
    }
}
