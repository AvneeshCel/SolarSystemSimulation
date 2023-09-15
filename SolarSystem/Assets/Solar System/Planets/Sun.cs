using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField]
    protected string sunName;
    [SerializeField]
    protected float sunMass;
    [SerializeField]
    protected float sunSize;
    [SerializeField]
    protected float planetGravity;
    [SerializeField]
    protected float axialTilt;
    [SerializeField]
    protected float rotationalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        sunMass = 333000f;
        sunName = "Sun";
        sunSize = 1.3927f;
        axialTilt = 7.25f;
        transform.Rotate(new Vector3(0, 0, -axialTilt));
    }




}
