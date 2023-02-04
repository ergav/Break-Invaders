using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public List<Invaders> invaders = new List<Invaders>();


    void Update()
    {
        if (invaders.Count == 0)
        {
            Win();
        }

        foreach (Invaders invader in invaders.ToList<Invaders>())
        {
            if (invader == null)
            {
                invaders.Remove(invader);
            }
        }
    }

    public void Win()
    {
        SceneManager.LoadScene(2);
    }
}
