
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AdministratorGUI : MonoBehaviour
{
    //TextInformation the player has
    public TextMeshProUGUI textTime;
    //TextInformation the player has
    public TextMeshProUGUI textPokemon;
    //Time max the player has
    private const float RESETTIME = 16;
    //Time that the player has
    private float time = RESETTIME;
    //Limit time you have
    private const int LIMITTIME = 0;
    //Point that the player has
    public static int point = 0;
    //Pokemones who have in this game
    private string[] pokemones = { "Charizard", "Squirtle", "Pikachu", "Bulbasaur", "Mewtwo", "Greninja", "Dragonite" };
    //Pokemon who is selected
    public static string pokemonNow = "";
    //Button who start the next pokemon
    public Button button;
    //Mode of button
    public static bool isEnable;
    //Button imagen
    public Image image;
    //conversion of time
    private int realTime;
    private void Start()
    {
        //Get imagen button
        image = button.GetComponent<Image>();
        //Change the first imagen
        changeImagen();
    }
    private void Update()
    {
       
       
        //Change information for the player
        textTime.SetText("Time: " + realTime.ToString() + "S\nPoint: " + point.ToString() + "");
        textPokemon.SetText("Pokemon Name: \n" + pokemonNow);
        //Change the button state 
        button.enabled = isEnable;

        //End this update
        if (ImagesScript.isRecognize)
        {
            image.color = Color.green;
            return;
        }
        //Real time
        realTime = ((time -= Time.deltaTime) < 0) ? 0 : (int)time;

        //Comprobe if the time has end
        if (realTime <= LIMITTIME)
        {
            if (!isEnable) { point--; }
            
            time = 0;
            isEnable = true;
            ImagesScript.isRecognize = true;
            image.color = Color.green;
        }
       

    }

    //Change the variable pokemonNow to other random pokemon
    public void newRandomPokemon()
    {
        //Dont repeat the pokemon
        string pokemon = pokemonNow;
        while (pokemon.Equals(pokemonNow))
        //Get a new pokemon random
        pokemonNow = pokemones[Random.Range(0, pokemones.Length)];
    }

    //Continue the game
    public void changeImagen()
    {
        //Change the pokemon name and reset the time
        newRandomPokemon();
        time = RESETTIME;
        //Change the button state 
        isEnable = false;
        ImagesScript.isRecognize = false;
        image.color = Color.red;
    }

}
