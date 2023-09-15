using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMercury : BasePlanet
{

    // Start is called before the first frame update
    protected override void Start()
    {
        planetName = "Mercury";
        //planetMass = 0.0553f;
        planetMass = 1;
        planetSize = 0.012742f;
        //planetOrbitalPeriod = ;
        //planetGravity = ;
        axialTilt = 0.1f;
        rotationalSpeed = 0.00001083f;
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}