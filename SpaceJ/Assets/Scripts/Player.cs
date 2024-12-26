using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    [SerializeField] private float health = 3f;

    // Projectile stuff
    public GameObject projectilePrefab;
    public AudioClip shootSound;
    private AudioSource audioSource;

    // Shooting stuff, cooldown, etc
    public Transform firepointA;
    public Transform firepointB;
    private bool canShoot = true;
    private float cooldownTime = 1f;

    // Points marker and actual score
    public Marker marker;
    public int score = 0;

    // Heart Container
    public HeartContainer heartContainer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        marker.updateScore(score);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            Fire();
        }

        if (Input.GetKey("right")) {
            if (transform.position.x < 7)
                transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey("left")) {
            if (transform.position.x > -7)
                transform.Translate(-Vector3.right * speed * Time.deltaTime);
        }
    }

    public void Fire()
    {
        GameObject projectile1 = Instantiate(projectilePrefab, firepointA.position, firepointA.rotation);
        projectile1.GetComponent<Projectile>().AddReference(this);
        // Reproducir el sonido del disparo
        if (audioSource != null && shootSound != null)
        {
            audioSource.pitch = Random.Range(0.9f, 1.1f); // Variación de tono
            audioSource.PlayOneShot(shootSound);
        }
        StartCoroutine(Cooldown());
    }

    public void AddPoints(int points)
    {
        score += points;
        marker.updateScore(score);
    }

    System.Collections.IEnumerator Cooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(cooldownTime);
        canShoot = true;
    }

    public void TakeDamage(float damage)
    {
        this.health -= damage;
        heartContainer.BrokeHeart();
    }
}
