using System;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponUI : UIToolkit
{
    private const string _weaponStr = "VisualElement_Weapon";
    private const string _imageStr = "VisualElement_Image";
    private const string _ammoStr = "Label_Ammo";

    private VisualElement _weaponVisualElement;
    private VisualElement _imageVisualElement;
    
    private Label _ammoLabel;
    
    protected override void GetUIElements()
    {
        base.GetUIElements();

        _weaponVisualElement = root.Q<VisualElement>();
        _imageVisualElement = root.Q<VisualElement>();
        
        _ammoLabel = root.Q<Label>();
    }
    
    // 무기 정보 받아오기 (무기 바뀔 때)
    // 총알 개수 받아오기 (공격할 때)
}