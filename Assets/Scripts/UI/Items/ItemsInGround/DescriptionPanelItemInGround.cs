using UnityEngine;
using TMPro;
using Game.Items;


namespace UI.Game.Items
{

    /// <summary>
    /// ������ � ��������� ��������
    /// </summary>
    public class DescriptionPanelItemInGround : MonoBehaviour
    {
        [Tooltip("���� �������� ��������")]
        [SerializeField] private TMP_Text _descriptionText;

        private Item _current;

        /// <summary>
        /// �������������
        /// </summary>
        public void Init(Item item)
        {
            _current = item;
            _descriptionText.text = _current.GetDescription();
            gameObject.SetActive(true);
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
