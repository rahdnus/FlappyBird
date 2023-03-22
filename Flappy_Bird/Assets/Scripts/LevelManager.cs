using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Transform spawn;
    [SerializeField] Transform destroy;
    [SerializeField] GameObject pipePrefab;
    [SerializeField] float pipeSpeed = 10f;

    [SerializeField] float minOffset, maxOffset;
    [SerializeField] float spawnRate=3f;
    private List<GameObject> pipes = new List<GameObject>();
    float timer=0f;
    void Start()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer>spawnRate)
        {
            timer=0f;
            float offset = Random.Range(minOffset, maxOffset);
            var pipe=Instantiate(pipePrefab,spawn.position+Vector3.up*offset,Quaternion.identity);
            pipe.GetComponent<Pipe>().Init((g) =>
            {
                pipes.Remove(g);
            }, pipeSpeed,destroy.position);
            pipes.Add(pipe);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
