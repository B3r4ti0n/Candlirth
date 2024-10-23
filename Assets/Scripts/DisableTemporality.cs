using System.Collections;
using UnityEngine;

public class DisableTemporality : MonoBehaviour
{
    // Le GameObject à désactiver temporairement
    public GameObject targetObject;
    // Durée pendant laquelle le GameObject sera désactivé (en secondes)
    public float disableDuration = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // Démarre la coroutine pour désactiver le GameObject
        StartCoroutine(DisableObjectTemporarily());
    }

    // Coroutine pour désactiver le GameObject pendant un certain temps
    private IEnumerator DisableObjectTemporarily()
    {
        // Désactive le GameObject
        targetObject.SetActive(false);

        // Attend pendant la durée spécifiée
        yield return new WaitForSeconds(disableDuration);

        // Réactive le GameObject
        targetObject.SetActive(true);
    }
}
