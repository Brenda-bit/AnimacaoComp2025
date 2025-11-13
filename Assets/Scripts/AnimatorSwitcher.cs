using UnityEngine;
using System.Collections;

public class AnimatorSwitcher : MonoBehaviour
{
    public Animator animator;
    private bool isTransitioning = false;

    private void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        animator.Play("Idle 0");
    }

    private void Update()
    {
        if (isTransitioning) return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.Play("Idle 0");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(PlayThroughIdle("Rumba"));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(PlayThroughIdle("Shakira"));
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
             Application.Quit();
        }
    }

    private IEnumerator PlayThroughIdle(string trigger)
    {
        isTransitioning = true;

        animator.CrossFade("Idle 0", 0.15f);
        yield return new WaitForSeconds(0.3f);

        animator.SetTrigger(trigger);

        isTransitioning = false;
    }
}
