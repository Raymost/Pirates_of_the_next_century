using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private TrailRenderer rastroBala;
    [SerializeField] private Transform explosionBalaPrefab;
    private Vector3 posicionObjetivo;

    public void Configuracion(Vector3 posicionObjetivo)
    {
        this.posicionObjetivo = posicionObjetivo;
    }
    private void Update() {
        // Movimiento de la bala
        Vector3 direccionMovimiento = (posicionObjetivo - transform.position).normalized;
        float distanciaAntesMoverse = Vector3.Distance(transform.position, posicionObjetivo);

        float velocidadMovimiento = 200f;
        transform.position += direccionMovimiento * velocidadMovimiento * Time.deltaTime;

        float distanciaDespuesMoverse = Vector3.Distance(transform.position, posicionObjetivo);

        if (distanciaAntesMoverse < distanciaDespuesMoverse)
        {
            // Asi la bala va a la posición deseada
            transform.position = posicionObjetivo;
            // Desvincula el rastro de la bala, de la propia bala
            rastroBala.transform.parent = null;
            // Destruimos la bala
            Destroy(gameObject);

            Instantiate(explosionBalaPrefab, posicionObjetivo, Quaternion.identity);
        }

    }
}
