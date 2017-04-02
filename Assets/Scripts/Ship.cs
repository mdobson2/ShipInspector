using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public enum GunStyle { cannon, plasma, machinegun, flamethrower};

    public int armor, attack, agility;
    public int hitPoints;
    public GunStyle[] shipGuns;
    public CrewMember[] crewMembers;

}
