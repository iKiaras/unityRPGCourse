using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] private string areaToLoad;
    [SerializeField] private string areaTransitionName;
    [SerializeField] private AreaEntrance _areaEntrance;
    [SerializeField] private float waitToLoad =1f;
    private bool shouldLoadAfterFade = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _areaEntrance.setTransitionName(areaTransitionName);
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime;

            if (waitToLoad <= 0)
            {
                shouldLoadAfterFade = false;
                SceneManager.LoadScene(areaToLoad);
            }
        }
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerController.getInstance().setAreaTransitionName(areaTransitionName);
            shouldLoadAfterFade = true;
            UIFader.getInstance().fadeToBlack();
        }
        
        
    }

}
