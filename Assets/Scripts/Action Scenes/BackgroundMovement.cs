using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public GameObject backgroundImage1;
    public GameObject backgroundImage2;
    public GameObject backgroundImage3;
    public GameObject backgroundImage4;
    public GameObject visualBackground1;
    public GameObject visualBackground2;
    public Transform background1SpawnPoint;
    public Transform background2SpawnPoint;
    private bool backgroundFromStart = true;
    private bool B1Spawn = true; //Background 1 Spawn?
    private bool B2Spawn = true; //Background 2 Spawn?

    // Start is called before the first frame update
    void Start()
    {
        visualBackground1 = Instantiate(randomBackground(), background1SpawnPoint.position, background1SpawnPoint.rotation);
        visualBackground2 = Instantiate(randomBackground(), background2SpawnPoint.position, background2SpawnPoint.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (visualBackground2.transform.localPosition.x < background1SpawnPoint.position.x && B1Spawn == true)
        {
            Destroy(visualBackground1);
            visualBackground1 = Instantiate(randomBackground(), background2SpawnPoint.position, background2SpawnPoint.rotation);
            backgroundFromStart = false;
            B1Spawn = false;
            B2Spawn = true;
        }

        if (visualBackground1.transform.localPosition.x < background1SpawnPoint.position.x && backgroundFromStart == false && B2Spawn == true)
        {
            Destroy(visualBackground2);
            visualBackground2 = Instantiate(randomBackground(), background2SpawnPoint.position, background2SpawnPoint.rotation);
            B1Spawn = true;
            B2Spawn = false;
        }

        visualBackground1.transform.Translate(-0.5f * Time.deltaTime, 0, 0);
        visualBackground2.transform.Translate(-0.5f * Time.deltaTime, 0, 0);
    }
    private GameObject randomBackground()
    {
        int backgroundNumber = Random.Range(1, 4);
        switch (backgroundNumber)
        {
            case 1:
                return backgroundImage1;
            case 2:
                return backgroundImage2;
            case 3:
                return backgroundImage3;
            case 4:
                return backgroundImage4;
            default:
                return backgroundImage1;
        }
    }
}
