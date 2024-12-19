using UnityEngine;

public class DropWeapon : MonoBehaviour
{
    public WeaponDataSO weapon;

    private void OnEnable()
    {
        GetComponent<SpriteRenderer>().sprite = weapon.weaponImage;
        transform.rotation = Quaternion.Euler(0,0,Random.Range(0, 180));
    }
}
