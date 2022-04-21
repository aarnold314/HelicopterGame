using UnityEngine;
using UnityEngine.SceneManagement;

public class TempShopNav : MonoBehaviour
{
    public void NextScene ()
    {
        SceneManager.LoadScene("Objective2");
    }
}
