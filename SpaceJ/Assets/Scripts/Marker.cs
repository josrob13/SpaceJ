using System;
using UnityEngine;

public class Marker : MonoBehaviour
{
    public GameObject[] numbersPrefab;
    public Transform hundreds;
    public Transform tens;
    public Transform units;

    private int currentScore = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void updateScore(int newScore)
    {
        currentScore = Math.Clamp(newScore, 0, 999);
        UpdateDigits();
    }

    private void UpdateDigits()
    {
        int newHundreds = currentScore / 100;
        int newTens = (currentScore / 10) % 10;
        int newUnits = (currentScore % 10);

        UpdateOne(hundreds, newHundreds);
        UpdateOne(tens, newTens);
        UpdateOne(units, newUnits);
    }

    private void UpdateOne(Transform oldDigit, int value)
    {
        foreach (Transform child in oldDigit)
        {
            Destroy(child.gameObject);
        }

        GameObject newDigit = numbersPrefab[value];
        Instantiate(newDigit, oldDigit.position, oldDigit.rotation, oldDigit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
