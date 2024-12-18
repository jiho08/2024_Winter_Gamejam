using UnityEngine;

[CreateAssetMenu(fileName = "GunDataSO", menuName = "SO/Weapon/GunDataSO")]
public class GunDataSO : WeaponDataSO
{
    public GameObject bulletPrefab;
    public int bulletCount;
}
