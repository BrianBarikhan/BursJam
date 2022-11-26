using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject playerSprite;
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
        if (direction.x >= 0)
        {
            playerSprite.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            playerSprite.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (direction.magnitude > 0.2f)
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
