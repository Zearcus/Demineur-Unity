using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Cell 
{
    public enum Type
    {
        Empty,
        Number,
        Mine,
    }

    public Vector3Int position;
    public Type type;
    public int number;
    public bool revealed;
    public bool flagged;
    public bool exploded;
}
