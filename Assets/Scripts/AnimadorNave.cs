using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimadorNave : MonoBehaviour
{

    // [SerializeField] private Animator animador;
    [SerializeField] private Transform balaPrefab;
    [SerializeField] private Transform puntoDisparoTransform;
    [SerializeField] private Transform puntoDisparo2Transform;
    // [SerializeField] private Transform rifleTransform;
    // [SerializeField] private Transform swordTransform;


    private void Awake()
    {
        // if (TryGetComponent<MoveAction>(out MoveAction moveAction))
        // {
        //     moveAction.OnStartMoving += MoveAction_OnStartMoving;
        //     moveAction.OnStopMoving += MoveAction_OnStopMoving;
        // }

        if (TryGetComponent<AccionDisparar>(out AccionDisparar accionDisparar))
        {
            accionDisparar.AlDisparar += AccionDisparar_AlDisparar;
        }

        // if (TryGetComponent<SwordAction>(out SwordAction swordAction))
        // {
        //     swordAction.OnSwordActionStarted += SwordAction_OnSwordActionStarted;
        //     swordAction.OnSwordActionCompleted += SwordAction_OnSwordActionCompleted;
        // }
    }

    private void Start()
    {
        //EquipRifle();
    }

    // private void SwordAction_OnSwordActionCompleted(object sender, EventArgs e)
    // {
    //     EquipRifle();
    // }

    // private void SwordAction_OnSwordActionStarted(object sender, EventArgs e)
    // {
    //     EquipSword();
    //     animador.SetTrigger("SwordSlash");
    // }

    // private void MoveAction_OnStartMoving(object sender, EventArgs e)
    // {
    //     animador.SetBool("IsWalking", true);
    // }

    // private void MoveAction_OnStopMoving(object sender, EventArgs e)
    // {
    //     animador.SetBool("IsWalking", false);
    // }

    private void AccionDisparar_AlDisparar(object sender, AccionDisparar.AlDispararEventArgs e)
    {
        Transform balaTransform = 
            Instantiate(balaPrefab, puntoDisparoTransform.position, Quaternion.identity);

        Bala bulletProjectile = balaTransform.GetComponent<Bala>();

        Vector3 naveDisparaPosicionObjetivo = e.naveObjetivo.GetPosicionEnMundo();

        naveDisparaPosicionObjetivo.y = puntoDisparoTransform.position.y;

        bulletProjectile.Configuracion(naveDisparaPosicionObjetivo);

        if (puntoDisparo2Transform != null)
        {
            Transform balaTransform2 = 
            Instantiate(balaPrefab, puntoDisparo2Transform.position, Quaternion.identity);

        Bala bulletProjectile2 = balaTransform2.GetComponent<Bala>();

        Vector3 naveDisparaPosicionObjetivo2 = e.naveObjetivo.GetPosicionEnMundo();

        naveDisparaPosicionObjetivo2.y = puntoDisparo2Transform.position.y;

        bulletProjectile2.Configuracion(naveDisparaPosicionObjetivo2);
        }
    }

    // private void EquipSword()
    // {
    //     swordTransform.gameObject.SetActive(true);
    //     rifleTransform.gameObject.SetActive(false);
    // }

    // private void EquipRifle()
    // {
    //     swordTransform.gameObject.SetActive(false);
    //     rifleTransform.gameObject.SetActive(true);
    // }

}
