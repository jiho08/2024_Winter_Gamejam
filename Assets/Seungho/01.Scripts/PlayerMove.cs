using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMove : MonoBehaviour
{
    InputSystem_Actions inputAction;
    Rigidbody2D rb;

    public float speed = 1;

    Vector2 inputVector;
    

    private void Awake()
    {
        inputAction = new InputSystem_Actions();

        inputAction.Player.Enable();

        rb = GetComponent<Rigidbody2D>();    
    }

    private void Update()
    {
        inputVector = inputAction.Player.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Move();
        LookAtMouse();
    }

    public void Move()
    {
        rb.linearVelocity = inputVector * speed;
    }

    public void LookAtMouse()
    {
        Vector2 targetPos;
        float angle;

        targetPos.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        targetPos.y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }
    
}