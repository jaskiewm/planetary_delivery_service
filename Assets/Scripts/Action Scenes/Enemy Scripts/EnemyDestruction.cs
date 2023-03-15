using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestruction : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        var tagName = col.gameObject.tag;

        if (tagName == "Projectile")
        {
            Destroy(gameObject);
            PlayerScore.scoreValue += 2;
        }
    }
}
