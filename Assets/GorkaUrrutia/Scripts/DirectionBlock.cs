using UnityEngine;

public enum DirectionNeed
{
    Up,
    Down,
    Left,
    Right
}

public class DirectionBlock : MonoBehaviour
{
    [SerializeField] AudioClip sound;
    [SerializeField] int points = 1;
    [SerializeField] GameObject particlePrefab;

    [SerializeField] public DirectionNeed directionNeed;

    private Vector3 lastSwordPos;

    private bool AlreadyCut = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            lastSwordPos = other.transform.position;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Sword") && !AlreadyCut)
        {
            Vector3 posicionActual = other.transform.position;
            Vector3 direction = (posicionActual - lastSwordPos);

            if (direction.magnitude < 0.05f)
                return;

            direction.z = 0;

            DirectionNeed playerDirection = DetectDirection(direction);

            CheckCut(playerDirection);

            lastSwordPos = posicionActual;

            AlreadyCut = true;
        }
    }

    DirectionNeed DetectDirection(Vector3 dir)
    {
        dir = dir.normalized;

        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            if (dir.x > 0)
            {
                print("Right");
                return DirectionNeed.Right;
            }
            else
            {
                print("Left");
                return DirectionNeed.Left;
            }
        }
        else
        {
            if (dir.y > 0)
            {
                print("Up");
                return DirectionNeed.Up;
            }
            else
            {
                print("Down");
                return DirectionNeed.Down;
            }
        }
    }

    void CheckCut(DirectionNeed playerDirection)
    {
        if (playerDirection == directionNeed)
        {
            GameManager.instance.AddPoint(points);
            AudioSource.PlayClipAtPoint(sound, transform.position);
        }
        else
        {
            GameManager.instance.AddPoint(-points);
        }

        GameObject particles = Instantiate(particlePrefab, transform.position, Quaternion.identity);
        if (particles != null)
        {
            Destroy(particles, particles.GetComponent<ParticleSystem>().main.duration);
        }

        Destroy(gameObject);
    }
}
