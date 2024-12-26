using System.Collections.Generic;
using UnityEngine;

public class HeartContainer : MonoBehaviour
{
    public List<GameObject> hearts;
    private int numHearts;
    public GameObject heartPrefab;
    public GameObject hitVFX;
    private RectTransform containerRectTransform;
    private RectTransform heartRectTransform;
    public Canvas canvas;

    // maybe no
    public GameObject container;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        numHearts = hearts.Count;
        containerRectTransform = GetComponent<RectTransform>();
    }

    public void BrokeHeart()
    {
        GameObject heartRef = hearts[numHearts - 1];
        heartRectTransform = heartRef.GetComponent<RectTransform>();
        //GameObject vfx = Instantiate(hitVFX, heartRef.transform.position, Quaternion.identity);
        

        // Calcular la posición relativa
        Vector3 relativePosition = containerRectTransform.localPosition + heartRef.transform.localPosition;

        // Instanciar el VFX como hijo del Canvas
        GameObject vfx = Instantiate(hitVFX, this.transform);

        /*
        // Ajustar la posición del VFX para que coincida con el corazón
        RectTransform heartRect = heartRef.GetComponent<RectTransform>();
        RectTransform vfxRect = vfx.GetComponent<RectTransform>();

        if (heartRect != null && vfxRect != null)
        {
            vfxRect.position = heartRect.position; // Igualar posición al corazón
            vfxRect.localScale = Vector3.one; // Escala por defecto (ajusta según sea necesario)
        }*/


        // Ajustar la posición del VFX
        //RectTransform vfxRect = vfx.GetComponent<RectTransform>();

        Vector3 offset = heartRef.transform.localPosition;
        offset.y = 7f;
        offset.z = 0f;
        vfx.transform.localPosition = offset;

        Debug.Log($"Heart Position: {heartRef.transform.position}");
        Debug.Log($"Heart Local Position: {heartRef.transform.localPosition}");
        Debug.Log($"---------------------------------");
        Debug.Log($"VFX POSITION LOCAL: {vfx.transform.localPosition}");

        //Destroy(vfx, 1f);
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
