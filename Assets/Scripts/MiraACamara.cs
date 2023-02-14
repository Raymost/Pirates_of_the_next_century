using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiraACamara : MonoBehaviour
{
    [SerializeField] private bool invertir;
   private Transform camaraTransform;

   private void Awake() {
    camaraTransform = Camera.main.transform;
   }

   private void LateUpdate() {
    if (invertir)
    {
        Vector3 direccionACamara = (camaraTransform.position + transform.position).normalized;
        transform.LookAt(camaraTransform.position + direccionACamara * -1);
    }
    else 
    {
        transform.LookAt(camaraTransform);
    }
   }
}
