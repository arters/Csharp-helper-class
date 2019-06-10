/**
 * ListViewHelper - ListViewHelper is a helper class that provides methods that
 * help ListView control in Windows Forms. 
 * https://github.com/arters/Csharp-helper-class/blob/master/ListViewHelper.cs
 *
 * @author Jwu
 * @license MIT
 *
 * @version 1.0.0
 */
 
 
// 宣告及建立 ListView 多個標題列
ColumnHeader[] cheader = new ColumnHeader[]
{
    new ColumnHeader{
        Name = "ID",
        Text = "序號",
        Width = -2,
        TextAlign = HorizontalAlignment.Center
    },
    new ColumnHeader{
        Name = "t1",
        Text = "標題1",
        Width = -2,
        TextAlign = HorizontalAlignment.Center
    },
    new ColumnHeader{
        Name = "t2",
        Text = "標題2",
        Width = -2,
        TextAlign = HorizontalAlignment.Center
    },
    new ColumnHeader{
        Name = "t3",
        Text = "標題3",
        Width = -2,
        TextAlign = HorizontalAlignment.Center
    },
};
ListViewHelper.CreateListViewColumn(listView1, cheader);



// 初始化 ListView
// 增加Item的標題(只增加Name屬性，不含其他properties)
string[] HeaderArr = { "標題1", "標題2", "標題3"};
ListViewHelper.InitListViewColumnName(listView1, HeaderArr);

// 新增 ListView 列
string[] dataArr = { "欄位1", "欄位2", "欄位3"};
ListViewHelper.AddListView(listView1, dataArr);

// 新增 ListView 列(可指定位置)預設資料插入到最頂端
string[] dataArr = { "欄位1", "欄位2", "欄位3"};
ListViewHelper.InsertListView(listView1, dataArr);
// 或
ListViewHelper.InsertListView(listView1, dataArr, 0);


// 經由指定標題列找出底下符合的資料後刪除整列
ListViewHelper.DeleteRowByHeaderName(listView1, "11135", "標題3"));


// 指定標題列找出符合的資料位於第幾列
MessageBox.Show( ListViewHelper.FindIndexByHeaderName(listView1, "11135", "標題3").ToString());

// 刪除所選取的列(一或多列)
ListViewHelper.DeleteSelectedRows(listView1);



