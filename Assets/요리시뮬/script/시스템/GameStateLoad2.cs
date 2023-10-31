using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameStateLoad2 : MonoBehaviour
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
        buttonInteraction.isButtonPressed = true;
        cookingpreparation.ingredients = false;
        water.water = true;
        pot.water_amount = 1f;
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(GameStateLoad2))]
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
                GameStateLoad2 s = (GameStateLoad2)target;
                s.LoadGame();
            }
            GUI.enabled = true;
        }
    }
#endif
}
