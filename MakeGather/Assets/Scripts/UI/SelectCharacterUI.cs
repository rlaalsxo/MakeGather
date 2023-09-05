using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectCharacterUI : MonoBehaviour, IPointerDownHandler
{
    public static SelectCharacterUI instance;
    public Image playerImage;
    [SerializeField] Image SelectImage;
    private void Awake()
    {
        instance = this;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(eventData.pointerEnter.gameObject.name == "SelectPlayer")
        {
            playerImage.sprite = eventData.pointerEnter.gameObject.GetComponent<Image>().sprite;
        }
    }
    public void OpenUI()
    {
        if(SelectImage.gameObject.activeSelf == false)
        {
            SelectImage.gameObject.SetActive(true);
            Debug.Log("Open");
        }
        else
        {
            SelectImage.gameObject.SetActive(false);
            Debug.Log("Close");
        }
    }
}
