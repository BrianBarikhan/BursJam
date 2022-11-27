using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject playerSprite;
    [SerializeField] Animator animator;
    Vector3 targetPosition;
    Vector3 mousePosition;
    Vector3 direction;
    bool isTargetSet;
    bool isTalking;
    bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        targetPosition = Vector3.zero;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); ;
        direction = Vector3.zero;
        isTargetSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&!isTalking&&canMove)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition = mousePosition;
            targetPosition.z = 0;

            direction = targetPosition - gameObject.transform.position;

            if (direction.x >= 0)
            {
                playerSprite.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                playerSprite.transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }

        direction = targetPosition - gameObject.transform.position;

        animator.SetFloat("direction", direction.magnitude);
    }

    private void FixedUpdate()
    {
        if (direction.magnitude > 0.2f)
        {
            direction = direction.normalized;
            if (!canMove)
            {
                direction = Vector3.zero;
            }
            gameObject.transform.position += direction * speed * Time.fixedDeltaTime;
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

    public void setCanMove(bool value)
    {
        canMove = value;
    }
}
