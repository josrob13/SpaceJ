using UnityEngine;
using UnityEngine.VFX;

public class Meteor : MonoBehaviour
{
    public float speed = 3f;
    public GameObject explosionEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        // Detectar colisión con la nave
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Meteorito impactó con la nave");

            // Destruir el meteorito
            if (gameObject != null)
                Destroy(gameObject);

            // Aplicar animacion
            GameObject vfx = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(vfx, 1f);

            // Reducir vida de la nave
            Player player = collider.gameObject.GetComponent<Player>();
            if (player != null)
                player.TakeDamage(1f);
        } else if (collider.CompareTag("Limit"))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
    }
}
