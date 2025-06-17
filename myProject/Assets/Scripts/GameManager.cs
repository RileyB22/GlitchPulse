using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    public static GameManager Instance;

    [SerializeField] private Level _level;
    [SerializeField] private Cell _cellPrefab;
    //[SerializeField] private Cell panelParent;
    [SerializeField] private Transform _edgePrefab;

    private bool hasGameFinished;
    private Cell[,] cells;
    private List<Vector2Int> filledPoints;
    private List<Transform> edges;
    private Vector2Int startPos, endPos;
    private List<Vector2Int> directions = new List<Vector2Int>()
    {
        Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right
    };

    private void Awake ()
    {
        Instance = this;
        hasGameFinished = false;
        filledPoints = new List<Vector2Int>();
        cells = new Cell[_level.Row, _level.Col];
        edges = new List<Transform>();
        SpawnLevel();
    }

    private void SpawnLevel()
    {
        Vector3 camPos = Camera.main.transform.position;
        camPos.x = _level.Col * 0.5f;
        camPos.y = _level.Row * 0.5f;
        Camera.main.transform.position = camPos;
        Camera.main.orthographicSize = Mathf.Max(_level.Row, _level.Col) + 2f;

        for (int i =0; i < _level.Row; i++)
        {
            for (int j  =0; j < _level.Col; j++)
            {
                cells[i, j] = Instantiate(_cellPrefab/*, panelParent*/);
               // cells[i, j].transform.SetParent(panelParent, false); // Attach to UI Panel

                cells[i, j].Init(_level.Data[i*_level.Col + j]);
                cells[i, j].transform.position = new Vector3(j + 0.5f, i + 0.5f, 0);
            }
        }
    }

    private void CheckWin()
    {
        for (int i = 0; i < _level.Row; i++)
        {
            for(int j = 0; j < _level.Col;j++)
            {
                if (!cells[i, j].Filled)
                    return;
            }
        }

        hasGameFinished = true;
        StartCoroutine(GameFinished());
    }
    private IEnumerator GameFinished()
    {
        yield return new WaitForSeconds(2f);
        //change this to go to runner level
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }



    /*// puzzle stuff
    public static GameManager Instance;

    public bool isGameOver;

    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private SpriteRenderer _bgSprite;
    [SerializeField] private SpriteRenderer _highlightSprite;
    [SerializeField] private Vector2 _highlightSize;
    [SerializeField] private LevelData levelData;
    [SerializeField] private float _cellGap;
    [SerializeField] private float _cellSize;
    [SerializeField] private float _LevelGap;

    private int[,] levelGrid;
    private Cell[,] cellGrid;
    private Cell startCell;
    private Vector2 startPos;

    private List<Vector3Int> Directions = new List<Vector3Int>()
    {Vector3Int.up, Vector3Int.right, Vector3Int.down, Vector3Int.left };

    private void Awake()
    {
        Instance = this;
        isGameOver = false;
        _highlightSprite.gameObject.SetActive(false);
        levelGrid = new int[_levelData.row, _levelData.col];
        cellGrid = new Cell[_levelData.row, _levelData.col];
        for (int i=0; i < _levelData.col; i++)
        {
            for (int j = 0; j < _levelData.col; j++)
            {
                cellGrid[i, j] = _levelData.data[i * _levelData.row + j];
            }  
        }

        SpawnLevel();
    }

    private void SpawnLevel()
    {
        float width = (_cellSize + _cellGap) * _levelData.col - _cellGap + _LevelGap;
        float height = (_cellSize + _cellGap) * _levelData.row - _cellGap + _LevelGap;
        _bgSprite.size = new Vector2(width, height);
        Vector3 bgPos = new Vector3(width / 2f - _cellSize / 2f - _levelGap / 2f, height / 2f - _cellSize / 2f - _levelGap / 2f);

        Camera.main.orthographicSize = width * 1.2f; 
        Camera.main.transform.position = new Vector3(bgPos.x, bgPos.y, -10f);

        Vector startPos = Vector3.zero;
        Vector3 rightOffset = Vector3.right * (_cellSize + _cellGap);
        Vector3 topOffset = Vector3.up * (_cellSize + _cellGap);

        for (int i = 0; i < levelData.row; i ++)
        {
            for (int j = 0; j < _levelData.col; j++)
            {
                Vector3 spawnPos = startPos + j * rightOffset + i * topOffset ;
                Cell tempCell = Instantiate(_cellPrefab, spawnPos, Quaternion.identity);
                tempCell.Number = levelGrid[i, j];
                cellGrid[i, j] = tempCell;
                if(tempCell.Number == 0)
                {
                    Destroy(tempCell.gameObject);
                    cellGrid[i, j] = null;
                }
            }
        }


    }




    [System.Serializable]
    public struct LevelData
    {
        public int row, col;
        public List<int> data;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
