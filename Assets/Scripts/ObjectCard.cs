using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectCard : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject object_Drag;
    public GameObject object_Game;
    public Canvas canvas;
    public GameObject objectDragInstance;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }
    public void OnDrag(PointerEventData eventData)
    {
        objectDragInstance.transform.position = Input.mousePosition;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        objectDragInstance = Instantiate(object_Drag, canvas.transform);
        objectDragInstance.transform.position = Input.mousePosition;
        objectDragInstance.GetComponent<ObjectDragging>().card = this;

        GameManager.instance.draggingObject = objectDragInstance;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        gameManager.PlaceObject();
        GameManager.instance.draggingObject = null;
        Destroy(objectDragInstance);
    }
}
