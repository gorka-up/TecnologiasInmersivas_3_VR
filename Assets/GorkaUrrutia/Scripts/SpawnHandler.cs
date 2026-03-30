using System.Collections;
using UnityEngine;
using static GameManager;

public class SpawnHandler : MonoBehaviour
{
    [Header("Type of Blocks")]
    [SerializeField] GameObject normalBlock;
    [SerializeField] GameObject badBlock;

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
            switch (PlayerPrefs.GetInt("selectedLevel"))
            {
                case 1:
                    SpawnBlock(normalBlock);
                    break;
                case 2:
                    float random = Random.value;

                    if (random < 0.8f)
                    {
                        SpawnBlock(normalBlock);
                    }
                    else
                    {
                        SpawnBlock(badBlock);
                    }
                    break;
                default:
                    SpawnBlock(normalBlock);
                    break;
            }
            accumTime -= genTime;
        }
    }

    public void SpawnBlock(GameObject block)
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

        Vector3 dir = cam.position - spawnPos;
        dir.y = 0;
        dir.Normalize();

        cloneBlock.GetComponent<Rigidbody>().linearVelocity = dir * speed;

        StartCoroutine(DestroyMyBlock(cloneBlock));
    }

    IEnumerator DestroyMyBlock(GameObject block, int time = 8)
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
                break;
            case 1:
                speed = 6;
                genTime = 1.0f;
                offsetRange = 8;
                break;
            case 2:
                speed = 7;
                genTime = 0.5f;
                offsetRange = 10;
                break;
            default:
                speed = 5;
                genTime = 2.0f;
                offsetRange = 6;
                break;
        }
    }
}
