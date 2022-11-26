using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    [SerializeField] private List<CraftingRecipe> recipes;
    private List<GameObject> pendingItem = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(pendingItem.Count < 2)
        //{
        //    return;
        //}

        //List<int> itemIDs = new List<int>();

        //foreach (GameObject item in pendingItem)
        //{
        //}

        //foreach(CraftingRecipe recipe in recipes)
        //{
        //    List<int> ingres = new List<int>(recipe.ingredients.Count);

        //    for (int o = 0; o < recipe.ingredients.Count; o++)
        //    {
        //        ingres.Add(recipe.ingredients[o]);
        //        Debug.Log(ingres[o]);
        //    }

        //    for (int i = 0; i < ingres.Count; i++)
        //    {
        //        foreach(int id in itemIDs)
        //        {
        //            if(id == ingres[i])
        //            {
        //                ingres.RemoveAt(i);
        //                i--;
        //                break;
        //            }
        //        }
        //    }

        //    if(ingres.Count == 0)
        //    {
        //        foreach(GameObject item in pendingItem)
        //        {
        //        }
        //        pendingItem.Clear();

        //        return;
        //    }
        //}

        //pendingItem.Clear();
    }

    public void AddToPending(GameObject item)
    {
        pendingItem.Add(item);
    }
}
