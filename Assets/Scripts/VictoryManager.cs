using Unity.VisualScripting;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject buttonrepeat;
    [SerializeField] private GameObject buttonexit;
    // Update is called once per frame
    void Update()
    {
        if (WinManager.win)
        {
            animator.SetBool("isopen", true);
            buttonexit.SetActive(false);
            buttonrepeat.SetActive(false);
        }
    }
}
