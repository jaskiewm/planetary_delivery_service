using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletBehavior : MonoBehaviour
{
    public float projectileSpeed = 100f;
    
    public Rigidbody2D projectile;
    public Transform ShipFrontEnd;
    float autoShootCounter = 0;
    float overHeatCounter = 0;
    bool zHasShot = false;
    public Slider overheatSlider;
    public Gradient sliderGradiant;
    public Image sliderFill;

    void Update()
    {
        if (zHasShot == false)
        {
            if (options.movementOption == true)
            {
                //If you click "Z", the bullet will have a force in the +ve x direction
                if (Input.GetKeyDown("z") & Time.timeScale != 0f)
                {
                    PlayerShoots();
                }
                //If you click "Z", the bullet will have a force in the +ve x direction automatically, but only if aSC is >150
                if (Input.GetKey("z") & Time.timeScale != 0f)
                {
                    autoShootCounter += 1f;
                    if (autoShootCounter > 100)
                    {
                        PlayerShoots();
                    }
                }
            }
            else if (options.movementOption == false)
            {
                //If you click "mouse button down", the bullet will have a force in the +ve x direction
                if (Input.GetMouseButtonDown(0) & Time.timeScale != 0f)
                {
                    PlayerShoots();
                }
            }
        }

        if (overHeatCounter > 0 & zHasShot == false)
        {
            overHeatCounter -= 0.1f;
        }

        if (overHeatCounter > 200 & zHasShot == false)
        {
            zHasShot = true;
        }
        else if (overHeatCounter > 0 & overHeatCounter <= 300 & zHasShot == true)
        {
            overHeatCounter -= 0.15f;
        }
        else if (overHeatCounter < 0 & zHasShot == true)
        {
            zHasShot = false;
            overHeatCounter = 0;
        }
        SetOverheat(overHeatCounter);
    }
    public void SetOverheat (float overheatValue)
    {
        overheatSlider.value = overheatValue;
        sliderFill.color = sliderGradiant.Evaluate(overheatValue/100f);
    }

    public void PlayerShoots()
    {
        Rigidbody2D projectileInstance;
        projectileInstance = Instantiate(projectile, ShipFrontEnd.position, ShipFrontEnd.rotation);
        projectileInstance.AddForce(transform.right * projectileSpeed);
        autoShootCounter = 0;
        overHeatCounter += 25f;
    }
}
