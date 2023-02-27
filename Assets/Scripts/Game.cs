using UnityEngine;

public class Game : MonoBehaviour
{
    //taille de la map 
    public int width = 16;
    public int height = 16;
    //nombre de mine sur le tableau
    private int countMine = 20;

    private Tab tab;
    private Cell[,] state;


    private void Awake()
    {
        tab = GetComponentInChildren<Tab>();
    }

    public void Start()
    {
        Play();
    }

    //lancement du jeu 
    private void Play()
    {
        state = new Cell[width, height];

        DrawMap();
        DrawMine();
        DrawNumber();

        Camera.main.transform.position = new Vector3(width / 2, height / 2, -10);

        tab.Board(state);
    }

    //creation de la map
    private void DrawMap()
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

    //initialisation des mine aleatoire 
    private void DrawMine()
    {
        for (int i = 0; i < countMine; i++)
        {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);

            while (state[x, y].type == Cell.Type.Mine)
            {
                x++;
                if (x > width)
                {
                    x = 0;
                    y++;
                    if (y > height)
                    {
                        y = 0;
                    }
                }
            }
            state[x, y].type = Cell.Type.Mine;
            //state[x, y].revealed = true;
        }
    }

    //initialisation des tile nombre en fonction des mine 
    private void DrawNumber()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Cell cell = state[i, j];

                if (cell.type == Cell.Type.Mine)
                {
                    continue;
                }

                cell.number = MineNumber(i, j);

                if (cell.number > 0)
                {
                    cell.type = Cell.Type.Number;
                }
                else
                {
                    cell.type = Cell.Type.Empty;
                }

                state[i, j] = cell;
                //state[i, j].revealed = true;
            }
        }
    }

    //range de chaque tile pour detecter les mine
    private int MineNumber(int posX, int posY)
    {
        int countNum = 0;

        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                int x = posX + i;
                int y = posY + j;

                if (i == 0 && j == 0)
                {
                    continue;
                }

                if (GetState(x, y).type == Cell.Type.Mine)
                {
                    countNum++;
                }
            }
        }
        return countNum;
    }

    //recuperation de la position sur le tableau 
    private Cell GetState(int x, int y)
    {
        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            return state[x, y];
        }
        else
        {
            return new Cell();
        }
    }

    private void SetFlag()
    {
        Vector3 mouseInScreen = Input.mousePosition;
        Vector3 mouseInWorld = Camera.main.ScreenToWorldPoint(mouseInScreen);
        Vector3Int pos = tab.map.WorldToCell(mouseInWorld);

        Cell cell = GetState(pos.x, pos.y);

        if (cell.flagged == true)
        {
            cell.flagged = false;
        }
        else
        {
            cell.flagged = true;
        }
        state[pos.x, pos.y] = cell;
        tab.Board(state);
    }

    void RevealedNum()
    {
        Vector3 mouseInScreen = Input.mousePosition;
        Vector3 mouseInWorld = Camera.main.ScreenToWorldPoint(mouseInScreen);
        Vector3Int pos = tab.map.WorldToCell(mouseInWorld);

        Cell cell = GetState(pos.x, pos.y);

        if(cell.revealed == false){
            cell.revealed = true;
        }
        state[pos.x, pos.y] = cell;
        tab.Board(state);

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SetFlag();
        }
        else if (Input.GetMouseButton(0))
        {
            RevealedNum();
        }
    }
}
