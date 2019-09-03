/**
 * ListBoxHelper - ListBoxHelper is a helper class that provides methods that
 * help ListBox control in Windows Forms. 
 * https://github.com/arters/Csharp-helper-class/blob/master/ListBoxHelper.cs
 *
 * @author Jwu
 * @license MIT
 *
 * @version 1.0.0
 */
 
 
// 循序找出 ListBox 中符合關鍵字的項目
// 範例：
ListBoxHelper.Find(listBox1, "關鍵字");
ListBoxHelper.Find(listBox1, QueryTextBox.Text);


// 迴圈取出所有 ListBox 的 Key/Value 值
// 使用 foreach 遍歷 listbox 的所有項
 foreach (KeyValuePair<string, string> item in listBox1.Items)
 {
     Console.WriteLine("Key = {0}, Value = {1}", item.Key, item.Value);
 }

// 創建一組 ListBox 資料
// 範例：
Dictionary<string, string> list = new Dictionary<string, string>();
//list.Add("Key", "Value");
list.Add("Arter_jaa", "1"); 
list.Add("Arter_jbb,b", "2");
list.Add("Arter_jcc", "3");

this.listBox1.SelectedItem = null;
this.listBox1.DataSource = new BindingSource(list, null);
this.listBox1.DisplayMember = "Key";
this.listBox1.ValueMember = "Value";

this.listBox1.SelectedIndex = 0;

// 選取 ListBox 中符合的項目 (依照 Value)
// 範例：
ListBoxHelper.SetByValue(listBox1, "3"); //如此則會直接選取到 "Arter_jcc"




