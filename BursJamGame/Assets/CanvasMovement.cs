using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMovement : MonoBehaviour
{
    [SerializeField] GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (camera != null)
        {
            gameObject.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, gameObject.transform.position.z);
        }
        
    }

    void FixedUpdate()
    {
    }
}
