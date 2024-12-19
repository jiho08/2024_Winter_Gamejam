using UnityEngine;

public class ExitPoint : MonoBehaviour
{
    public LayerMask enterLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(((1 << collision.gameObject.layer) & enterLayer) != 0)
        {
            GameManager.instance.StageClear("Á» ÃÆ´Ù¤»¤»");
        }
    }
}
