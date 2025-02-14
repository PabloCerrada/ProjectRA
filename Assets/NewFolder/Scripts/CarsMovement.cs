using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarsMovement : MonoBehaviour
{
    private Transform carTransform;

    [SerializeField]
    private int speed;

    [SerializeField]
    private Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        carTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        carTransform.Translate(dir * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Se suma la rata cuando entra al trigger
        PlayerInputComponent playerComp = other.gameObject.GetComponent<PlayerInputComponent>();
        if (playerComp != null)
        {
            SceneManager.LoadScene("MenuPrincipal");//GameManager.Instance.Menu();
        }

        Debug.Log("Entro");
        carTransform.Translate(dir * -140);
    }
}
