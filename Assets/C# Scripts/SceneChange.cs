using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update

   
   
    void Start()
    {

        Invoke("LoadMainLevel", 8);

    }

    // Update is called once per frame
   

    private void LoadMainLevel()
    {

        
        SceneManager.LoadScene(1);
        
    }
}
