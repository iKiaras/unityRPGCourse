using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{

    [SerializeField] private GameObject theMenu;
    [SerializeField] private Text nameText, hPText, mPText, levelText, currentXpText, maxCurrentXpText;
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
                GameManager.getInstance().MenuClosed();
                theMenu.SetActive(false);
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
        hPText.text = playerStats.CurrentHp.ToString();
        mPText.text = playerStats.CurrentMp.ToString();
        levelText.text = playerStats.PlayerLevel.ToString();
        currentXpText.text = playerStats.CurrentExp.ToString();
        maxCurrentXpText.text = playerStats.ExpToNextLevel[playerStats.PlayerLevel].ToString();

    }
}
