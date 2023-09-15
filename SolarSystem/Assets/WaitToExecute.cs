using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitToExecute : MonoBehaviour
{
    public BasePlanet planet;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SetPlanetRotation", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetPlanetRotation()
    {
        planet.enabled = true;
       // Destroy(GetComponent<WaitToExecute>());
    }
}
