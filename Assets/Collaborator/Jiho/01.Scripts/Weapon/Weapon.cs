using System;
using Hellmade.Sound;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponDataSO weaponData;
    [SerializeField] private AudioClip shootSound, noSound;
    [SerializeField] private WeaponUI weaponUI;
    
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
        weaponUI.GetCurrentWeapon(weaponData.dropWeaponImage, _ammo);
    }

    private void Update()
    {
        _currentDelay += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            if (_currentDelay < weaponData.attackDelay || _ammo <= 0)
            {
                // 안된다는 효과음 재생
                EazySoundManager.PlaySound(noSound);
                return;
            }

            Shoot();
            
        }
    }

    private void Shoot()
    {
        EazySoundManager.PlaySound(shootSound);
        _currentDelay = 0;
        --_ammo;
        weaponUI.GetCurrentAmmo(_ammo);
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