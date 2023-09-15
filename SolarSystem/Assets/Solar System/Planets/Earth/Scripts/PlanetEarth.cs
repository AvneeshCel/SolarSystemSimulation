using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetEarth : BasePlanet
{
    
    // Start is called before the first frame update
    protected override void Start()
    {
        planetName = "Earth";
        planetMass = 1f;
        planetSize = 0.012742f;
        //planetOrbitalPeriod = ;
        //planetGravity = ;
        axialTilt = 23.5f;
        rotationalSpeed = 0.001574f;
        base.Start();
        transform.Rotate(39.61f, 0, 0);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        //base.FixedUpdate();
    }
}
