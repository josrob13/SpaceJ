using System.Collections.Generic;
using UnityEngine;

public class HeartContainer : MonoBehaviour
{
    public List<GameObject> hearts;
    private int numHearts;
    public GameObject heartPrefab;
    public GameObject hitVFX;
    public Canvas canvas;

    // maybe no
    public GameObject container;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        numHearts = hearts.Count;
    }

    public void BrokeHeart()
    {
        GameObject heartRef = hearts[numHearts - 1];

        // Instanciar el VFX como hijo del Canvas
        GameObject vfx = Instantiate(hitVFX, this.transform);
        vfx.transform.localPosition = heartRef.transform.localPosition;

        Debug.Log($"Heart Position: {heartRef.transform.position}");
        Debug.Log($"Heart Local Position: {heartRef.transform.localPosition}");
        Debug.Log($"---------------------------------");
        Debug.Log($"VFX POSITION LOCAL: {vfx.transform.localPosition}");

        Destroy(vfx, 1f);
        Destroy(hearts[numHearts - 1]);
        hearts.RemoveAt(numHearts - 1);
        numHearts--;
    }

    public void AddHeart()
    {
        hearts.Add(heartPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
