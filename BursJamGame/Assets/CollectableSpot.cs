using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpot : MonoBehaviour
{
    [SerializeField] private GameObject item;
    private GameObject inventorySystem;
    bool clicked;
    // Start is called before the first frame update
    void Start()
    {
        inventorySystem = GameObject.Find("Inventory");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        clicked = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && clicked == true)
        {
            Transform parent = inventorySystem.GetComponent<InventoryManager>().AddItem(item);
            
            if(parent == null)
            {
                return;
            }

            Instantiate(item, parent);
            Destroy(gameObject);
        }
    }
}
