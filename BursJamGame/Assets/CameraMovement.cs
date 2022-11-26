using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float leftBorder;
    [SerializeField] float rightBorder;
    [SerializeField] float topBorder;
    [SerializeField] float bottomBorder;
    bool move;
    // Start is called before the first frame update
    void Start()
    {
        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null &&
           player.transform.position.x > leftBorder &&
           player.transform.position.x < rightBorder &&
           player.transform.position.y < topBorder &&
           player.transform.position.y > bottomBorder)
        {
            move = true;
                gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, gameObject.transform.position.z);
        }
        else
        {
            move = false;
        }

    }
        void FixedUpdate()
        {
            if (move)
            {
            }
        }
}
