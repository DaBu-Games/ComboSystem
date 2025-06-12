using UnityEngine;

public class SceneManager : IObserver
{
    private GameObject endScreen;

    public SceneManager(GameObject endScreen)
    {
        this.endScreen = endScreen;
        this.endScreen.SetActive(false);
    }
    
    public void Update(ISubject subject)
    {
        endScreen.SetActive(true);
    }
}
