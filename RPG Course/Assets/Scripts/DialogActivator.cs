using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    [SerializeField] private List<string> lines;
    private bool _canActivate;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_canActivate && Input.GetButtonDown("Fire1") && !DialogManager.getInstance().isDialogBoxActive())
        {
            DialogManager.getInstance().ShowDialog(lines);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _canActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _canActivate = false;
        }
    }
}
