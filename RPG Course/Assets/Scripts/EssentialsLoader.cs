using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    [SerializeField] private GameObject UIScreen;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject GameManagerInstance;
    
    // Start is called before the first frame update
    void Start()
    {
        if (UIFader.getInstance() == null)
        {
            UIFader.setInstance(Instantiate(UIScreen).GetComponent<UIFader>());
        }

        if (PlayerController.getInstance() == null)
        {
            PlayerController clone = Instantiate(Player).GetComponent<PlayerController>();
            PlayerController.setInstance(clone);
        }

        if (GameManager.getInstance() == null)
        {
            Instantiate(GameManagerInstance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
