using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Ship))]
public class ShipInspector : Editor {

    public int selGridInt = 0;
    public string[] selStrings = new string[] { "Ship", "Crew" };
    public int progressBarInt = 0;

    Ship script;
    public int locArmor, locAttack, locAgility, locHitPoints;
    SerializedProperty locCrewMembers, locShipWeapons;

    private void OnEnable()
    {
        script = (Ship)target;
        locArmor = script.armor;
        locAttack = script.attack;
        locAgility = script.agility;
        locHitPoints = script.hitPoints;
        locShipWeapons = serializedObject.FindProperty("shipGuns");
        locCrewMembers = serializedObject.FindProperty("crewMembers");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        //start button group
        //two buttons, one for ship, one for crew
        selGridInt = GUILayout.SelectionGrid(selGridInt, selStrings, 2);
        //end button group
        GUILayout.BeginVertical("box");
        progressBarInt = locArmor + locAgility + locAttack;
        GUIContent content = new GUIContent();

        //switch based on which button
        switch(selGridInt)
        {
            case 0:
                content.text = "Ship Hit Points";
                content.tooltip = "The amount of hit points that this ship has";
                locHitPoints = EditorGUILayout.IntField(content, Mathf.Max(locHitPoints, 1));

                content.text = "Armor";
                content.tooltip = "The amount of armor that this ship will have";
                locArmor = EditorGUILayout.IntSlider(content,locArmor, 10, Mathf.Min(100 - locAttack - locAgility, 80));
                content.text = "Attack";
                content.tooltip = "The amount of attack that this ship will have";
                locAttack = EditorGUILayout.IntSlider(content, locAttack, 10, Mathf.Min(100 - locArmor - locAgility, 80));
                content.text = "Agility";
                content.tooltip = "The amount of agility that this ship will have";
                locAgility = EditorGUILayout.IntSlider(content, locAgility, 10, Mathf.Min(100 - locArmor - locAttack, 80));

                content.text = "Ship Guns";
                content.tooltip = "The weapons that will be on this ship";
                EditorGUILayout.PropertyField(locShipWeapons, content, true);
                break;
            case 1:
                content.text = "Crew Members";
                content.tooltip = "The crew members for this ship";
                EditorGUILayout.PropertyField(locCrewMembers, content, true);
                break;
        }

        serializedObject.ApplyModifiedProperties();
        //base.OnInspectorGUI();
        script.armor = locArmor;
        script.attack = locAttack;
        script.agility = locAgility;
        script.hitPoints = locHitPoints;
    }

    
}
