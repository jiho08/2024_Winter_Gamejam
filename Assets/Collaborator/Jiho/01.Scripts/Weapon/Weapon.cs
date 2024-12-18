using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponDataSO data;
    private float attackDelay;
    private float attackRange;
    private GameObject projectilePrefab;
    private int projectileCount;

    private void Awake()
    {
        attackDelay = data.attackDelay;
        attackRange = data.attackRange;
        projectilePrefab = data.projectilePrefab;
        projectileCount = data.projectileCount;
    }

    private void Shoot()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }
}
