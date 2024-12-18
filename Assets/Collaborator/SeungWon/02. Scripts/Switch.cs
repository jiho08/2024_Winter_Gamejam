using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool open = false;
    [SerializeField] private Sprite openSwitchImage, closeSwitchImage;
    private SpriteRenderer spriteRenderer;
    public LayerMask playerLayer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = open ? openSwitchImage : closeSwitchImage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & playerLayer) != 0)
        {
            open = true;
            spriteRenderer.sprite = openSwitchImage;
        }
    }
}
