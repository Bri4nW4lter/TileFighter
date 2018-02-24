using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingChange : MonoBehaviour {

    public Light sun;
    public float StandardIntensity = 1.0f;
    public float DarkendIntensity = 0.5f;
   
	// Use this for initialization
	void Start () {
        sun.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
 
	}
    public void DimLight()
    {
        Debug.Log("dimmed");
        sun.intensity = DarkendIntensity;


    }
}
