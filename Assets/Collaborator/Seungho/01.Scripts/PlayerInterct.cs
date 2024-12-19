using Hellmade.Sound;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInterct : MonoBehaviour
{
    [SerializeField] private AudioClip weaponInteractSound;
    
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
            weaponCompo.WeaponChange(collision.gameObject.GetComponent<DropWeapon>().weapon);
            Destroy(collision.gameObject);
        }
    }
}
