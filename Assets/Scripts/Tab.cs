using UnityEngine;
using UnityEngine.Tilemaps;

public class Tab : MonoBehaviour
{
    public Tilemap map { get; private set; }

    //mise en place des sprite pour faire la map 
    public Tile num1;
    public Tile num2;
    public Tile num3;
    public Tile num4;
    public Tile num5;
    public Tile num6;
    public Tile num7;
    public Tile num8;
    public Tile mine;
    public Tile mineOn;
    public Tile flag;
    public Tile empty;
    public Tile unknown;

    private void Awake()
    {
        map = GetComponent<Tilemap>();
    }

    //initialisation du tableau 
    public void Board(Cell[,] state)
    {
        int width = state.GetLength(0);
        int height = state.GetLength(1);

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Cell cell = state[i, j];
                map.SetTile(cell.position, GetTypeTile(cell));
            }
        }
    }

    //type d'action 
    private Tile GetTypeTile(Cell cell)
    {
        if (cell.revealed)
        {
            return GetMine(cell);
        }
        else if (cell.flagged)
        {
            return flag;
        }
        else
        {
            return unknown;
        }
    }

    //sprite derriere chaque case 
    private Tile GetMine(Cell cell)
    {
        switch (cell.type)
        {
            case Cell.Type.Empty:
                return empty;
            case Cell.Type.Mine:
                return mine;
            case Cell.Type.Number:
                return GetNumber(cell);
            default:
                return null;
        }
    }

    //quel tile mettre en fonction du nombre de mine 
    private Tile GetNumber(Cell cell)
    {
        switch (cell.number)
        {
            case 1:
                return num1;
            case 2:
                return num2;
            case 3:
                return num3;
            case 4:
                return num4;
            case 5:
                return num5;
            case 6:
                return num6;
            case 7:
                return num7;
            case 8:
                return num8;
            default:
                return null;
        }
    }
}
