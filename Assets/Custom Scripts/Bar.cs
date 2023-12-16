using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{

    [SerializeField] protected float currentBarValue;
    [SerializeField] protected float minBarValue;
    [SerializeField] protected float maxBarValue; 

    [SerializeField] protected GameObject barFillVisual;
    // Start is called before the first frame update
    public virtual void Start()
    {
        currentBarValue = 100;
        minBarValue = 0f;
        maxBarValue = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getCurrentBarValue(){
        return this.currentBarValue;
    }

    public void adjustCurrentBarValue(float barAdjustment){
        setCurrentBarValue(this.currentBarValue + barAdjustment);
    }

    protected float computeBarFillScale(){
        return getCurrentBarValue()/maxBarValue;
    }

    public void setCurrentBarValue(float newBarValue){
        float temp = Mathf.Clamp(newBarValue, minBarValue, maxBarValue);
        this.currentBarValue = temp;
    }
}
