using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameStateLoad : MonoBehaviour
{
    public Transform Player;
    public Cookingpreparation manager;
    public ButtonInteraction buttonInteraction;
    public Pot pot;
    [Header("위치 저장할 오브젝트들")]
    public Transform[] transforms;

    List<Transform> objs = new();
    List<Vector3> objs_pos = new();
    List<Quaternion> objs_rot = new();

    Vector3 player_pos;
    Vector3 pot_pos;
    Quaternion player_rot;
    Quaternion pot_rot;

    float pot_water_amount;

    int stage_level = 0;

    public void SaveGame()
    {
        if (Player == null)
        {
            Debug.LogError("플레이어null");
            return;
        }

        player_pos = Player.transform.position;
        player_rot = Player.transform.rotation;
        pot_pos = pot.transform.position;
        pot_rot = pot.transform.rotation;

        objs_pos.Capacity = transforms.Length;
        objs_rot.Capacity = transforms.Length;
        foreach (var t in transforms)
        {
            if (t == null)
                continue;
            objs.Add(t);
            objs_pos.Add(t.position);
            objs_rot.Add(t.rotation);
            int child_cnt = t.childCount;
            for(int i = 0; i < child_cnt; ++i)
            {
                Transform child = t.GetChild(i);
                objs.Add(child);
                objs_pos.Add(child.position);
                objs_rot.Add(child.rotation);
            }

        }

        stage_level = manager.GetLevel();
        pot_water_amount = pot.GetWaterAmount();
    }
    public void LoadGame() 
    {
        if (Player == null)
        {
            Debug.LogError("플레이어null");
            return;
        }

        Player.transform.position = player_pos;
        Player.transform.rotation = player_rot;
        pot.transform.position = pot_pos;
        pot.transform.rotation = pot_rot;

        pot.SetWaterAmount(pot_water_amount);

        for (int i = 0; i < objs.Count; ++i)
        {
            if (objs[i] == null)
                continue;
            var rb = objs[i].GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
            objs[i].position = objs_pos[i];
            objs[i].rotation = objs_rot[i];
        }

        buttonInteraction.SetPress(false);
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(GameStateLoad))]
    public class GameStateLoad1Editor : Editor
    {
        public override void OnInspectorGUI()
        {
            this.DrawDefaultInspector();

            GUILayout.Space(10.0f);
            GUILayout.Label("테스트");
            GUI.enabled = Application.isPlaying;
            if (GUILayout.Button("저장"))
            {
                var target = (GameStateLoad)this.target;
                target.SaveGame();
            }
            if (GUILayout.Button("로드"))
            {
                var target = (GameStateLoad)this.target;
                target.LoadGame();
            }
            GUI.enabled = true;
        }
    }
#endif
}
