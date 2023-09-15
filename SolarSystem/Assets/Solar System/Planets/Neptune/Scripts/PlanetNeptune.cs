using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetNeptune : BasePlanet
{

    // Start is called before the first frame update
    protected override void Start()
    {
        planetName = "Neptune";
        planetMass = 17.1f;
        planetSize = 0.012742f;
        //planetOrbitalPeriod = ;
        //planetGravity = ;
        axialTilt = 28.5f;
        rotationalSpeed = 0.009719f;
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}