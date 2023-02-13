using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]

public class SoundOnHover : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource theSource;

    // Start is called before the first frame update
    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioSource theSource = GetComponent<AudioSource>();
        theSource.Play();
    }
}
