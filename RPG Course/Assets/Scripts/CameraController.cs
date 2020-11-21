using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Tilemap _tilemap;
    
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;
    private float halfHeight;
    private float halfWidth;
    
    // Start is called before the first frame update
    void Start()
    {
        // target = PlayerController.getInstance().transform;
        target = FindObjectOfType<PlayerController>().transform;
        
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;
        
        bottomLeftLimit = _tilemap.localBounds.min + new Vector3(halfWidth, halfHeight,0);
        topRightLimit = _tilemap.localBounds.max - new Vector3(halfWidth, halfHeight,0);
        
        PlayerController.getInstance().SetBounds(_tilemap.localBounds.min, _tilemap.localBounds.max);
    }

    // Update is called once per frame after Update
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x,target.position.y, transform.position.z);
        
        //Keep the camera inside bounds
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x),Mathf.Clamp(transform.position.y, bottomLeftLimit.y,topRightLimit.y), transform.position.z);
    }
    
    
}
