using System.Collections;
using UnityEngine;

public class EndingGame : MonoBehaviour
{
    public Camera cam;
    public GameObject wife;
    public Transform player;
    public float speed;
    private static readonly int AnimationInt = Animator.StringToHash("Animation_int");
    private bool isEnding = false;
    private Vector3 wifePosition;

    private void Start()
    {
        var offset = player.position - cam.transform.position;
        wifePosition = wife.transform.position - offset;
    }

    private void OnEnable()
    {
        EventBroker.onGameVictory += EndGame;
    }

    private void OnDisable()
    {
        EventBroker.onGameVictory -= EndGame;
    }

    private void Update()
    {
        if (isEnding)
        {
            cam.transform.position =
                Vector3.MoveTowards(cam.transform.position, wifePosition, speed * Time.deltaTime);
        }
    }

    private void EndGame()
    {
        StartCoroutine(CutSceneEnding());
    }

    private IEnumerator CutSceneEnding()
    {
        yield return new WaitForSeconds(1f);
        CameraFollowPlayer followPlayer = cam.GetComponent<CameraFollowPlayer>();
        followPlayer.Ending();

        wife.SetActive(true);
        isEnding = true;
        Animator animator = wife.GetComponent<Animator>();
        animator.SetInteger(AnimationInt, 3);

        SoundManager.Instance.StopPlayBattleSound();
        SoundManager.Instance.PlaySound(SoundManager.Instance.ending);
        yield return new WaitForSeconds(2f);
        EventBroker.CallDisplayGameVictory();
    }
}