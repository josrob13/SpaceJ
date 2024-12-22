using System.Collections;
using UnityEngine;

public class HeartRotation : MonoBehaviour
{
    public float time = 20f;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(TriggerAnimation());
    }

    private IEnumerator TriggerAnimation()
    {
        Debug.Log("Esperando...");
        yield return new WaitForSecondsRealtime(time);

        while (true)
        {
            animator.SetTrigger("PlayRotation");
            Debug.Log("rotando!!");
            yield return new WaitForSecondsRealtime(time);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
