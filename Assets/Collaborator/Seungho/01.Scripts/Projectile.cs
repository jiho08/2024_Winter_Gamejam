using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        rb.AddForce(Input.mousePosition.normalized * 10, ForceMode2D.Impulse);
    }
}
