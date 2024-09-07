using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Items;
using TMPro;

namespace UI.Game.Items
{
    /// <summary>
    /// �������� ��������� � ���������
    /// </summary>
    public class DescriptionPanelItemInInventory : MonoBehaviour
    {
        [Tooltip("���� ��� ���������� ��������")]
        [SerializeField] private TMP_Text _descriptionText;

        [Tooltip("������ �������� ������� ��������")]
        [SerializeField] private  Vector2 _offsetVector = new Vector2(50f, 50f);

        private Item _current;
        private RectTransform _rectTransform;


        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        /// <summary>
        /// �������������
        /// </summary>
        public void Init(Item item)
        {
            _current = item;
            _descriptionText.text = _current.GetDescription();
            gameObject.SetActive(true);

            Vector2 mousePosition = Input.mousePosition;
            _rectTransform.position = new Vector2(mousePosition.x + _offsetVector.x, mousePosition.y + _offsetVector.y);
        }

        /// <summary>
        /// ���������������
        /// </summary>
        public void ReInit()
        {
            _current = null;
            _descriptionText.text = string.Empty;
            gameObject.SetActive(false);
        }
    }
}
