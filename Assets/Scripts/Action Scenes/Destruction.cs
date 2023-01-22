using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    //Destroyed on impact
    private void OnCollisionEnter2D(Collision2D col)
    {
        var tagName = col.gameObject.tag;

        if (tagName == "Projectile")
        {
            Destroy(gameObject);
            if (gameObject.tag == "Enemy")
            {
                //Score.scoreValue += 1;
            }
        }
    }
}
