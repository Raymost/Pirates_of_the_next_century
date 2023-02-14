using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{

    private void Update()
    {
        Vector3 moverDireccion = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            moverDireccion.z = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moverDireccion.z = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moverDireccion.x = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moverDireccion.x = +1f;
        }

        float velocidadMovimiento = 10f;

        Vector3 vectorMovimiento = transform.forward * moverDireccion.z + transform.right * moverDireccion.x;
        transform.position += vectorMovimiento * velocidadMovimiento * Time.deltaTime;




        Vector3 vectorRotacion = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.Q))
        {
            vectorRotacion.y = +1f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            vectorRotacion.y = -1f;
        }

        float velocidadRotacion = 100f;
        transform.eulerAngles += vectorRotacion * velocidadRotacion * Time.deltaTime;

    }
}
