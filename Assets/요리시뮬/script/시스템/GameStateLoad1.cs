using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameStateLoad1 : MonoBehaviour
{
    
    public Transform playerpostion;
    public Cookingpreparation cookingpreparation;
    public Water water;
    public ButtonInteraction buttonInteraction;
    public Pot pot;

    public void LoadGame() 
    {
        playerpostion.transform.position = new Vector3(-5.8f, 0f, -0.5f);
        playerpostion.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        buttonInteraction.isButtonPressed = false;
        cookingpreparation.ingredients = false;
        water.water = false;
        pot.water_amount = 0f;
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(GameStateLoad1))]
    public class GameStateLoad1Editor : Editor
    {
        public override void OnInspectorGUI()
        {
            this.DrawDefaultInspector();

            GUILayout.Space(10.0f);
            GUILayout.Label("Å×½ºÆ®");
            GUI.enabled = Application.isPlaying;
            if (GUILayout.Button("On"))
            {
                GameStateLoad1 s = (GameStateLoad1)target;
                s.LoadGame();
            }
            GUI.enabled = true;
        }
    }
#endif
}
