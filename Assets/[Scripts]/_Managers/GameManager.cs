using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isTutorialPlayed = false;
    public int level = 1;

    #region Singleton
    public static GameManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            GetDependencies();
        }
        else
        {
            DestroyImmediate(this);
        }
    }
    #endregion

    private void GetDependencies()
    {
        //if level variable set -1, game run as mobile
        //if we want to play specific level on editor, change -1 to value we want
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer || level == -1)
        {
            level = DataManager.instance.level;
        }

        // Get neccessary prefab assets here from resources folder. And use into another script
        // ****
        // i.e: if you need to explosion particle, save your particle in resources folder and get it in here
        // On the top side, assign variable as [HideInInspector] public GameObject explosionPrefab;
        // in here, explosionPrefab = Resources.Load<GameObject>("explosion-prefab"); or explosionPrefab = Resources.Load<ParticleSystem>("explosion-prefab"); depends your need
        // and instantiate it as Instantiate(GameManager.instance.explosionPrefab) from place you want.
        // ****
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel() {
        DataManager.instance.SetLevel(++level);
        Invoke("LoadNextScene", 1.2f);
    }

    public void LoadNextScene() {
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}