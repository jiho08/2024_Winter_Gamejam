using UnityEngine;

[CreateAssetMenu(menuName = "SO/WeaponData")]
public class WeaponDataSO : ScriptableObject
{
    public string weaponName;
    public float attackDelay;
    public float attackRange;
    public Sprite weaponImage;
    public GameObject projectilePrefab;
    public int projectileCount;
}
