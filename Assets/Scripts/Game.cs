using UnityEngine;

public class Game : MonoBehaviour
{
    public int width = 16;
    public int height = 16;
    public int mineCount = 16;

    private Board board;
    private Cell[,] state;

    private void Awake()
    {
        board = GetComponentInChildren<Board>();
    }

    private void Start ()
    {
        NewGame();
    }

    private void NewGame()
    {
        state = new Cell[width, height];

        GenerateCells();
        GenerateMines();
        Numbers();

        Camera.main.transform.position = new Vector3(width / 2f, height / 2f, -10f);
        board.Draw(state);
    }

    private void GenerateCells()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Cell cell = new Cell();
                cell.position = new Vector3Int(i, j, 0);
                cell.type = Cell.Type.Empty;
                state[i, j] = cell;
            }
        }
    }

    private void GenerateMines()
    {
        for (int i = 0; i < mineCount; i++)
        {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);

            while (state[x, y].type == Cell.Type.Mine) 
            {
                x++;

                if (x>= width)
                {
                    x = 0;
                    x++;

                    if (y >= height) 
                    {
                        y = 0;
                    }
                }
            }
            state[x, y].type = Cell.Type.Mine;
        }
    }

    private void Numbers()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Cell cell = state[x, y];

                if (cell.type == Cell.Type.Mine)
                {
                    continue;
                }

                cell.number = CounterMines(x,y);

                if (cell.number > 0)
                {
                    cell.type = Cell.Type.Number;
                }
                state[x, y] = cell;
            }
        }
    }

    private int CounterMines(int cellX, int cellY)
    {
        int count = 0;

        for (int adgX = -1; adgX <= 1; adgX++)
        {
            for (int adgY = -1; adgY <= 1; adgY++)
            {
                if (adgX == 0 && adgY == 0)
                {
                    continue;
                }

                int x = cellX + adgX;
                int y = cellY + adgY;

                if (GetCell(x, y).type == Cell.Type.Mine)
                {
                    count++;
                }
            }
        }

        return count;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Flag();
        }
    }
    private void Flag()
    {
        Vector3 WorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int CellPostion = board.tilemap.WorldToCell(WorldPosition);
        Cell cell = GetCell(CellPostion.x, CellPostion.y);

        if (cell.type == Cell.Type.Invalid || cell.revealed) 
        {
            return;
        }

        cell.flagged = !cell.flagged;
        state[CellPostion.x, CellPostion.y] = cell;
        board.Draw(state);
    }

    private Cell GetCell(int x, int y)
    {
        if (IsValid(x, y))
        {
            return state[x, y];
        }
        else
        {
            return new Cell();
        }
    }

    private bool IsValid(int x, int y)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
    }
}
