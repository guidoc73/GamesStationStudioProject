using UnityEngine;

public class EvilSquareManager : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private BoxCollider2D _boxCollider;

    [SerializeField] private float _timeToLaunchNewSquare;

    private float _countdown;
    private bool _gameFinished;

    private void OnEnable()
    {
        EventBus<bool>.Instance.Subscribe(CustomEvents.DEAD, SetGameFinished);
    }

    private void SetGameFinished(bool value)
    {
        _gameFinished = value;
    }

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (_boxCollider == null || _pool == null || _gameFinished) return;

        _countdown -= Time.deltaTime;

        if (_countdown <= 0)
        {
            var square = _pool.GetObjectFromPool();
            square.transform.position = GetRandomPosition();
            square.SetActive(true);

            _countdown = _timeToLaunchNewSquare;
        }
    }

    public void SetPool(ObjectPool pool)
    {
        _pool = pool;
    }

    private void OnDisable()
    {
        EventBus<bool>.Instance.Unsubscribe(CustomEvents.DEAD, SetGameFinished);
    }

    private Vector2 GetRandomPosition() =>
        new Vector2Int((int)Random.Range(_boxCollider.bounds.min.x, _boxCollider.bounds.max.x), 5);
}
