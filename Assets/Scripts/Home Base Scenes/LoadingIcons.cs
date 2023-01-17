using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingIcons : MonoBehaviour
{
    private float timeToAppearP1;
    private float timeToAppearP2;
    private float timeToAppearP3;
    private float timeWhenDissapear;
    public Text LoadingIcon;
    public Text Period1;
    public Text Period2;
    public Text Period3;

    // Start is called before the first frame update
    void Start()
    {
        LoadingIcon.enabled = true;
        Period1.enabled = true;
        Period2.enabled = false;
        Period3.enabled = false;

        timeToAppearP2 = Time.time + 1.5f;
        timeToAppearP3 = Time.time + 3f;
        timeWhenDissapear = Time.time + 4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Period1.enabled == false && (Time.time >= timeToAppearP1))
        {
            Period1.enabled = true;
        }
        if (Period2.enabled == false && (Time.time >= timeToAppearP2))
        {
            Period2.enabled = true;
        }
        if (Period3.enabled == false && (Time.time >= timeToAppearP3))
        {
            Period3.enabled = true;
        }
        if (LoadingIcon.enabled && (Time.time >= timeWhenDissapear))
        {
            LoadingIcon.enabled = false;
        }

        if (Period1.enabled && (Time.time >= timeWhenDissapear))
        {
            Period1.enabled = false;
            Period2.enabled = false;
            Period3.enabled = false;
        }

        Debug.Log(Period3.enabled);
    }
}
