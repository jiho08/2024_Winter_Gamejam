using UnityEngine;

[CreateAssetMenu(menuName = "SO/Weapon/WeaponDataSO")]
public class WeaponDataSO : ScriptableObject
{
    public string weaponName;
    public float attackDelay;
    public float attackRange;
    public Sprite weaponImage;
    public GameObject projectilePrefab;
    public int projectileCount;
}
