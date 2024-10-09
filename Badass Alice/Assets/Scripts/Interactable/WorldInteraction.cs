using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldInteraction : Interactable
{
    [SerializeField]
    private string worldToLoad = "";
    [SerializeField]
    private ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void OnInteract()
    {
        SceneManager.LoadScene(worldToLoad);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                if (particleSystem)
                {
                    particleSystem.Play();
                }
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                if (particleSystem)
                {
                    particleSystem.Stop();
                }
                break;
        }
    }
}
