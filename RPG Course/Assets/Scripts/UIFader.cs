using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFader : MonoBehaviour
{

    [SerializeField] private Image fadeScreen;
    [SerializeField] private float fadeSpeed;

    private static UIFader instance;
    private bool shouldFadeToBlack = false;
    private bool shouldFadeFromBlack = false;
    
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
        if (shouldFadeToBlack)
        {
            fadeScreen.color = new Color(0,0,0,Mathf.MoveTowards(fadeScreen.color.a,1, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 1)
            {
                shouldFadeToBlack = false;
            }
        }

        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(0,0,0,Mathf.MoveTowards(fadeScreen.color.a,0, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 0)
            {
                shouldFadeFromBlack = false;
            }
        }
    }

    public static UIFader getInstance()
    {
        return instance;
    }

    public static void setInstance(UIFader newInstance)
    {
        instance = newInstance;
    }

    public void fadeToBlack()
    {
        shouldFadeFromBlack = false;
        shouldFadeToBlack = true;
    }

    public void fadeFromBlack()
    {
        shouldFadeToBlack = false;
        shouldFadeFromBlack = true;
    }
}
