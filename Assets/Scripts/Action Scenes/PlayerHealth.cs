using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    int health;
    public int CurrentHealth => health;

    private int healthMax = 3;
    private bool invincibility = false;
    public float invincibleTimeStart = 3;
    public float invincibleTime;
    public Slider healthSlider;
    public Slider invincibleSlider;

    // Start is called before the first frame update
    private void Start()
    {
        health = healthMax;
    }

    // Update is called once per frame
    void Update()
    {
        //if the player is temporarily invincible or not
        if (invincibleTime > 0 && invincibility == true)
        {
            invincibleTime -= Time.deltaTime;
        }
        else
        {
            invincibility = false;
            invincibleTime = invincibleTimeStart;
        }
        setHealth(health);
        invincibleSlider.value = invincibleTime;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (health > 0 && invincibility == false)
        {
            receiveSpaceshipDamage(1);
        }
    }
    public int getHealth()
    {
        return CurrentHealth;
    }
    public void setHealth(float HealthValue)
    {
        healthSlider.value = HealthValue;
    }
    private void receiveSpaceshipDamage(int damageAmount)
    {
        health -= damageAmount;
        invincibility = true;

        Debug.Log("Health Remaining: " + health + "/3");
    }
}
