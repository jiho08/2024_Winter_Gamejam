using UnityEngine;
using UnityEngine.Events;

public class PlayerInterct : MonoBehaviour
{
    Weapon weaponCompo;

    private void Awake()
    {
        weaponCompo = GetComponentInChildren<Weapon>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            weaponCompo.WeaponChange(collision.gameObject.GetComponent<DropWeapon>().weapon);
            Debug.Log($"{collision.gameObject.GetComponent<DropWeapon>().weapon.weaponName} ภๅย๘วิ");
            Destroy(collision.gameObject);
        }
    }
}
