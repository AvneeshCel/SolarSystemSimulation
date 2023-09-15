using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlanet : MonoBehaviour
{
   
    [SerializeField]
    protected string planetName;
    [SerializeField]
    protected float planetMass;
    [SerializeField]
    protected float planetSize;
    [SerializeField]
    protected int planetOrbitalPeriod;
    [SerializeField]
    protected float planetGravity;
    [SerializeField]
    public float axialTilt;
    [SerializeField]
    protected float rotationalSpeed; //This value is converted into million kilometer per hour to make it easier and in the same unit as other values.
   

    //GameObject[] objects; //Gather all the objects that will have gravity applied to them here.
    //const float G = 0.000667f; //Gravitational Constant scaled to match other objects.
    //const float G = 6.67f; //Gravitational Constant scaled to match other objects.
    //[SerializeField]
    //bool IsElipticalOrbit = false;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        transform.Rotate(new Vector3(0, 0, axialTilt));
    }


    // Update is called once per frame
    protected virtual void Update() //make a function, dont override update and awake.
    {
        RotatePlanet();

       

    }
    
    
    protected virtual void FixedUpdate()
    {
        //CalculateGravity();

    }




    //Every Planet attracts all objects with the "Objects" tag. Does not pull other planets.
   

    private void RotatePlanet()
    {
        transform.RotateAround(Vector3.up, (rotationalSpeed) * Time.deltaTime);

        
    }

}
