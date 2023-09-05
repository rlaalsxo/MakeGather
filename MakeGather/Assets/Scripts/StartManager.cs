using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Animations;

public class StartManager : MonoBehaviour
{
    public static StartManager instance;
    [SerializeField] private TextMeshProUGUI text;
    public string playername;
    public Sprite character;
    public AnimatorController[] playerAnimator;
    private void Awake()
    {
        instance = this;
    }

    public void PlayerChoose()
    {
        if(text.text.Length >= 2 && text.text.Length <= 10)
        {
            playername = text.text;
            character = SelectCharacterUI.instance.playerImage.sprite;
            SceneManager.LoadScene("GatherScene");
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Debug.Log("적용할 수 없는 이름입니다");
        }
    }
}
