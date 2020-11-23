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
                        GameManager.getInstance().DialogEnded();
                    }
                    else
                    {
                        CheckIfName();
                        dialogText.text = dialogLines[currentLine];
                    }
                }else
                {
                    justStarted = false;
                }
            }
            
        }
    }

    public void ShowDialog(List<string> newLines, bool isPerson)
    {
        dialogLines = newLines;
        currentLine = 0;
        justStarted = true;
        
        nameBox.SetActive(isPerson);
        
        GameManager.getInstance().DialogStarted();
        CheckIfName();
        dialogText.text = dialogLines[currentLine];
        
        dialogBox.SetActive(true);
    }

    public void CheckIfName()
    {
        if (dialogLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogLines[currentLine].Replace("n-","");
            currentLine++;
        }
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