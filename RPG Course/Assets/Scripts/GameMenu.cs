using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{

    [SerializeField] private GameObject theMenu;
    [SerializeField] private GameObject[] windows;
    [SerializeField] private Text nameText, hPText, mPText, levelText, expText;
    [SerializeField] private Slider expSlider;
    [SerializeField] private Image characterImage;
    private CharacterStats playerStats;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2")) 
        {
            if (theMenu.activeInHierarchy)
            {
                closeMenu();
            }
            else
            {
                UpdateMainStats();
                GameManager.getInstance().MenuOpened();
                theMenu.SetActive(true);
            }
        }
    }

    public void UpdateMainStats()
    {
        playerStats = GameManager.getInstance().CharStats;

        nameText.text = playerStats.CharacterName;
        hPText.text = playerStats.CurrentHp + "/" + playerStats.MaxHp;
        mPText.text = playerStats.CurrentMp + "/" + playerStats.MaxMp;
        levelText.text = "Level: "+ playerStats.PlayerLevel;
        expText.text = playerStats.CurrentExp + "/" + playerStats.ExpToNextLevel[playerStats.PlayerLevel];
        expSlider.value = playerStats.CurrentExp;
        expSlider.maxValue = playerStats.ExpToNextLevel[playerStats.PlayerLevel];
        characterImage.sprite = playerStats.CharImage;
    }

    public void ToggleWindow(int windowNumber)
    {
        for (int i = 0; i < windows.Length; i++)
        {
            if (i==windowNumber)
            {
                windows[i].SetActive(!windows[i].activeInHierarchy);
            }
            else
            {
                windows[i].SetActive(false);
            }
        }
    }

    public void closeMenu()
    {
        for (int i = 0; i < windows.Length; i++)
        {
            windows[i].SetActive(false);
        }
        
        theMenu.SetActive(false);
        
        GameManager.getInstance().MenuClosed();
    }
}
