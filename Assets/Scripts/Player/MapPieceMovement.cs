using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPieceMovement : MonoBehaviour
{
    private enum directions
    {
        LEFT = 1,
        RIGHT = 2,
        UP = 4,
        DOWN = 8
    }

    [SerializeField]
    private GameObject _pivotParent;

    private List<PivotDetail> _pivotList = new List<PivotDetail>();
    private bool _isMoving;
    private MapPiecesController _currentMapPiece;

    private void Start()
    {
        for(int i = 0; i < _pivotParent.transform.childCount; i++)
        {
            _pivotList.Add(_pivotParent.transform.GetChild(i).GetComponent<PivotDetail>());
        }
    }

    private void Update()
    {
        if(_currentMapPiece != null)
            _isMoving = _currentMapPiece.GetIsMoving();
        if (_isMoving)
            return;


        if (Input.GetKeyDown(KeyCode.A))
        {
            OnMovingLeft();
            return;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            OnMovingRight();
            return;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            OnMovingUp();
            return;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            OnMovingDown();
            return; 
        }
    }

    private void OnMovingLeft()
    {
        foreach(PivotDetail i in _pivotList)
        {
            if (i.CanMoveToDirection((int)directions.LEFT))
            {
                _currentMapPiece = i.GetCurrentMapPiece();
                _currentMapPiece.MoveToPivot((int)directions.LEFT);
                _isMoving = true;
                return;
            }
        }
    }

    private void OnMovingRight()
    {
        foreach (PivotDetail i in _pivotList)
        {
            if (i.CanMoveToDirection((int)directions.RIGHT))
            {
                _currentMapPiece = i.GetCurrentMapPiece();
                _currentMapPiece.MoveToPivot((int)directions.RIGHT);
                _isMoving = true;
                return;
            }
        }

    }

    private void OnMovingUp()
    {
        foreach (PivotDetail i in _pivotList)
        {
            if (i.CanMoveToDirection((int)directions.UP))
            {
                _currentMapPiece = i.GetCurrentMapPiece();
                _currentMapPiece.MoveToPivot((int)directions.UP);
                _isMoving = true;
                return;
            }
        }
    }

    private void OnMovingDown()
    {
        foreach (PivotDetail i in _pivotList)
        {
            if (i.CanMoveToDirection((int)directions.DOWN))
            {
                _currentMapPiece = i.GetCurrentMapPiece();
                _currentMapPiece.MoveToPivot((int)directions.DOWN);
                _isMoving = true;
                return;
            }
        }
    }

}
