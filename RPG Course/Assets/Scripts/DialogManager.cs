using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    private static DialogManager instance;
    private int currentLine;
    [SerializeField] private GameObject dialogBox;
    private List<string> dialogLines;

    [SerializeField] private Text dialogText;
    private bool justStarted;
    [SerializeField] private GameObject nameBox;
    [SerializeField] private Text nameText;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                if (!justStarted)
                {
                    currentLine++;

                    if (currentLine >= dialogLines.Count)
                    {
                        dialogBox.SetActive(false);
                        PlayerController.getInstance().enableMovement();
                    }
                    else
                    {
                        dialogText.text = dialogLines[currentLine];
                    }
                }else
                {
                    justStarted = false;
                }
            }
            
        }
    }

    public void ShowDialog(List<string> newLines)
    {
        dialogLines = newLines;
        currentLine = 0;
        justStarted = true;
        
        PlayerController.getInstance().disableMovement();

        dialogText.text = dialogLines[currentLine];
        dialogBox.SetActive(true);
    }

    public bool isDialogBoxActive()
    {
        return dialogBox.activeInHierarchy;
    }

    public static DialogManager getInstance()
    {
        return instance;
    }
}