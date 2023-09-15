using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent (typeof(Rigidbody))]
public class SpaceShip : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    [Header("Ship Movement Settings")]
    [SerializeField]
    private float yawTorque = 500f;
    [SerializeField]
    private float pitchTorque = 1000f;
    [SerializeField]
    private float rollTorque = 1000f;
    [SerializeField]
    private float thrust = 100f;
    [SerializeField]
    private float upThrust = 50f;
    [SerializeField]
    private float strafeThrust = 50f;


    [Header("Boost Settings")]
    [SerializeField]
    private float maxBoostAmount = 2f;
    [SerializeField]
    private float boostDeprecationRate = 0.25f;
    [SerializeField]
    private float boostRechargeRate = 0.5f;
    [SerializeField]
    private float boostMultiplier = 5f;
    public bool boosting = false;
    public float currentBoostAmount;



    [SerializeField, Range(0.001f, 0.999f)]
    private float thrustGlideReduction = 0.999f;
    [SerializeField, Range(0.001f, 0.999f)]
    private float upDownGlideReduction = 0.111f;
    [SerializeField, Range(0.001f, 0.999f)]
    private float leftRightGlideReduction = 0.111f;
    float glide, verticalGlide, horizontalGlide = 0f;

    Rigidbody rb;
    public bool showPointer = false;
    public GameObject pointers;
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public GameObject instructionsMenu;
    public bool pause = false;
    public Slider slider;


    //Input Values
    private float thrust1D;
    private float upDown1D;
    private float strafe1D;
    private float roll1D;
    private Vector2 pitchYaw;

    //Misc
    private PlanetsMover mover;
    public Transform moverObj;
    public CinemachineVirtualCamera cam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentBoostAmount = maxBoostAmount;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pointers = GameObject.Find("Indicators");

    }

    private void Update()
    {
        if (pause) Cursor.visible = true;
        if (!pause) Cursor.visible = false;

        slider.maxValue = maxBoostAmount;
        slider.value = currentBoostAmount;

        if (!boosting) if (audioSource.isPlaying) audioSource.Stop();


        if (showPointer && pointers != null)
        {
           // foreach (GameObject obj in pointers)
           // {
           //     obj.SetActive(true);
            //}

            pointers.SetActive(true);
        }

        else if (pointers != null)
        {
           // foreach (GameObject obj in pointers)
           // {
                //obj.SetActive(false);
           // }

            pointers.SetActive(false);
        }

        moverObj.transform.position = -Mover() / 0.01f;


    }

    void FixedUpdate()
    {
        HandleBoosting();
        HandleMovement();
        
    }
    
    void HandleBoosting()
    {
        if (boosting && currentBoostAmount > 0f)
        {
            currentBoostAmount -= boostDeprecationRate;

            cam.m_Lens.FieldOfView = Mathf.Lerp(90, 60, currentBoostAmount/maxBoostAmount);


            
            if (currentBoostAmount <= 0f)
            {
                boosting = false;
            }
        }
        else
        {
            if (currentBoostAmount < maxBoostAmount)
            {
                currentBoostAmount += boostRechargeRate;
                cam.m_Lens.FieldOfView = Mathf.Lerp(90, 60, currentBoostAmount / maxBoostAmount);
            }
        }
    }


    void HandleMovement()
    {
        // Roll
        rb.AddRelativeTorque(roll1D * rollTorque * Time.deltaTime * Vector3.back);
        // Pitch
        rb.AddRelativeTorque(Mathf.Clamp(-pitchYaw.y, -1f, 1f) * pitchTorque * Time.deltaTime * Vector3.right);
        // Yaw
        rb.AddRelativeTorque(Mathf.Clamp(pitchYaw.x, -1f, 1f) * yawTorque * Time.deltaTime * Vector3.up);

        // Thrust
        if (thrust1D > 0.1f || thrust1D < -0.1f)
        {
            float currentThrust;

            if (boosting)
            {
                currentThrust = thrust * boostMultiplier;
            }

            else
            {
                currentThrust = thrust;
            }

            rb.AddRelativeForce(thrust1D * currentThrust * Time.deltaTime * Vector3.forward);
            glide = thrust;
        }
        else
        {
            rb.AddRelativeForce(glide * Time.deltaTime * Vector3.forward);
            glide *= thrustGlideReduction; 
        }

        // Up/Down
        if (upDown1D > 0.1f || upDown1D < -0.1f)
        {
            
            rb.AddRelativeForce(upDown1D * upThrust * Time.fixedDeltaTime * Vector3.up);
            verticalGlide = upDown1D * upThrust;
        }
        else
        {
            rb.AddRelativeForce(verticalGlide * Time.fixedDeltaTime * Vector3.up);
            verticalGlide *= upDownGlideReduction;
        }

        // Strafe
        if (strafe1D > 0.1f || strafe1D < -0.1f)
        {
            rb.AddRelativeForce(strafe1D * upThrust * Time.fixedDeltaTime * Vector3.right);
            horizontalGlide = strafe1D * strafeThrust;
        }
        else
        {
            rb.AddRelativeForce(horizontalGlide * Time.fixedDeltaTime * Vector3.right);
            horizontalGlide *= leftRightGlideReduction;
        }




    }

    #region Input Methods
    public void OnThrust(InputAction.CallbackContext context)
    {
        thrust1D = context.ReadValue<float>();
    }
    
    public void OnStrafe(InputAction.CallbackContext context)
    {
        strafe1D = context.ReadValue<float>();
    }
    
    public void OnUpDown(InputAction.CallbackContext context)
    {
        upDown1D = context.ReadValue<float>();
    }
    
    public void OnRoll(InputAction.CallbackContext context)
    {
        roll1D = context.ReadValue<float>();
    }
    
    public void OnPitchYaw(InputAction.CallbackContext context)
    {
        pitchYaw = context.ReadValue<Vector2>();
    }

    public void OnBoost(InputAction.CallbackContext context)
    {
        boosting = context.performed;
        audioSource.clip = audioClip;
        audioSource.Play();

    }

    public void ShowPointer(InputAction.CallbackContext context)
    {
        //showPointer = context.performed;
        showPointer = !showPointer;

    }
    
    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

            PauseGame();
        
        }
    }

    #endregion

    public void PauseGame()
    {


        //showPointer = context.performed;
        if (!settingsMenu.activeSelf && !instructionsMenu.activeSelf)
        {

            pause = !pause;
        }

        Debug.Log("called");

        if (!pause)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        //if pausemenu is disabled
        if (pauseMenu.activeSelf == false)
        {
            if (settingsMenu.activeSelf)
            {
                pauseMenu.SetActive(true);
                settingsMenu.SetActive(false);
            }

            else if (instructionsMenu.activeSelf)
            {
                instructionsMenu.SetActive(false);
                pauseMenu.SetActive(true);
            }

            if (pause)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
            }
        }



    }

    public Vector3 Mover()
    {
        //Debug.Log(transform.position);
     //  Debug.Log(moverObj.position);
        return transform.position;
    }
}
