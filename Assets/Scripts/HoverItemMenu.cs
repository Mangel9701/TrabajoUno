using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverItemMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject background;
    public AudioSource audioSource;
    public AudioClip hoverClip;

    void Start()
    {
        audioSource.clip = hoverClip;
    }

    public void OnPointerEnter(PointerEventData eventData)
     {
         background.SetActive(true);
         audioSource.Play();
     }
 
     public void OnPointerExit(PointerEventData eventData)
     {
         background.SetActive(false);
     }
}
