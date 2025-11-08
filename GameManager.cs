using UnityEngine;
using System.Collections.Generic;

// Very small manager to demonstrate "scare" triggers and objective tracking.
// Attach to an empty GameObject in the scene and set up ScareTrigger components.

public class GameManager : MonoBehaviour
{
    public int booksNeeded = 3;
    private int booksCollected = 0;
    public Light globalAmbientLight;
    public AudioSource ambientSource;
    public AudioClip subtleJumpClip;

    // Simple list of triggered scare IDs to avoid repetition
    private HashSet<string> triggeredScares = new HashSet<string>();

    void Start()
    {
        // initial ambience
        if (ambientSource != null) ambientSource.Play();
    }

    public void CollectBook()
    {
        booksCollected++;
        Debug.Log($"Books collected: {booksCollected}/{booksNeeded}");
        if (booksCollected >= booksNeeded) OnAllBooksCollected();
    }

    void OnAllBooksCollected()
    {
        Debug.Log("All books collected! Return to the desk to finish.");
        // e.g., open exit door — implement via events
    }

    // Called by trigger volumes or other events to play a mild scare.
    public void TriggerScare(string scareId, Transform scareLocation)
    {
        if (triggeredScares.Contains(scareId)) return;
        triggeredScares.Add(scareId);
        StartCoroutine(PlayScareRoutine(scareLocation));
    }

    System.Collections.IEnumerator PlayScareRoutine(Transform loc)
    {
        // mild flash of light + sound
        if (globalAmbientLight != null)
        {
            float orig = globalAmbientLight.intensity;
            float t = 0f;
            while (t < 0.15f) // quick flash
            {
                globalAmbientLight.intensity = Mathf.Lerp(orig, orig + 0.8f, t / 0.15f);
                t += Time.deltaTime;
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);
            globalAmbientLight.intensity = orig;
        }
        if (subtleJumpClip != null)
        {
            AudioSource.PlayClipAtPoint(subtleJumpClip, loc.position, 0.9f);
        }
        // Optional: spawn a silhouette prefab that fades quickly (non-threatening)
    }
}
