using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponDataSO weaponData;

    private float _currentDelay;
    private int _ammo;

    private void Start()
    {
        _currentDelay = weaponData.attackDelay;
        _ammo = weaponData.ammo;
    }

    private void Update()
    {
        _currentDelay += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            if (_currentDelay < weaponData.attackDelay || _ammo <= 0)
            {
                // 안된다는 효과음 재생
                return;
            }

            Shoot();
            --_ammo;
        }
    }

    private void Shoot()
    {
        PoolManager.ProjectileSpawn(transform, weaponData.bulletSpeed, weaponData.isPenetration, weaponData.isDiffuse, weaponData.projectileCount);
    }

    // 웨폰 체인지 됐을 때 어택 딜레이, 탄창 초기화 시켜주기
    
    public void WeaponChange(WeaponDataSO weaponData)
    {
        this.weaponData = weaponData;
        _currentDelay = weaponData.attackDelay;
        _ammo = weaponData.ammo;
    }
}