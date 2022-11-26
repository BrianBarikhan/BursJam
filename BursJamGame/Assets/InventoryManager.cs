using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> inventorySlots;
    private List<int> itemID = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < inventorySlots.Count; i++)
        {
            itemID.Add(-1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(CollectableItem item)
    {
        Debug.Log("A");
        int index;
        if(itemID.Contains(-1))
        {
            index = itemID.IndexOf(-1);
        }
        else
        {
            return;
        }

        inventorySlots[index].GetComponent<Image>().sprite = item.sprite;
        inventorySlots[index].GetComponentInChildren<Text>().text = item.name;
        itemID[index] = item.id;
    }
}
