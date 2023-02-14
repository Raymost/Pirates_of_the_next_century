using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatonMundo : MonoBehaviour
{
    private static RatonMundo instancia;
    [SerializeField] private LayerMask ratonSueloCapaMascara; // Etiqueta del suelo

    private void Awake() {
       instancia = this;
    }

    void Update()
    {
        transform.position = RatonMundo.GetPosicionRaton();
    }
    
    // Hace un raycast desde la camara a la posicion del raton que solo este en el suelo
    // para obtener la posicion
    public static Vector3 GetPosicionRaton()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instancia.ratonSueloCapaMascara);
        return raycastHit.point;
    }
}
