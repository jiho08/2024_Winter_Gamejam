using Hellmade.Sound;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInterct : MonoBehaviour
{
    [SerializeField] private AudioClip weaponInteractSound;
    [SerializeField] private WeaponUI weaponUI;
    
    Weapon weaponCompo;

    private void Awake()
    {
        weaponCompo = GetComponentInChildren<Weapon>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            EazySoundManager.PlaySound(weaponInteractSound);

            var data = collision.gameObject.GetComponent<DropWeapon>().weapon;
            
            weaponUI.GetCurrentWeapon(data.dropWeaponImage, data.ammo);
            weaponCompo.WeaponChange(data);
            Destroy(collision.gameObject);
        }
    }
}
