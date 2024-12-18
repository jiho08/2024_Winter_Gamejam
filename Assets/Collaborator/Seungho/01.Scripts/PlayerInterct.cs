using UnityEngine;
using UnityEngine.Events;

public class PlayerInterct : MonoBehaviour
{
    Weapon weaponCompo;

    private void Awake()
    {
        weaponCompo = GetComponentInChildren<Weapon>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
