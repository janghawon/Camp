using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;
using System;

public enum eSceneName
{
    None = -1,
    Loading,
    Logo,
    Title,
    Game
}

public class MZScene : MonoBehaviour
{
    private static MZScene _instance;
    public static MZScene Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType(typeof(MZScene)) as MZScene;
                if(_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.hideFlags = HideFlags.HideAndDontSave;
                    _instance = obj.AddComponent<MZScene>();
                }
            }

            return _instance;
        }
    }

    private StringBuilder _sb;
    private eSceneName _currentScene, _beforeScene;

    private Transform _uiRootTrm;
    private Transform _addUiTrm;

    public GameObject uiRootPrefab;
    public GameObject LoadingUiPrefab;

    public GameObject logoUiPrefab;
    public GameObject titleUiPrefab;
    public GameObject gameUiPrefab;


    public void Generate() { }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        _sb = new StringBuilder();
        GameObject uiRootObj = GameObject.Instantiate(uiRootPrefab) as GameObject;
        _uiRootTrm = uiRootObj.transform;

        InitScene();
    }

    private void InitScene()
    {
        _beforeScene = eSceneName.None;
        ChageScene(eSceneName.Logo);
    }

    public void ChageScene(eSceneName inScene)
    {
        _currentScene = inScene;

        _sb.Remove(0, _sb.Length);
        _sb.AppendFormat("{0}Scene", eSceneName.Loading);
        SceneManager.LoadScene(_sb.ToString());
        ChageUI(eSceneName.Loading);
    }

    private void ChageUI(eSceneName inScene)
    {
        if (_addUiTrm != null)
        {
            _addUiTrm.SetParent(null);
            GameObject.Destroy(_addUiTrm.gameObject);
        }

        GameObject go = null;

        if (inScene == eSceneName.Loading)
            go = GameObject.Instantiate(LoadingUiPrefab) as GameObject;
        else if (inScene == eSceneName.Logo)
            go = GameObject.Instantiate(logoUiPrefab) as GameObject;
        else if (inScene == eSceneName.Title)
            go = GameObject.Instantiate(titleUiPrefab) as GameObject;
        else if (inScene == eSceneName.Game)
            go = GameObject.Instantiate(gameUiPrefab) as GameObject;


        _addUiTrm = go.transform;
        _addUiTrm.SetParent(_uiRootTrm);

        _addUiTrm.localPosition = Vector3.zero;
        _addUiTrm.localScale = new Vector3(1, 1, 1);

        RectTransform rect = go.GetComponent<RectTransform>();
        rect.offsetMax = new Vector2(0, 0);
        rect.offsetMin = new Vector2(0, 0);
    }

    public void LoadingDone()
    {
        _beforeScene = _currentScene;
        ChageUI(_currentScene);
        Debug.Log("·Îµù ³¡");
    }
}
