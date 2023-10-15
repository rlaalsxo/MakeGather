using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class UIManager : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Image usernameimage;
    [SerializeField] private Image selectchararter;
    [SerializeField] private Image namechangeimage;
    [SerializeField] private Image npctalk;
    [SerializeField] private Image npcface;
    [SerializeField] private Image talkspace;
    [SerializeField] private Image chatspace;
    [SerializeField] private TextMeshProUGUI changename;
    [SerializeField] private TextMeshProUGUI npcname;
    [SerializeField] private TextMeshProUGUI chat;
    public TextMeshProUGUI Usetext;
    public TextMeshProUGUI Username;
    GameObject thistutor = null;
    TextMeshProUGUI showtext;
    GameObject[] npcnames;
    GameObject[] playernames;
    private void Awake()
    {
        npcnames = GameObject.FindGameObjectsWithTag("Manager");
        playernames = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i < npcnames.Length; i++)
        {
            showtext = Instantiate<TextMeshProUGUI>(Username, usernameimage.transform, false);
            showtext.text = npcnames[i].name;
        }
        for (int i = 0; i < playernames.Length; i++)
        {
            showtext = Instantiate<TextMeshProUGUI>(Username, usernameimage.transform, false);
            showtext.text = playernames[i].name;
        }
    }
    private void Update()
    {
        foreach (var tutor in GameManager.instance.Tutors)
        {
            if(thistutor == null)
            {
                if (Vector3.Distance(GameManager.instance.Player.transform.position, tutor.gameObject.transform.position) <= 1f)
                {
                    tutor.MyName.gameObject.SetActive(true);
                    npctalk.gameObject.SetActive(true);
                    npctalk.gameObject.transform.position = Camera.main.WorldToScreenPoint(GameManager.instance.ChatPos.position);
                    npcface.sprite = tutor.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                    npcname.text = tutor.gameObject.name;
                    thistutor = tutor.gameObject;
                }
            }
            else if(Vector3.Distance(GameManager.instance.Player.transform.position, thistutor.transform.position) > 1.3f)
            {
                thistutor.GetComponent<TutorName>().MyName.gameObject.SetActive(false);
                npctalk.gameObject.SetActive(false);
                thistutor = null;
            }
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerEnter.gameObject.name == "SelectPlayer")
        {
            GameManager.instance.Player.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = eventData.pointerEnter.gameObject.GetComponent<Image>().sprite;
            GameManager.instance.Player.transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController = StartManager.instance.playerAnimator.Where(name => name.name == eventData.pointerEnter.gameObject.GetComponent<Image>().sprite.name).FirstOrDefault();
            selectchararter.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("잘못 누름");
        }
    }

    public void OpenUsersName()
    {
        if (usernameimage.gameObject.activeSelf == false)
        {
            usernameimage.gameObject.SetActive(true);
        }
        else
        {
            usernameimage.gameObject.SetActive(false);
        }
    }
    public void OpenSelectCharacter()
    {
        if (selectchararter.gameObject.activeSelf == false)
        {
            selectchararter.gameObject.SetActive(true);
        }
        else
        {
            selectchararter.gameObject.SetActive(false);
        }
    }
    public void OpenChangerName()
    {
        if(namechangeimage.gameObject.activeSelf == false)
        {
            namechangeimage.gameObject.SetActive(true);
        }
        else
        {
            namechangeimage.gameObject.SetActive(false);
        }
    }
    public void ChangeNameInGame()
    {
        if(changename.text.Length >= 2 && changename.text.Length <= 10)
        {
            GameManager.instance.PlayerName.text = changename.text;
        }
        else
        {
            Debug.Log("적용할 수 없는 이름입니다.");
        }
        changename.text = string.Empty;
        namechangeimage.gameObject.SetActive(false);
    }
    public void OpenTalk()
    {
        if(talkspace.gameObject.activeSelf == false)
        {
            talkspace.gameObject.SetActive(true);
            chatspace.gameObject.SetActive(true);
        }
        else
        {
            talkspace.gameObject.SetActive(false);
            chatspace.gameObject.SetActive(false);
        }
    }
    public void Chatting()
    {
        showtext = Instantiate<TextMeshProUGUI>(Usetext, talkspace.transform, false);
        showtext.text = chat.text;
        chat.text = string.Empty;
    }
}
