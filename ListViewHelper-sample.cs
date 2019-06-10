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
        Name = "HashCode",
        Text = "HashCode",
        Width = 1,
        TextAlign = HorizontalAlignment.Center
    },
    new ColumnHeader{
        Name = "Zone",
        Text = "Zone",
        Width = 1,
        TextAlign = HorizontalAlignment.Center
    },
    new ColumnHeader{
        Name = "Area",
        Text = "Area",
        Width = 1,
        TextAlign = HorizontalAlignment.Center
    },
    new ColumnHeader{
        Name = "Size",
        Text = "Size",
        Width = 50,
        TextAlign = HorizontalAlignment.Left
    },
    new ColumnHeader{
        Name = "Status",
        Text = "進度",
        Width = 50,
        TextAlign = HorizontalAlignment.Center
    }
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


