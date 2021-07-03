using UnityEngine;
using UnityEngine.UI;

public class SpeedUpUI : MonoBehaviour
{
    public bool isSelected = false;
    private readonly Color colorSelected = Color.red;
    private readonly Color colorDeselected = Color.white;
    private Image buttonImage;
    
    // Start is called before the first frame update
    private void Start()
    {
        buttonImage = GetComponent<Image>();
    }

    public void ClickButton()
    {
        if (isSelected == false)
        {
            Selected();
        }
        else
        {
            Deselected();
        }
    }
    private void Selected()
    {
        isSelected = true;
        buttonImage.color = colorSelected;
    }

    private void Deselected()
    {
        isSelected = false;
        buttonImage.color = colorDeselected;
    }
}
