using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI PlayerName;
    public Transform PlayerNamePos;
    public Transform ChatPos;
    [SerializeField] public GameObject Player;
    [SerializeField] public TutorName[] Tutors;
    private void Awake()
    {
        instance = this;
        PlayerName.text = StartManager.instance.playername;
        PlayerName.transform.position = Camera.main.WorldToScreenPoint(PlayerNamePos.position);
        Player.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = StartManager.instance.character;
    }
    private void Update()
    {
        
    }
}
