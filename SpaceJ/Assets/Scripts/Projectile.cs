using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    public float lifetime = 2f;
    public GameObject goodShot;
    public int points;
    private Player player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    public void AddReference(Player p)
    {
        player = p;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Meteor"))
        {
            // Add points
            player.AddPoints(points);

            // Apply animation
            GameObject vfx = Instantiate(goodShot, transform.position, Quaternion.identity);
            Destroy(vfx, 1f);

            // Destroy objects
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
