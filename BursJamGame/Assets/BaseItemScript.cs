using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItemScript : MonoBehaviour
{
    [SerializeField] private string objectName;
    [SerializeField] private string completeObjectName;

    [SerializeField] private List<string> mergeableItem;
    [SerializeField] private List<GameObject> activatableItem;
    bool collided;
    string inputName;
    GameObject inputObject;


    private void Start()
    {
        for(int i = 0; i < mergeableItem.Count; i++)
        {
            mergeableItem[i] += "(Clone)";
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && collided)
        {
            Debug.Log("Release");

            foreach (string name in mergeableItem)
            {
                if (name == inputName)
                {
                    Destroy(inputObject);
                    activatableItem[mergeableItem.IndexOf(name)].SetActive(true);
                    return;
                }
            }
        }

            bool activated = true;

            foreach(GameObject gem in activatableItem)
            {
                if(!gem.activeInHierarchy)
                {
                    activated = false;
                    break;
                }
            }

            if(!activated)
            {
                objectName = completeObjectName;
            }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Item")
        {
            collided = true;
            inputName = other.gameObject.name;
            inputObject = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collided = false;
        inputName = "";
        inputObject = null;
    }

    public string GetName()
    {
        return objectName;
    }
}
