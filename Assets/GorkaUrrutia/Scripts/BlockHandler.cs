using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockHandler : MonoBehaviour
{
    [SerializeField] AudioClip sound;
    [SerializeField] int points = 1;
    [SerializeField] GameObject particlePrefab;

    [SerializeField] bool badBlock = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            if (!badBlock)
            {
                AudioSource.PlayClipAtPoint(sound, transform.position);

            }
            GameManager.instance.AddPoint(points);

            GameObject particles = Instantiate(particlePrefab, transform.position, Quaternion.identity);
            if (particles != null)
            {
                Destroy(particles, particles.GetComponent<ParticleSystem>().main.duration);
            }

            if (badBlock)
            {
                GameManager.instance.LoseHp();
            }

            Destroy(gameObject);
        }
    }
}
