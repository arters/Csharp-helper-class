using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/// <summary>
/// ListBox 控制項輔助類
/// 2019/09/11 Arter
/// </summary>

namespace ArterForm
{
    class ListBoxHelper
    {

        private static int StratQueryPos = 0;
        private static string PastQueryStr = null; //上一次查詢的歷史關鍵字

        /// <summary>
        /// 尋找ListBox中符合的項目 (循環搜尋)
        /// </summary>
        /// <param name="control"></param>
        /// <param name="QueryStr"></param>
        public static void Find(ListBox control, string QueryStr = "")
        {
            string ListText = "";
            int ListBoxNum = control.Items.Count;
            int SelectedIndex = control.SelectedIndex;

            //如果查詢的關鍵字有更動則歸零
            if (!QueryStr.Equals(PastQueryStr))
            {
                PastQueryStr = QueryStr;//把當前查詢的關鍵字放到歷史關鍵字
                StratQueryPos = 0;
            }
            //超出搜尋位置則歸零
            if (StratQueryPos >= ListBoxNum)
            {
                StratQueryPos = 0;
            }
            for (int i = StratQueryPos; i < ListBoxNum; i++)
            {
                //取得lsitbox該列的值 (Getting value of loop item in list box)
                ListText = control.GetItemText(control.Items[StratQueryPos]).ToString();
                //MessageBox.Show(ListText);
                
                //如果該列有包含到關鍵字
                if (ListText.Contains(QueryStr))
                {
                    control.SetSelected(StratQueryPos, true);//把該列選取起來
                    StratQueryPos++;
                    break;
                }
                StratQueryPos++;
            }
        }

        /// <summary>
        /// 選取 ListBox 中符合的項目 (依照 Value)
        /// </summary>
        /// <param name="control"></param>
        /// <param name="KeyStr"></param>
        public static void SetByKey(ListBox control, string KeyStr = "")
        {
            int i = 0;
            string ListText = "";
            foreach (KeyValuePair<string, string> item in control.Items)
            {
                ListText = item.Key;
                if (ListText == KeyStr)
                {
                    control.SetSelected(i, true);//把該列選取起來
                    break;
                }
                i++;
            }
        }
        /// <summary>
        /// 選取 ListBox 中符合的項目 (依照 Value)
        /// </summary>
        /// <param name="control"></param>
        /// <param name="ValueStr"></param>
        public static void SetByValue(ListBox control, string ValueStr = "")
        {
            int i = 0;
            string ListText = "";
            foreach (KeyValuePair<string, string> item in control.Items)
            {
                ListText = item.Value;
                if ( ListText == ValueStr )
                {
                    control.SetSelected(i, true);//把該列選取起來
                    break;
                }
                i++;
            }
        }

        /// <summary>
        /// 讓 ListBox 向上或向下選取
        /// Move item in listbox up and down
        /// </summary>
        /// <param name="control"></param>
        /// <param name="direction"></param>
        public static void ListBoxMoveItem(ListBox control, int direction)
        {
            // Checking selected item
            if (control.SelectedItem == null || control.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = control.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= control.Items.Count)
                return; // Index out of range - nothing to do

            /*
            object selected = control.SelectedItem;
            // Removing removable element
            control.Items.Remove(selected);
            // Insert it in new position
            control.Items.Insert(newIndex, selected);
            // Restore selection
            control.SetSelected(newIndex, true);
            */

            control.SetSelected(newIndex, true);//把該列選取起來
        }
    }

}
