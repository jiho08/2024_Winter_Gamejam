using UnityEngine;

[CreateAssetMenu(menuName = "SO/Weapon/WeaponDataSO")]
public class WeaponDataSO : ScriptableObject
{
    public string weaponName;
    public Sprite dropWeaponImage;
    public Sprite weaponImage;
    
    public GameObject projectilePrefab;
    public int projectileCount;
    
    public int ammo;
    public float bulletSpeed;
    public float attackDelay;
    public float attackRange;
    
    public bool isPenetration;
    public bool isDiffuse;
}
