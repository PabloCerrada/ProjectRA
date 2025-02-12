using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInputComponent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Transform playerTransform;

    [SerializeField]
    private int speed;

    bool holdingLeft = false, holdingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (holdingLeft)
        {
            playerTransform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (holdingRight)
        {
            playerTransform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    public void OnPointerDown(PointerEventData eventData) // Evento de presionar
    {
        // Interfaz
    }

    public void OnPointerUp(PointerEventData eventData) // Evento de soltar
    {
        // Interfaz
    }

    public void OnPointerDownLeft() // Evento de presionar
    {
        holdingLeft = true;
    }

    public void OnPointerUpLeft() // Evento de soltar
    {
        holdingLeft = false;
    }
    public void OnPointerDownRight() // Evento de presionar
    {
        holdingRight = true;
    }

    public void OnPointerUpRight() // Evento de soltar
    {
        holdingRight = false;
    }
}
