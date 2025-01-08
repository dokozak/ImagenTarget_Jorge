using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagesScript : MonoBehaviour
{
    //Comprobe if the player has used a card
    public static bool isRecognize;

    //Comprobe if the random pokemon is equals than this pokemon
    public void isThisPokemon(string namePokemon)
    {
        //Indicate if any pokemon has been recognize
        if (isRecognize)
            return;

        //If you pokemon is the same who is selected, you get a point if not you lose point
        if (namePokemon.Equals(AdministratorGUI.pokemonNow))
            AdministratorGUI.point++;
        
        else
            AdministratorGUI.point--;
        //Change the button state
        AdministratorGUI.isEnable = true;
        //Indicate if any pokemon has been recognize
        isRecognize = true;

    }

}
