using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteor;
    public float spawntime = 3f;
    public float spawncountdown;
    public float spawnrange = 7f;
    private float spawnX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawncountdown = spawntime;
    }

    public void SpawnObject()
    {
        spawnX = Random.Range(-spawnrange, spawnrange);
        Vector3 newPosition = new Vector3(spawnX, transform.position.y, 25);
        Instantiate(meteor, newPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (meteor != null)
        {
            spawncountdown -= Time.deltaTime;
            if (spawncountdown <= 0)
            {
                SpawnObject();
                spawncountdown = spawntime;
            }
        }
    }
}
