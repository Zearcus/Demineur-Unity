using UnityEngine;

public class Cell
{
    //crée les 3 Type de case
    public enum Type
    {
        Empty,
        Mine,
        Number,
    }

    //les action possible 
    public Type type;
    public Vector3Int position;
    public int number;
    public bool exploded;
    public bool flagged;
    public bool revealed;
}
