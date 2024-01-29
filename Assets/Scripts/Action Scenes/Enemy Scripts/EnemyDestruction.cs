using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestruction : MonoBehaviour
{
    public AudioClip destroySound;
    public float volume = 0.5f;


    private void OnCollisionEnter2D(Collision2D col)
    {
        var tagName = col.gameObject.tag;

        if (tagName == "Projectile")
        {
            AudioSource.PlayClipAtPoint(destroySound, transform.position,volume);
            Destroy(gameObject);
            PlayerScore.scoreValue += 2;
        }
    }

}
