using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipes", menuName = "Recipe")]
public class CraftingRecipe : ScriptableObject
{
    public List<int> ingredients;
    public Item product;
}
