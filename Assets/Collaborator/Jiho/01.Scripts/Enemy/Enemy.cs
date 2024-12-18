using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float targetCheckRadius, targetCheckAngle;
    [SerializeField] private float attackRadius, attackAngle;

    [SerializeField] private Transform target;

    [SerializeField] private LayerMask whatIsPlayer, whatIsObstacle;

    // 무기 가져오기
    [SerializeField] private WeaponDataSO _weapon;

    private NavMeshAgent _agent;

    private readonly float _checkTimer = 0.3f;
    private float _lastCheckTime;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void Update()
    {
        LookAtTarget();
        if (_lastCheckTime + _checkTimer < Time.time)
        {
            _lastCheckTime = Time.time;
            CheckTarget();
            
        }

        //_agent.SetDestination(target.position);
    }

    private void CheckTarget()
    {
        if (CheckTargetInCheckRadius() && !CheckTargetInAttackRadius())
        {
            Debug.Log("따라가기");
            StopCoroutine(Shoot());
            _agent.SetDestination(target.position); // 따라가기
        }
        else if (CheckTargetInCheckRadius() && CheckTargetInAttackRadius())
        {
            Debug.Log("어택");
            StartCoroutine(Shoot());
        }
        else if (!CheckTargetInCheckRadius() && !CheckTargetInAttackRadius())
        {
            Debug.Log("가만히");
            StopCoroutine(Shoot());
            _agent.SetDestination(transform.position);
        }
    }

    private IEnumerator Shoot()
    {
        
        PoolManager.Spawn(0, transform.GetChild(0));

        yield return new WaitForSeconds(_weapon.attackDelay);
    }

    private bool CheckTargetInCheckRadius()
    {
        var collision = Physics2D.OverlapCircle(transform.position, targetCheckRadius, whatIsPlayer);

        if (collision != null)
        {
            // var direction = collision.transform.position - transform.position;
            // var angle = Vector2.Angle(direction.normalized, transform.right);
            //
            // if (angle >= targetCheckAngle * 0.5f)
            //     return false;

            if (collision.TryGetComponent(out PlayerMove player))
            {
                target = player.transform;
                return true;
            }
        }

        return false;
    }

    private bool CheckTargetInAttackRadius()
    {
        var collision = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);
        Debug.Log(collision);

        if (collision != null)
        {
            Debug.Log("어택 라디우스 안");
            var direction = collision.transform.position - transform.position;
            // var angle = Vector2.Angle(direction.normalized, transform.right);
            //
            // if (angle >= attackAngle * 0.5f)
            //     return false;

            // var hit = Physics2D.Raycast(transform.position, direction.normalized,
            //     direction.magnitude, whatIsObstacle);

            if (collision.TryGetComponent(out PlayerMove player))
            {
                target = player.transform;
                return true;
            }
        }

        return false;
    }
    
    public void LookAtTarget()
    {
        Vector2 targetPos;
        float angle;

        targetPos.x = target.transform.position.x - transform.position.x;
        targetPos.y = target.transform.position.y - transform.position.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
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