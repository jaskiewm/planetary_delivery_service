using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    //Bullet destroyed after x seconds
    void Start()
    {
        if (gameObject.tag == "Projectile")
        {
            Destroy(gameObject, 3f);
        }
    }

    //Destroyed on impact
    private void OnCollisionEnter(Collision col)
    {
        var tagName = col.gameObject.tag;

        if (tagName == "spaceship" || tagName == "Projectile" || gameObject.tag == "projectile")
        {
            Destroy(gameObject);
            if (gameObject.tag == "Enemy")
            {
                //Score.scoreValue += 1;
            }
        }
    }
}
