using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ShipMovement : MonoBehaviour
{   
    [Header("Speed")]

   [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 400f;
    [Tooltip("In ms")] [SerializeField] float ySpeed = 400f;

    

    [Header("Ranges")]
    [SerializeField] float xRange = 60f;
    [SerializeField] float yRangeDown = -4f;
    [SerializeField] float yRangeUp = 22f;

    float xOffset;
    float yOffset;

    [Header("Sensitivity Controls")]
    [SerializeField] float pitchFactor = -2f;
    [SerializeField] float otherPitchFactor = -2.5f;

    [SerializeField] float yawFactor = 1.5f;
    [SerializeField] float rollFactor = -1.5f;

    [Header("Guns")]

    [SerializeField] GameObject[] Lasers;

    bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isDead)
        {

            OperateTranslation();
            OperateRotation();
            OperateLasers();

        }else
        {

            return;

        }               
        
    }

   

    private void DeathSequence()
    {

        isDead = true;


    }

    private void OperateRotation()
    {
        transform.localRotation = Quaternion.Euler(GetPitch(), GetYaw(), GetRoll());

    }

    private float GetPitch()
    {

        float pitch = transform.localPosition.y * pitchFactor + yOffset * otherPitchFactor;
        return pitch;

    }

    private float GetYaw()
    {
        float yaw = transform.localPosition.x * yawFactor;
        return yaw;

    }

    private float GetRoll()
    {

        float roll = xOffset * rollFactor;
        return roll;
    }

    
    private void OperateTranslation()
    {

        transform.localPosition = new Vector3(TranslationX(), TranslationY(), transform.localPosition.z);

    }

    private float TranslationX()
    {
        float horizontalPush = CrossPlatformInputManager.GetAxis("Horizontal");


        xOffset = xSpeed * horizontalPush * Time.deltaTime;
        float rawXpos = transform.localPosition.x + xOffset;

        float actualXPos = Mathf.Clamp(rawXpos, -xRange, xRange);

        return actualXPos;

    }

    private float TranslationY()
    {

        float verticalPush = CrossPlatformInputManager.GetAxis("Vertical");

        yOffset = ySpeed * Time.deltaTime * verticalPush;
        float rawYpos = transform.localPosition.y + yOffset;

        float actualYPos = Mathf.Clamp(rawYpos,yRangeDown, yRangeUp);

        return actualYPos;

    }

    private void OperateLasers()
    {

        if (CrossPlatformInputManager.GetButton("Fire"))
        {

            SetLasersActive(true);


        }
        else
        {

            SetLasersActive(false);

        }



    }


    private void SetLasersActive(bool isActive)
    {

        foreach (GameObject laser in Lasers)
        {

            ParticleSystem lazy = laser.GetComponent<ParticleSystem>();
            lazy.enableEmission = isActive;

        }

    }

}
