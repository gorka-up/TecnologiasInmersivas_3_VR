using System.Collections;
using UnityEngine;
using static GameManager;

public class SpawnHandler : MonoBehaviour
{
    [SerializeField] GameObject block;

    float offsetRange = 6;
    float spawnDistance = 10f;

    float speed = 5f;
    float genTime = 2.0f;

    float accumTime = 0.0f;

    bool start = false;

    public void SpawnBlocks()
    {
        if (start)
        {
            accumTime += Time.deltaTime;
            while (accumTime >= genTime)
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
                accumTime -= genTime;
            }
        }
    }

    IEnumerator DestroyMyBlock(GameObject block)
    {
        yield return new WaitForSeconds(6);
        if (block != null ) Destroy(block);
    }

    public void Ready()
    {
        StartCoroutine(SetStart());
    }

    IEnumerator SetStart()
    {

        if (start)
        {
            start = !start;
        }
        yield return new WaitForSeconds(1);
        GameManager.instance.countDownTMP.gameObject.SetActive(true);
        GameManager.instance.countDownTMP.text = "5";
        yield return new WaitForSeconds(1);
        GameManager.instance.countDownTMP.text = "4";
        yield return new WaitForSeconds(1);
        GameManager.instance.countDownTMP.text = "3";
        yield return new WaitForSeconds(1);
        GameManager.instance.countDownTMP.text = "2";
        yield return new WaitForSeconds(1);
        GameManager.instance.countDownTMP.text = "1";
        yield return new WaitForSeconds(1);
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
