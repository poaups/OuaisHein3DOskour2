//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Raycast3DExample : MonoBehaviour
//{
//    public LayerMask layerMask;  // Le LayerMask pour cibler certains objets
//    public float rayLength = 1000.0f;  // Longueur du rayon

//    void Update()
//    {
//        // Origine du rayon (position de l'objet)
//        Vector3 origin = transform.position;

//        // Direction du rayon (en avant de l'objet)
//        Vector3 direction = transform.forward;

//        // Utilisation de RaycastAll pour d�tecter toutes les collisions le long du rayon
//        RaycastHit[] hits = Physics.RaycastAll(origin, direction, rayLength, layerMask);

//        // Dessiner le rayon dans la fen�tre de sc�ne (facultatif)
//        Debug.DrawRay(origin, direction * rayLength, Color.red);

//        // Si le rayon touche quelque chose
//        if (hits.Length > 0)
//        {
//            Debug.Log("Le rayon a touch� " + hits.Length + " objet(s)");

//            // Parcourir tous les objets touch�s
//            foreach (RaycastHit hit in hits)
//            {
//                Debug.Log("Rayon touch�: " + hit.collider.name);
//            }
//        }
//        else
//        {
//            Debug.Log("Le rayon n'a touch� aucun objet");
//        }
//    }
//}
