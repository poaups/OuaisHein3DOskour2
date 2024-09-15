using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Alors, oui c'est moche mais y'a une raison, en gros quand j'appuyais sur clique gauche et rentrant en collision avec un bouton avec le raycats ca marchait pas alors j'ai créer la fonction ClikGauche qui simule un clique gauche avec la variable oskour.
//oskour2 permet a ne pas spam un bouton, quand je reste appuye sur clique gauche l'anim se fait pleins de fois alors elle se joue que quand oskour2 est true et ce dernier est true quand on relache le clique donc il est actif que 1 fois donc 1 anim
public class Raycast : MonoBehaviour
{
    private bool oskour = false;
    private bool oskour2 = true;
    void Update()
    {
        ClikGauche();
        print(oskour + "oskour");
        // Le Update reste vide si tu veux tout gérer dans OnTriggerStay
    }

    private void OnTriggerStay(Collider other)
    {
        // Vérifier si l'objet en collision est l'objet B
        if (other.CompareTag("ButtonDigiPad"))
        {
            
            if(oskour && oskour2)
            {
                var _script = other.GetComponent<ButtonDigiPad>();
                _script.MouseClickPressed = true;
                if (_script.Reset == true )
                    _script.RestCode();

                if(_script.Validation == true )
                    _script.ValidationCode();
                
                oskour2 = false;
            }
            

        }
      
    }

    void ClikGauche()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            oskour = true;
            
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            oskour = false;
            oskour2 = true;
        }
    }
}
