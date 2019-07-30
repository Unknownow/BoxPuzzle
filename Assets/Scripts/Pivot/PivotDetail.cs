using UnityEngine;

public class PivotDetail : MonoBehaviour
{
    private enum directions
    {
        LEFT = 1,
        RIGHT = 2,
        UP = 4,
        DOWN = 8
    }

    [SerializeField]
    private PivotDetail _leftPivot;

    [SerializeField]
    private PivotDetail _rightPivot;

    [SerializeField]
    private PivotDetail _upperPivot;

    [SerializeField]
    private PivotDetail _lowerPivot;

    private bool _hasMapPieces;
    private MapPiecesController _currentMapPiece;


    public Vector2 getPosition(int pos)
    {
        switch (pos)
        {
            case (int)directions.LEFT:
                return _leftPivot != null ? _leftPivot.transform.position : new Vector3(0, 0, 0);
            case (int)directions.RIGHT:
                return _rightPivot != null ? _rightPivot.transform.position : new Vector3(0, 0, 0);
            case (int)directions.UP:
                return _upperPivot != null ? _upperPivot.transform.position : new Vector3(0, 0, 0);
            case (int)directions.DOWN:
                return _lowerPivot != null ? _lowerPivot.transform.position : new Vector3(0, 0, 0);
            default:
                return new Vector2(0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Map Piece"))
        {
            _hasMapPieces = true;
            _currentMapPiece = collision.GetComponent<MapPiecesController>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Map Piece"))
        {
            _hasMapPieces = false;
            _currentMapPiece = null;
        }
    }

    public bool CanMoveToThisPivot()
    {
        return !_hasMapPieces;
    }

    public bool CanMoveToDirection(int direction)
    {
        switch (direction)
        {
            case (int)directions.LEFT:
                return (_leftPivot  != null) && _leftPivot.CanMoveToThisPivot();

            case (int)directions.RIGHT:
                return (_rightPivot != null) && _rightPivot.CanMoveToThisPivot();

            case (int)directions.UP:
                return (_upperPivot != null) && _upperPivot.CanMoveToThisPivot();

            case (int)directions.DOWN:
                return (_lowerPivot != null) && _lowerPivot.CanMoveToThisPivot();
        }
        return false;
    }

    public MapPiecesController GetCurrentMapPiece()
    {
        return _currentMapPiece;
    }
}
