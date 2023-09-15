using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSaturn : BasePlanet
{

    // Start is called before the first frame update
    protected override void Start()
    {
        planetName = "Saturn";
        planetMass = 95.2f;
        planetSize = 0.012742f;
        //planetOrbitalPeriod = ;
        //planetGravity = ;
        axialTilt = 26.7f;
        rotationalSpeed = 0.03684f;
        
        base.Start();

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}