using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MenuIndicator : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler
{
    [SerializeField] GameObject diamond;
    [SerializeField] TMP_Text label;
    [SerializeField] Color normalColor = new Color(0.75f, 0.8f, 0.95f);
    [SerializeField] Color selectedColor = Color.white;
    [SerializeField] float selectedScale = 1.2f;
    [SerializeField] float speed = 12f;

    bool selected;

    void OnEnable()
    {
        selected = EventSystem.current != null &&
                   EventSystem.current.currentSelectedGameObject == gameObject;
        Apply(true);
    }

    public void OnSelect(BaseEventData e) { selected = true; diamond.SetActive(true); label.color = selectedColor; }
    public void OnDeselect(BaseEventData e) { selected = false; diamond.SetActive(false); label.color = normalColor; }
    public void OnPointerEnter(PointerEventData e) =>
        EventSystem.current.SetSelectedGameObject(gameObject);

    void Update() => Apply(false);

    void Apply(bool instant)
    {
        float target = selected ? selectedScale : 1f;
        Vector3 s = Vector3.one * target;
        label.rectTransform.localScale = instant
            ? s
            : Vector3.Lerp(label.rectTransform.localScale, s, Time.unscaledDeltaTime * speed);

        diamond.SetActive(selected);
        label.color = selected ? selectedColor : normalColor;
    }
}