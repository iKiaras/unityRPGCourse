using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    private string transitionName;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerController.getInstance() != null)
        {
            if (transitionName.Equals(PlayerController.getInstance().getAreaTransitionName()))
            {
                PlayerController.getInstance().transform.position = transform.position;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setTransitionName(string name)
    {
        transitionName = name;
    }
}
