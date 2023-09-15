using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetUranus : BasePlanet
{

    // Start is called before the first frame update
    protected override void Start()
    {
        planetName = "Uranus";
        planetMass = 14.5f;
        planetSize = 0.012742f;
        //planetOrbitalPeriod = ;
        //planetGravity = ;
        axialTilt = 97.8f;
        rotationalSpeed = 0.014794f;
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}