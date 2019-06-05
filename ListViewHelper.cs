// 2019/06/05

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Arters
{
    class ListViewHelper
    {

        public static List<ListViewHeader> ListViewHeaders = new List<ListViewHeader>();
        public class ListViewHeader
        {
            public string Name { get; set; }
            public string Text { get; set; }
            public int Width { get; set; }
            public HorizontalAlignment TextAlign { get; set; }
            public string Tag { get; set; }
        }

        /// <summary>
        /// //設置成 Details 模式
        /// </summary>
        public static void SetListViewDetails(ListView listViewControl)
        {
            listViewControl.View = View.Details;//ListView顯示方式
            listViewControl.FullRowSelect = true;
            listViewControl.GridLines = true;

        }

        /// <summary>
        /// 初始化 ListView
        /// 增加Item的標題
        /// </summary>
        /// <remarks>
        /// 範例：
        /// string[] HeaderArr = { "標題1", "標題2", "標題3"};
        /// ListViewHelper.InitListView(listView1, HeaderArr);
        /// </remarks>
        public static void InitListViewColumnName(ListView listViewControl, string[] ColumnsArr)
        {
            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            int index = 0;
            foreach (string ColumnName in ColumnsArr)
            {
                listViewControl.Columns.Add(ColumnName);
                listViewControl.Columns[index].Name = ColumnName;
                ++index;
            }
            //listViewControl.Columns[0].Name = "Column 1";
            //listViewControl.Columns[1].Name = "Column 2";

        }
        /// <summary>
        /// 初始化 ListView
        /// </summary>
        public static void InitListViewColumn(ListView listViewControl, ListViewHeader header)
        {
            ColumnHeader cheader = new ColumnHeader();
            cheader.Name = header.Name;
            cheader.Text = header.Text;
            cheader.Width = header.Width;
            cheader.TextAlign = header.TextAlign;
            cheader.Tag = header.Tag;
            listViewControl.Columns.Add(cheader);
        }

        /// <summary>
        /// 增加 ListView 列
        /// </summary>
        /// <remarks>
        /// 範例：
        /// string[] dataArr = { "欄位1", "欄位2", "欄位3"};
        /// ListViewHelper.AddListView(listView1, dataArr);
        /// </remarks>
        public static void AddListView(ListView listViewControl, string[] DataArr)
        {
            ListViewItem lvi = new ListViewItem(DataArr);
            listViewControl.Items.Add(lvi);
        }

        /// <summary>
        /// 增加 ListView 列(指定位置)預設插入到最頂端
        /// </summary>
        /// <remarks>
        /// 範例：
        /// string[] dataArr = { "欄位1", "欄位2", "欄位3"};
        /// ListViewHelper.InsertListView(listView1, dataArr);
        /// </remarks>
        public static void InsertListView(ListView listViewControl,string[] DataArr, int index = 0)
        {
            ListViewItem lvi = new ListViewItem(DataArr);
            listViewControl.Items.Insert(index ,lvi);
        }

        /// <summary>
        /// 指定標題列找出符合的資料後刪除整列
        /// </summary>
        /// <remarks>
        /// 範例：DeleteRowByHeaderName(listView1, "11135", "標題3"));
        /// </remarks>
        /// 
        public static bool DeleteRowByHeaderName(ListView listViewControl, string find, string headerName)
        {
            int index =  FindIndexByHeaderName(listViewControl, find, headerName);
            if(index > 0)
            {
                listViewControl.Items.RemoveAt(index);
                return true;
            }
            return false;
        }
        /// <summary>
        /// 指定標題列找出符合的資料位於第幾列
        /// </summary>
        /// <param name="find">要匹配吻合的文字</param>
        /// <param name="headerName">標題列</param>
        /// <returns>Row index。-1 表示找不到</returns>
        /// <remarks>
        /// 範例：MessageBox.Show( FindIndexByHeaderName(listView1, "11135", "標題3").ToString());
        /// </remarks>
        public static int FindIndexByHeaderName(ListView listViewControl, string find, string headerName)
        {
            int index = -1;
            foreach (ColumnHeader header in listViewControl.Columns)
            {
                if (header.Name == headerName)
                {
                    index = header.Index;
                    break;
                }
            }
            if (index > -1)
            {
                foreach (ListViewItem lvi in listViewControl.Items)
                    if (lvi.SubItems[index].Text == find)
                        return lvi.Index;
            }
            return -1;

        }

    }
}
