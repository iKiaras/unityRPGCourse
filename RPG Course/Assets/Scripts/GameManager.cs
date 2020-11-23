using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CharacterStats charStats; //List if we need more than one character.
    private static GameManager instance;
    
    private bool gameMenuOpen, dialogActive, fadingBetweenAreas;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameMenuOpen || dialogActive || fadingBetweenAreas)
        {
            PlayerController.getInstance().disableMovement();
        }
        else
        {
            PlayerController.getInstance().enableMovement();
        }
    }

    public static GameManager getInstance()
    {
        return instance;
    }

    public void MenuOpened()
    {
        gameMenuOpen = true;
    }

    public void MenuClosed()
    {
        gameMenuOpen = false;
    }

    public void DialogStarted()
    {
        dialogActive = true;
    }

    public void DialogEnded()
    {
        dialogActive = false;
    }

    public void SceneTransitionStarted()
    {
        fadingBetweenAreas = true;
    }

    public void SceneTransitionEnded()
    {
        fadingBetweenAreas = false;
    }

    public CharacterStats CharStats
    {
        get => charStats;
        set => charStats = value;
    }
}
