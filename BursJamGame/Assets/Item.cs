using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collectable", menuName = "Item")]
public class Item : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    public int id;
}