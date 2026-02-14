using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "New Power", menuName = "Powers")]
public class PowerUp : ScriptableObject
{
    public string powerName;
    public string description;

    public Object model;
    public int speedModifier;
    public int massModifier;
    public int timeActivated;

}
