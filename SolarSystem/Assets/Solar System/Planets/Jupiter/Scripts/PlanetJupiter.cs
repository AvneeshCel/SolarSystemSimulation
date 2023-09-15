using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetJupiter : BasePlanet
{

    // Start is called before the first frame update
    protected override void Start()
    {
        planetName = "Jupiter";
        planetMass = 317.8f;
        planetSize = 0.012742f;
        //planetOrbitalPeriod = ;
        //planetGravity = ;
        axialTilt = 3.1f;
        rotationalSpeed = 0.045583f;
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}