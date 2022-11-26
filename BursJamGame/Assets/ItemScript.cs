using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    bool following = false;
    Vector2 initialPos;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(following)
        {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            transform.position = initialPos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            following = false;
        }
    }

    private void OnMouseDown()
    {
        following = true;
    }
}
