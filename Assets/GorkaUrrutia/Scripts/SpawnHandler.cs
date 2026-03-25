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

    private bool start = false;

    private void Start()
    {
        accumTime = 0.0f;
    }
    public void SpawnBlocks()
    {
        if (start)
        {
            accumTime += Time.deltaTime;
            while (accumTime >= genTime)
            {
                SpawnBlock(normalBlock);
                accumTime -= genTime;
            }
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

    public void Ready()
    {
        StartCoroutine(SetStart());
    }

    IEnumerator SetStart()
    {
        WaitForSeconds wait = new WaitForSeconds(1);
        if (start)
        {
            start = !start;
        }
        yield return wait;
        GameManager.instance.countDownTMP.gameObject.SetActive(true);
        GameManager.instance.countDownTMP.text = "5";
        yield return wait;
        GameManager.instance.countDownTMP.text = "4";
        yield return wait;
        GameManager.instance.countDownTMP.text = "3";
        yield return wait;
        GameManager.instance.countDownTMP.text = "2";
        yield return wait;
        GameManager.instance.countDownTMP.text = "1";
        yield return wait;
        GameManager.instance.countDownTMP.gameObject.SetActive(false);
        start = !start;
    }

    public void Easy()
    {
        speed = 5;
        genTime = 2.0f;
        offsetRange = 6;
        GameManager.instance.easyButton.colors.Equals(Color.green);
        GameManager.instance.mediumButton.colors.Equals(Color.gray);
        GameManager.instance.hardButton.colors.Equals(Color.gray);
    }
    public void Medium()
    {
        speed = 6;
        genTime = 1.0f;
        offsetRange = 8;
        GameManager.instance.easyButton.colors.Equals(Color.gray);
        GameManager.instance.mediumButton.colors.Equals(Color.yellow);
        GameManager.instance.hardButton.colors.Equals(Color.gray);
    }
    public void Hard()
    {
        speed = 7;
        genTime = 0.5f;
        offsetRange = 10;
        GameManager.instance.easyButton.colors.Equals(Color.gray);
        GameManager.instance.mediumButton.colors.Equals(Color.gray);
        GameManager.instance.hardButton.colors.Equals(Color.red);
    }
}
