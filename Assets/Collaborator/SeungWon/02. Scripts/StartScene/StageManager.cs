using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;

    [SerializeField] private GameObject stagesPrefabs;
    [SerializeField] private StageSO[] stageSo;
    [SerializeField] private Transform stagesTransform;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < stageSo.Length; i++)
        {
            GameObject stage = Instantiate(stagesPrefabs, stagesTransform);
            stage.GetComponent<Stage>().stageSO = stageSo[i];
        }
        gameObject.SetActive(false);
    }

    public void StageLoad(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }
}
