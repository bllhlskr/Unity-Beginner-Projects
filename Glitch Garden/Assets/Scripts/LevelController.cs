using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelController : MonoBehaviour
{
    [SerializeField] float waitToLoad = 3f;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject LooseLabel;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    private void Start()
    {
        winLabel.SetActive(false);
        LooseLabel.SetActive(false);
    }
    public void AttackerSpawned()
    {
        numberOfAttackers++;
        Debug.Log(numberOfAttackers);
    }
    public void AttackerKilled()
    {
        numberOfAttackers--;
        
        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
            Debug.Log(numberOfAttackers);
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
       public void HandleLooseCondition()
    {
        LooseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    
}
