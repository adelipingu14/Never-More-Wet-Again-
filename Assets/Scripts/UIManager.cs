using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject introducePanel;
    [SerializeField] private GameObject howToPlayPanel;


    public void ChangePanel()
    {
        if (introducePanel.activeSelf)
        {
            introducePanel.SetActive(false);
            howToPlayPanel.SetActive(true);
        }
        else
        { 
            introducePanel.SetActive(true);
            howToPlayPanel.SetActive(false);
        }
    }
}
