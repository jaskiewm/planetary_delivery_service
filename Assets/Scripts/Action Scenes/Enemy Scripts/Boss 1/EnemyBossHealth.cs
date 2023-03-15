using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossHealth : MonoBehaviour
{
    public int health;
    public int healthMax = 50;
    public GameObject boss;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    


    // Start is called before the first frame update
    void Start()
    {
        health = healthMax;
        spriteRenderer = boss.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D col)
    {
        health -= 1;

        if (health <= 0)
        {
            PlayerScore.scoreValue += 10;
            Destroy(gameObject);
        }
        else
        {
            originalColor.a = 0.5f;
            spriteRenderer.color = originalColor;
            originalColor.a = 1f;
        }
    }
    
}
