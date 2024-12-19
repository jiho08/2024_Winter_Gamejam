using System;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponUI : UIToolkit
{
    private const string _weaponStr = "VisualElement_Weapon";
    private const string _imageStr = "VisualElement_Image";
    private const string _currentAmmoStr = "Label_CurrentAmmo";
    private const string _maxAmmoStr = "Label_MaxAmmo";

    private VisualElement _weaponVisualElement;
    private VisualElement _imageVisualElement;
    
    private Label _currentAmmoLabel;
    private Label _maxAmmoLabel;

    private void OnEnable()
    {
        GetUIElements();
    }

    protected override void GetUIElements()
    {
        base.GetUIElements();

        _weaponVisualElement = root.Q<VisualElement>(_weaponStr);
        _imageVisualElement = root.Q<VisualElement>(_imageStr);
        
        _currentAmmoLabel = root.Q<Label>(_currentAmmoStr);
        _maxAmmoLabel = root.Q<Label>(_maxAmmoStr);
    }
    
    public void GetCurrentWeapon(Sprite weapon, int ammo)
    {
        _imageVisualElement.style.backgroundImage = weapon.texture;
        _currentAmmoLabel.text = $"{ammo}/";
        _maxAmmoLabel.text = ammo.ToString();
    }
    
    public void GetCurrentAmmo(int ammo)
    {
        _currentAmmoLabel.text = $"{ammo}/";
    }
    
    // 무기 정보 받아오기 (무기 바뀔 때)
    // 총알 개수 받아오기 (공격할 때)
}