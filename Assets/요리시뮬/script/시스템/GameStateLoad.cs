using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameStateLoad : MonoBehaviour
{
    
    public Transform playerpostion;
    public Cookingpreparation cookingpreparation;
    public ButtonInteraction buttonInteraction;
    public Pot pot;

    public void LoadGame() 
    {
        playerpostion.transform.position = new Vector3(-5.8f, 0f, -0.5f);
        playerpostion.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        buttonInteraction.isButtonPressed = false;
        cookingpreparation.ingredients = false;
        pot.SetWaterAmount(0.0f);
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(GameStateLoad))]
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
                var target = (GameStateLoad)this.target;
                target.LoadGame();
            }
            GUI.enabled = true;
        }
    }
#endif
}
