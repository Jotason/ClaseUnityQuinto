using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemControlle : MonoBehaviour
{
    BoxCollider item;
    public Image iconEmpty;
    public Image itemIcon;
    public Transform equipSlot;
    //private bool canCollect = false; // Variable para verificar si se puede recoger el ítem
    void Start()
    {
        item = GetComponentInChildren<BoxCollider>();
    }

    void Update()
    {
        //// Detectar si se presiona la tecla E
        //if (canCollect && Input.GetKeyDown(KeyCode.E))
        //{
        //    CollectorItem();
        //}
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    // Verificar si el jugador entra en el área del ítem
    //    if (other.CompareTag("Player")) // Asegúrate de que el jugador tenga la etiqueta "Player"
    //    {
    //        canCollect = true;
    //    }
    //}

    //void OnTriggerExit(Collider other)
    //{
    //    // Verificar si el jugador sale del área del ítem
    //    if (other.CompareTag("Player"))
    //    {
    //        canCollect = false;
    //    }
    //}

    //public void CollectorItem()
    //{
    //    item.enabled = false;
    //    iconEmpty.sprite = itemIcon.sprite;
    //    transform.SetParent(equipSlot, false);
    //    transform.localPosition = Vector3.zero;
    //    transform.localRotation = Quaternion.identity;
    //}
    //public void DropItem()
    //{
    //    item.enabled = true; // Vuelve a habilitar el collider
    //    transform.SetParent(null); // Desvincula el ítem del equipSlot
    //                               // Opcional: Posicionar el ítem en el mundo
    //    transform.position = transform.position + new Vector3(0, 0.5f, 0); // Ajustar la altura al soltar
    //}
    //void Update()
    //{


    //}

    public void CollectorItem()
    {
        item.enabled = false;
        iconEmpty.sprite = itemIcon.sprite;
        transform.SetParent(equipSlot, false);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
}
