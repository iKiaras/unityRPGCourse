using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerController.getInstance().transform;
    }

    // Update is called once per frame after Update
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x,target.position.y, transform.position.z);
    }
}
