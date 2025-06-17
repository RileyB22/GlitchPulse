using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cell : MonoBehaviour
{
    [HideInInspector] public bool Blocked;
    [HideInInspector] public bool Filled;

    [SerializeField] private Color _blockedColor;
    [SerializeField] private Color _emptyColor;
    [SerializeField] private Color _filledColor;
   // [SerializeField] private Color _lockedColor;
    [SerializeField] private Image _cellRenderer;
   // [SerializeField] private Transform panelParent;

    public void Init(int fill)
    {
        Blocked = fill == 1;
        Filled = Blocked;
        _cellRenderer.color = Blocked ? _blockedColor : _emptyColor;
    }

    public void Add()
    {
        Filled = true;
        _cellRenderer.color = _filledColor;
    }
    public void Remove()
    {
        Filled = false;
        _cellRenderer.color = _emptyColor;
    }
    public void ChangeState()
    {
        Blocked = !Blocked;
        Filled = Blocked;
        _cellRenderer.color = Blocked ? _blockedColor : _emptyColor;
    }





    // [HideInInspector] public int Number {  get; set; }

    /*[HideInInspector] public int Row;
    [HideInInspector] public int Column;

    [SerializeField] private TMP_Text _numberText;
    [SerializeField] private SpriteRenderer _cellSprite;

    [SerializeField] private GameObject _right1;
    [SerializeField] private GameObject _right2;
    [SerializeField] private GameObject _top1;
    [SerializeField] private GameObject _top2;
    [SerializeField] private GameObject _left1;
    [SerializeField] private GameObject _left2;
    [SerializeField] private GameObject _bottom1;
    [SerializeField] private GameObject _bottom2;

    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _solvedColor;
    [SerializeField] private Color _inCorrectColor;

    private int number;
    private Dictionary<int, Dictionary<int, GameObject>> edges;
    private Dictionary<int, int> edgeCounts;
    private Dictionary<int, Cell> connectedCell;

    private const int RIGHT = 0;
    private const int TOP = 1;
    private const int LEFT = 2;
    private const int BOTTOM = 3;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
