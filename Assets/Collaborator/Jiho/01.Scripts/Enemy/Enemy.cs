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

    [SerializeField] private GameObject weapon;

    [SerializeField] private WeaponDataSO weaponData;
    [SerializeField] private GameObject deadParticle;

    [SerializeField] private DropWeapon dropWeapon;

    private NavMeshAgent _agent;
    private SpriteRenderer _renderer;

    private readonly float _checkTimer = 0.3f;
    private float _lastCheckTime;

    private void Awake()
    {
        dropWeapon.weapon = weaponData;
        _agent = GetComponent<NavMeshAgent>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void Update()
    {
        LookAtTarget();

        _renderer.enabled = !CheckTargetBetweenWall();
        weapon.SetActive(!CheckTargetBetweenWall());

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
            StopCoroutine(Shoot());
            _agent.SetDestination(target.position);
        }
        else if (CheckTargetInCheckRadius() && CheckTargetInAttackRadius())
        {
            StartCoroutine(Shoot());
        }
        else if (!CheckTargetInCheckRadius() && !CheckTargetInAttackRadius())
        {
            StopCoroutine(Shoot());
            _agent.SetDestination(transform.position);
        }
    }

    private IEnumerator Shoot()
    {
        PoolManager.ProjectileSpawn(weapon.transform, weaponData.bulletSpeed, weaponData.isPenetration, weaponData.isDiffuse, weaponData.projectileCount);

        yield return new WaitForSeconds(weaponData.attackDelay);
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
            var direction = collision.transform.position - transform.position;
            var angle = Vector2.Angle(direction.normalized, transform.right);

            if (angle >= attackAngle * 0.5f)
                return false;

            var hit = Physics2D.Raycast(transform.position, direction.normalized,
                direction.magnitude, whatIsObstacle);

            if (hit.collider == null && collision.TryGetComponent(out PlayerMove player))
            {
                target = player.transform;
                return true;
            }
        }

        return false;
    }

    private bool CheckTargetBetweenWall()
    {
        var collision = Physics2D.OverlapCircle(transform.position, targetCheckRadius, whatIsPlayer);

        if (collision != null)
        {
            var direction = collision.transform.position - transform.position;

            var hit = Physics2D.Raycast(transform.position, direction.normalized,
                direction.magnitude, whatIsObstacle);

            if (hit.collider == null && collision.CompareTag("Player"))
                return false;
        }

        return true;
    }

    private void LookAtTarget()
    {
        Vector2 targetPos;
        float angle;

        targetPos.x = target.transform.position.x - transform.position.x;
        targetPos.y = target.transform.position.y - transform.position.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void Dead()
    {
        Instantiate(dropWeapon, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Dead();
            Instantiate(deadParticle, transform.position, Quaternion.identity);
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