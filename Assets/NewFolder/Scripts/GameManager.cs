using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    static private GameManager _instance; // Unique GameManager instance (Singleton Pattern).
    static public GameManager Instance // Public accesor for GameManager instance.
    {
        get
        {
            return _instance; // Para poder instanciar el GameManager y llamarlo desde cualquier script
        }
    }

    private int score = 0;
    private float time = 0;
    private float interval = 5;
    private float lastTime = 0;
    private TMP_Text textComp;

    private Button myButtonRun;
    private Button myButtonExit;
    private Button myButtonAjustes;
    private Button myButtonMenu;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (textComp != null)
        {
            time += Time.deltaTime;
            if (time > lastTime + interval)
            {
                score++;
                textComp.text = "SCORE - " + score;
                lastTime = time;
            }
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Nueva escena cargada: " + scene.name);
        // Código que quieres ejecutar en cada escena
        if (scene.name == "Jugar")
        {
            textComp = GameObject.Find("Score").GetComponent<TMP_Text>(); // Busca el componente en el mismo GameObject
        }
        else if (scene.name == "MenuPrincipal")
        {
            myButtonRun = GameObject.Find("ButtonRun").GetComponent<Button>(); // Busca el componente en el mismo GameObject
            myButtonRun.onClick.AddListener(Jugar);
            myButtonExit = GameObject.Find("ButtonExit").GetComponent<Button>(); // Busca el componente en el mismo GameObject
            myButtonExit.onClick.AddListener(Exit);
            myButtonAjustes = GameObject.Find("ButtonAjustes").GetComponent<Button>(); // Busca el componente en el mismo GameObject
            myButtonAjustes.onClick.AddListener(Ajustes);
        }
        else if (scene.name == "Ajustes")
        {
            myButtonMenu = GameObject.Find("ButtonMenu").GetComponent<Button>(); // Busca el componente en el mismo GameObject
            myButtonMenu.onClick.AddListener(Menu);
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Eliminar la suscripción para evitar errores
    }

    public void Jugar()
    {
        SceneManager.LoadScene("Jugar");
    }

    public void Ajustes()
    {
        SceneManager.LoadScene("Ajustes");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void Exit()
    {
        Application.Quit();
    }

}
