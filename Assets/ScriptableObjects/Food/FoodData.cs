using UnityEngine;

[CreateAssetMenu(fileName = "Food Data",menuName = "ScriptableObjects/Food Data",order = 3)]
public class FoodData : ScriptableObject
{
    public GameObject hitEffect;
    public FloatReference speed;
    public string targetTag;
    public FloatReference boundaryDestroy;
}
