using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Assertions.Must;
public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Collider2D playerCollider;
    public Collider2D enemyCollider;

    public Transform Player;
    public float enemySpeed = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float distance = Vector2.Distance(Player.position, transform.position);

        if (enemyCollider.IsTouching(playerCollider))
        {
            rb.linearVelocity = Vector2.zero;
            Debug.Log("Touched");
        }
        else if (distance <= 5f)
        {
            Vector2 direction = (Player.position - transform.position).normalized;
            transform.position += (Vector3)direction * enemySpeed * Time.deltaTime;
        }
    }
}