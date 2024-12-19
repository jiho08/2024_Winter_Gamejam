using System.Collections;
using Hellmade.Sound;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PlayerDeadCheck : MonoBehaviour
{
    [SerializeField] private AudioClip deadSound;
    
    public ParticleSystem deadParticle;
    public GameManager gameManager;

    public PlayerMove player;
    public bool isDead = false;
    Coroutine coroutine = null;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    private void Start()
    {
        

    }

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

            Dead();
        }
    }

    public void Dead()
    {
        EazySoundManager.PlaySound(deadSound);
        player.inputAction.Player.Disable();
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        transform.GetChild(0).gameObject.SetActive(false);
        Instantiate(deadParticle, player.transform.position, Quaternion.identity);
        Time.timeScale = 0.1f;
        coroutine = StartCoroutine(DeadCoroutine());
    }

    IEnumerator DeadCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(gameManager.Noise());
        yield return new WaitForSeconds(1f);
        isDead = false;
        SceneManager.LoadScene(SceneManager.sceneCount);
    }



    




}
