using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverTextEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI textMeshPro;
    public Color normalColor = Color.black;
    public Color hoverColor = Color.yellow;
   


    


    public void OnPointerEnter(PointerEventData eventData)
    {
        textMeshPro.color = hoverColor; // Change color on hover
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textMeshPro.color = normalColor; // Reset color when not hovering
    }
}
