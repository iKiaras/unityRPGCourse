using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float movementSpeed;
    [SerializeField] private Animator _animator;
    private string areaTransitionName;
    private static PlayerController instance;
    
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
        
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * movementSpeed;
        
        _animator.SetFloat("moveX", _rigidbody2D.velocity.x);
        _animator.SetFloat("moveY", _rigidbody2D.velocity.y);

        if (Input.GetAxisRaw("Horizontal")==1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical")==1 || Input.GetAxisRaw("Vertical") == -1)
        {
            _animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            _animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));

        }
    }

    public static PlayerController getInstance()
    {
        return instance;
    }

    public void setAreaTransitionName(string name)
    {
        areaTransitionName = name;
    }

    public string getAreaTransitionName()
    {
        return areaTransitionName;
    }
}
