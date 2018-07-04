using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FYProject
{
    public class UIButton : Button
    {
        [SerializeField]
        private UnityEvent m_OnHover = null;

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            m_OnHover.Invoke();
        }

    }
}
