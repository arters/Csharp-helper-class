using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/// <summary>
/// ListBox 控制項輔助類
/// 2019/09/03 Arter
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
        /// <param name="listbox"></param>
        /// <param name="QueryStr"></param>
        public static void Find(ListBox listbox, string QueryStr = "")
        {
            string ListText = "";
            int ListBoxNum = listbox.Items.Count;
            int SelectedIndex = listbox.SelectedIndex;

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
                ListText = listbox.GetItemText(listbox.Items[StratQueryPos]).ToString();
                //MessageBox.Show(ListText);
                
                //如果該列有包含到關鍵字
                if (ListText.Contains(QueryStr))
                {
                    listbox.SetSelected(StratQueryPos, true);//把該列選取起來
                    StratQueryPos++;
                    break;
                }
                StratQueryPos++;
            }
        }

        /// <summary>
        /// 選取 ListBox 中符合的項目 (依照 Value)
        /// </summary>
        /// <param name="listbox"></param>
        /// <param name="KeyStr"></param>
        public static void SetByKey(ListBox listbox, string KeyStr = "")
        {
            int i = 0;
            string ListText = "";
            foreach (KeyValuePair<string, string> item in listbox.Items)
            {
                ListText = item.Key;
                if (ListText == KeyStr)
                {
                    listbox.SetSelected(i, true);//把該列選取起來
                    break;
                }
                i++;
            }
        }
        /// <summary>
        /// 選取 ListBox 中符合的項目 (依照 Value)
        /// </summary>
        /// <param name="listbox"></param>
        /// <param name="ValueStr"></param>
        public static void SetByValue(ListBox listbox, string ValueStr = "")
        {
            int i = 0;
            string ListText = "";
            foreach (KeyValuePair<string, string> item in listbox.Items)
            {
                ListText = item.Value;
                if ( ListText == ValueStr )
                {
                    listbox.SetSelected(i, true);//把該列選取起來
                    break;
                }
                i++;
            }
        }
    }

}
