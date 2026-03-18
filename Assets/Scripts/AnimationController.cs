using Unity.VisualScripting;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool isopen = false;
    public void Clickbtn()
    {
        isopen = !isopen;
        animator.SetBool("isopen", isopen);
    }
}
