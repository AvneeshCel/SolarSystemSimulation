using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMars : BasePlanet
{

    // Start is called before the first frame update
    protected override void Start()
    {
        planetName = "Mars";
        //planetMass = 0.107f;
        planetMass = 1.5f;
        planetSize = 0.012742f;
        //planetOrbitalPeriod = ;
        //planetGravity = ;
        axialTilt = 25f;
        rotationalSpeed = 0.000866f;
        base.Start();

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}