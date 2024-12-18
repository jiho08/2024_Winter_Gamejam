using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PlayerDeadCheck : MonoBehaviour
{
    public ParticleSystem deadParticle;
    public GameObject noise;
    public PlayerMove player;
    public bool isDead = false;
    Coroutine coroutine = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            isDead = true;
            PoolManager.Return(0, collision.gameObject);
        }
    }

    private void Update()
    {
        if (isDead && coroutine == null)
        {
            isDead = false;
            player.inputAction.Player.Disable();
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            transform.GetChild(0).gameObject.SetActive(false);
            Instantiate(deadParticle, player.transform.position, Quaternion.identity);
            
            coroutine = StartCoroutine(Dead());
        }
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1.0f;
        noise.SetActive(true);
        yield return new WaitForSeconds(1f);

        
        SceneManager.LoadScene("PlayerTestScene");
    }


}
