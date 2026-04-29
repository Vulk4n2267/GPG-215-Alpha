using UnityEngine;

public class MusicSelection : MonoBehaviour
{
    
    public GameObject[] targetObjects;




    public void ActivateObjects()
    {
        foreach (GameObject obj in targetObjects)
        {
            if (obj != null)
                obj.SetActive(true);
            


        }
    }

    
    public void DeactivateObjects()
    {
        foreach (GameObject obj in targetObjects)
        {
            if (obj != null)
                obj.SetActive(false);
            
        }
    }

   
    public void ToggleObjects()
    {
        foreach (GameObject obj in targetObjects)
        {
            if (obj != null)
                obj.SetActive(!obj.activeSelf);
        }
    }

   

}

