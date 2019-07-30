using UnityEngine;

public class MapPiecesController : MonoBehaviour
{
    private enum directions
    {
        LEFT = 1,
        RIGHT = 2,
        UP = 4,
        DOWN = 8
    }


    [SerializeField]
    private GameObject _startPivot;

    private PivotDetail _currentPivot;
    private bool _isMoving;
    private Vector2 _targetPosition;


    private void Start()
    {
        gameObject.transform.position = _startPivot.transform.localPosition;
        _isMoving = false;
    }

    private void Update()
    {
        if (!_isMoving)
            return;
        
        Vector2 temp = transform.position;
        if (Vector2.Distance(temp, _targetPosition) > 0.5f)
        {
            transform.position = Vector3.Lerp(temp, _targetPosition, Time.deltaTime * 10);
        }
        else
        {
            transform.position = Vector3.Lerp(temp, _targetPosition, 1);
        }
        _isMoving &= !(transform.position.Equals(_targetPosition));
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Pivot"))
        {
            _currentPivot = collision.GetComponent<PivotDetail>(); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Pivot"))
        {
            _currentPivot = null;
        }
    }

    public void MoveToPivot(int direction)
    {
        _isMoving = true;
        _targetPosition = _currentPivot.getPosition(direction);
    }

    public bool GetIsMoving()
    {
        return _isMoving;
;    }
}
