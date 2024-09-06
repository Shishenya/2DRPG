using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Game.Inventory;
using Game.Items;

namespace UI.Game.Items
{
    /// <summary>
    /// ������ � ���������
    /// </summary>
    public class PlayerInventoryCellUI : MonoBehaviour
    {
        [Tooltip("������ ��������")]
        [SerializeField] private Image _image;

        [Tooltip("")]
        [SerializeField] private TMP_Text _countTMP;

        private InventoryCell _inventoryCell;

        /// <summary>
        /// ������������� � ����������
        /// </summary>
        public void Init(InventoryCell inventoryCell)
        {
            _inventoryCell = inventoryCell;
            _image.sprite = GameItemsStorage.Instance.GetItemSOByID(inventoryCell.IdItem).Sprite;
            _countTMP.text = inventoryCell.CountItems.ToString();
        }

        /// <summary>
        /// �������
        /// </summary>
        public void Clear()
        {
            _inventoryCell = null;
            _image.sprite = null;
            _countTMP.text = string.Empty;
        }
    }
}
