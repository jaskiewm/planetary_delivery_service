using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestruction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}
