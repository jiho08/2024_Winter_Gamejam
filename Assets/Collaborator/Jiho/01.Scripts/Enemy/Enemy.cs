using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float targetCheckRadius, targetCheckAngle;
    [SerializeField] private float attackRadius, attackAngle;
    
    [SerializeField] private Transform target;
    
    [SerializeField] private LayerMask whatIsPlayer, whatIsObstacle;

    private NavMeshAgent _agent;
    
    // 무기 가져오기

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void Update()
    {
        //_agent.SetDestination(target.position);
        
        if (CheckTargetInCheckRadius() && !CheckTargetInAttackRadius())
        {
            _agent.SetDestination(target.position); // 따라가기
        }
        else if (CheckTargetInCheckRadius() && CheckTargetInAttackRadius())
        {
            // 어택
        }
        else if (!CheckTargetInCheckRadius())
        {
            _agent.SetDestination(transform.position);
        }
    }

    private bool CheckTargetInCheckRadius()
    {
        var collision = Physics2D.OverlapCircle(transform.position, targetCheckRadius, whatIsPlayer);
        
        if (collision != null)
        {
            var direction = collision.transform.position - transform.position;
            var angle = Vector2.Angle(direction.normalized, transform.right);
            
            if (angle >= targetCheckAngle * 0.5f)
                return false;
            
            //if (collision.TryGetComponent(out Player player))
            {
                //target = player;
                return true;
            }
        }
        
        return false;
    }
    
    private bool CheckTargetInAttackRadius()
    {
        var collision = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);
        
        if (collision != null)
        {
            var direction = collision.transform.position - transform.position;
            var angle = Vector2.Angle(direction.normalized, transform.right);
            
            if (angle >= attackAngle * 0.5f)
                return false;
            
            var hit = Physics2D.Raycast(transform.position, direction.normalized,
                direction.magnitude, whatIsObstacle);
            
            //if (hit.collider == null && collision.TryGetComponent(out Player player))
            {
                //target = player;
                return true;
            }
        }
        
        return false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            // 사망
            Destroy(gameObject);
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, targetCheckRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.white;
    }
}
