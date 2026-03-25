using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadBlockHandler : MonoBehaviour
{
    [SerializeField] AudioClip sound;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
            GameManager.instance.AddPoint(-1);
            Destroy(gameObject);
        }
    }
}
