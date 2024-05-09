using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    // ��Ϸ������
    // Start is called before the first frame update
    public static Manager instance;

    [SerializeField]
    public GameObject[] Characters;

    private int _charIndex;
    public int CharIndex
    {
        get { return _charIndex; }
        set { _charIndex = value; }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()// ���Ĵ˷���
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }
    private void OnDisable()// ɾ���˷���
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }
    void OnLevelFinishedLoading(UnityEngine.SceneManagement.Scene scene,LoadSceneMode mode)
    {
        if(scene.name == "GamePlay")
        {
            Instantiate(Characters[CharIndex]);
        }
    }
}
