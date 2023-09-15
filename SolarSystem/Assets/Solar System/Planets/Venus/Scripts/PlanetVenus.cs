using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetVenus : BasePlanet
{

    // Start is called before the first frame update
    protected override void Start()
    {
        planetName = "Venus";
        planetMass = 0.815f;
        planetSize = 0.012742f;
        //planetOrbitalPeriod = ;
        //planetGravity = ;
        axialTilt = 177f;
        rotationalSpeed = 0.00000652f;
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}