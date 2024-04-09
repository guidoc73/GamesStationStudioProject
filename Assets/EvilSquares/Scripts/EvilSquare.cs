using UnityEngine;

public class EvilSquare : MonoBehaviour
{
    [SerializeField] private float _speed;


    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * _speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Ground"))
            gameObject.SetActive(false);
    }
}
