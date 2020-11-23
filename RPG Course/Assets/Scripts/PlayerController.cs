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
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;
    private bool canMove = true;

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
        if (canMove)
        {
            _rigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) *
                                    movementSpeed;

            _animator.SetFloat("moveX", _rigidbody2D.velocity.x);
            _animator.SetFloat("moveY", _rigidbody2D.velocity.y);
        }
        else
        {
            _rigidbody2D.velocity = Vector2.zero;
            
            _animator.SetFloat("moveX", _rigidbody2D.velocity.x);
            _animator.SetFloat("moveY", _rigidbody2D.velocity.y);
        }

        if (canMove)
        {
            if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 ||
                Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
            {
                _animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
                _animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
                
                
            }
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x),
                Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
        }

        
    }

    public void SetBounds(Vector3 newBottomLeftLimit, Vector3 newTopRightLimit)
    {
        bottomLeftLimit = newBottomLeftLimit + new Vector3(1, 1, 0);
        topRightLimit = newTopRightLimit - new Vector3(1, 1, 0);
    }

    public static PlayerController getInstance()
    {
        return instance;
    }

    public static void setInstance(PlayerController playerController)
    {
        instance = playerController;
    }

    public void setAreaTransitionName(string name)
    {
        areaTransitionName = name;
    }

    public string getAreaTransitionName()
    {
        return areaTransitionName;
    }

    public void disableMovement()
    {
        canMove = false;
    }

    public void enableMovement()
    {
        canMove = true;
    }
}