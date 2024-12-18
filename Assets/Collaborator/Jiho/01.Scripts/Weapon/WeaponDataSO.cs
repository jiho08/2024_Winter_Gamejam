using UnityEngine;

public class WeaponDataSO : ScriptableObject
{
    public string weaponName;
    public float attackDelay;
    public float attackRange;
    public Sprite weaponImage;
    public GameObject projectilePrefab;
    public int projectileCount;
}
