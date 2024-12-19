using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponDataSO weaponData;

    private PoolManager poolManager;
    private float _currentDelay;
    private int _ammo;
    private float attackDelay;


    private void Awake()
    {
        poolManager = FindAnyObjectByType<PoolManager>();
    }
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
            
        }
    }

    private void Shoot()
    {
        _currentDelay = 0;
        --_ammo;
        poolManager.ProjectileSpawn(transform, weaponData.bulletSpeed, weaponData.isPenetration, weaponData.isDiffuse, weaponData.isBurst, weaponData.projectileCount);
    }

    // 웨폰 체인지 됐을 때 어택 딜레이, 탄창 초기화 시켜주기
    
    public void WeaponChange(WeaponDataSO weaponData)
    {
        this.weaponData = weaponData;
        GetComponent<SpriteRenderer>().sprite = weaponData.weaponImage;
        _currentDelay = weaponData.attackDelay;
        _ammo = weaponData.ammo;
    }
}