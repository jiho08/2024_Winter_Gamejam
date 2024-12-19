using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearManager : MonoBehaviour
{
    public int mission = 0; // 0 : ��� �� óġ, 1 : Ż�� ���� ����
    private TextAction text;
    public float timer;
    public Transform enemys;
    private float enemyCount;



    private void Awake()
    {
        text = FindAnyObjectByType<TextAction>();
    }
    public void Start()
    {
        enemyCount = enemys.GetComponentsInChildren<Enemy>().Length;
        StageStart();
    }
    private void Update()
    {
        timer += Time.deltaTime;
    }

    public void StageStart()
    {
        
        switch (mission)
        {
            case 0:
                text.ShowText("��� �� óġ");
                break;

            case 1:
                text.ShowText("Ż�� ���� ����");
                break;
        }
    }

    public IEnumerator StageClear(string message)
    {
        text.ShowText(message);
        yield return new WaitForSecondsRealtime(1f);
        
    }
}
