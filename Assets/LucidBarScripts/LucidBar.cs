using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucidBar : MonoBehaviour
{

    [SerializeField] private float currentLucidity;

    [SerializeField] float minLucidity;
    [SerializeField] float maxLucidity; 

    [SerializeField] private float lucidityChangeRate; // percent to drain per second.

    [SerializeField] private GameObject lucidBarFill;


    // Start is called before the first frame update
    void Start()
    {
        currentLucidity = 100;
        lucidityChangeRate = -1;
        minLucidity = 0f;
        maxLucidity = 100f;
        lucidBarFill = GameObject.Find("LucidBarFill");
    }

    // Update is called once per frame
    void Update()
    {
        //Figure out how much the current lucidty changes based on drain rate.
        float amountToDrain = lucidityChangeRate * Time.deltaTime;

        //Actually update the current lucidity.
        adjustCurrentLucidity(amountToDrain);

        //Update the visuals of the bar.
        Vector3 newLucidBarScale = lucidBarFill.transform.localScale;
        newLucidBarScale.x = computeLucidBarFillScale();
        lucidBarFill.transform.localScale = newLucidBarScale;
    }

    public float getCurrentLucidity(){
        return this.currentLucidity;
    }

    private float computeLucidBarFillScale(){
        return getCurrentLucidity()/100.0f;
    }

    public void setCurrentLucidity(float newLucidity){
        float temp = Mathf.Clamp(newLucidity, minLucidity, maxLucidity);
        this.currentLucidity = temp;
    }

    public void adjustCurrentLucidity(float lucidityAdjustment){
        setCurrentLucidity(this.currentLucidity + lucidityAdjustment);
    }
}
