using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> inventorySlots;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform AddItem(GameObject item)
    {
        foreach(GameObject slot in inventorySlots)
        {
            if(slot.transform.childCount == 0)
            {
                return slot.transform;
            }
        }

        return null;
    }

    public void RemoveItem(int index)
    {
        inventorySlots[index].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
    }
}
