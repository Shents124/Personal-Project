using UnityEngine;

[CreateAssetMenu(fileName = "DataAnimal" , menuName = "ScriptableObjects/DataAnimal",order = 2)]
public class DataAnimal : ScriptableObject
{
    public FloatReference maxHealth;
    public int pointScore;
    public int dame;
    public int speed;
}
