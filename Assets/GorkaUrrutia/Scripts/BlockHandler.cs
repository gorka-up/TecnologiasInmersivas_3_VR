using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockHandler : MonoBehaviour
{
    [SerializeField] AudioClip sound;
    [SerializeField] int points = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
            GameManager.instance.AddPoint(points);
            Destroy(gameObject);
        }
    }
}
