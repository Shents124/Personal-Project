using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject wife;
    private Vector3 offset;

    private bool isEnding = false;
    private void Awake()
    {
        offset = player.transform.position - transform.position;
    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        if(isEnding == false)
            transform.position = player.transform.position - offset;
    }

    public void Ending()
    {
        isEnding = true;
    }
}
