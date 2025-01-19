using UnityEngine;

public class TAnimation1 : MonoBehaviour
{
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void textT1()
    {
        animator.SetTrigger("VTrigger");
    }

}
