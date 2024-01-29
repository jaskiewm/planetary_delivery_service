using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBossHealth : MonoBehaviour
{
    public int health;
    public int healthMax = 60;
    public GameObject boss;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public Slider bossHealthSlider;
    public GameObject bossHealthObject;
    public AudioClip destroySound;
    public float volume = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        bossHealthSlider = GameObject.Find("BossHealthBar").GetComponent<Slider>();
        bossHealthObject.GetComponent<CanvasGroup>().alpha = 1f;

        health = healthMax;
        SetHealth(health);
        spriteRenderer = boss.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D col)
    {
        health -= 1;
        Debug.Log(bossHealthSlider.value);
        SetHealth(health);
        if (health <= 0)
        {
            PlayerScore.scoreValue += 10;
            AudioSource.PlayClipAtPoint(destroySound, transform.position, volume);
            Destroy(gameObject);
        }
        else
        {
            originalColor.a = 0.94f;
            spriteRenderer.color = originalColor;

            StartCoroutine(waiter(() =>
                {
                originalColor.a = 1f;
                spriteRenderer.color = originalColor;
            }));
        }
    }

    IEnumerator waiter(System.Action onComplete)
    {
        yield return new WaitForSecondsRealtime(0.1f);

        if (onComplete != null)
        {
            onComplete.Invoke();
        }
    }

    public void SetHealth(float HealthValue)
    {
        bossHealthSlider.value = HealthValue;
    }

}
