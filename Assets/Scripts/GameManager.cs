using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private GameObject[] characters;

    private int _charIndex;
    public int charIndex
    {
        get { return _charIndex; }
        set { _charIndex = value; }
    }

    //only 1 gameobject in gameManager
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //để gameObject chuyển từ scene to another scene
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }
    //tại sao gọi hàm k cần truyền tham số?
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "GamePlay")
        {
            Instantiate(characters[charIndex]);
        }
    }

}
