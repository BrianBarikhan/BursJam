using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 targetPosition;
    Vector3 mousePosition;
    Vector3 direction;
    bool isTargetSet;
    bool isTalking;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = Vector3.zero;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); ;
        direction = Vector3.zero;
        isTargetSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&!isTalking)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition = mousePosition;
            targetPosition.z = 0;
        }
        direction = targetPosition - gameObject.transform.position;
        if(direction.magnitude > 1)
        {
            direction = direction.normalized;
            gameObject.transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        targetPosition = gameObject.transform.position;
    }

    public void setIsTalking(bool value)
    {
        isTalking = value;
    }
}
