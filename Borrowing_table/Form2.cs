using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using MetroFramework.Forms;


namespace Borrowing_table
{
    public partial class Form2 : MetroForm
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        private Form1 form1;

        public Form2(Form1 form1)
        {
            InitializeComponent();

            this.form1 = form1;

            //xml 文档
            this.xdoc = new XmlDocument();
            //this.xdoc.Load("Persons.xml");
            //xml文件路径创建
            if (Directory.Exists(CurXmlPath))
            {
            }
            else
            {
                var directoryInfo = new DirectoryInfo(CurXmlPath);
                directoryInfo.Create();
            }

            //默认xml文件
            if (CurXmlName == "")
            {
                CurXmlName = "model.xml";
            }
        }

        #region datagrilview 拖拽

        private string str1 = ""; //全局变量，存放拖动单元格value      
        int nRow; //记录被拖动单元格行标
        int nColumn; //记录被拖动单元格列标

        private void metroGrid1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            nRow = e.RowIndex;
            nColumn = e.ColumnIndex;
            if (this.metroGrid1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                str1 = this.metroGrid1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
        }

        private void metroGrid1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Clicks >= 2) || (e.Button != MouseButtons.Left)) return;
            if ((e.ColumnIndex >= 0) && (e.RowIndex > -1) && str1 != "")
            {
                metroGrid1.DoDragDrop(metroGrid1.Rows[e.RowIndex], DragDropEffects.Move);
            }
        }

        /// <summary>
        /// GetRowFromPoint方法，目的是获取拖动目标cell单元格行、列坐标
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private Point GetRowFromPoint(int x, int y)
        {
            var nX = -1;
            var nY = -1;
            for (var i = 0; i < metroGrid1.RowCount; i++)
            {
                var rec = metroGrid1.GetRowDisplayRectangle(i, false);
                if (metroGrid1.RectangleToScreen(rec).Contains(x, y))
                    nX = i;
            }
            for (var nI = 0; nI < metroGrid1.Columns.Count; nI++)
            {
                var rec = metroGrid1.GetColumnDisplayRectangle(nI, false);
                if (metroGrid1.RectangleToScreen(rec).Contains(x, y))
                    nY = nI;
            }
            return new Point(nX, nY);
        }

        private int _selectionIdx = 0;

        /// <summary>
        ///在鼠标指针移到 DataGridView 控件上时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroGrid1_DragDrop(object sender, DragEventArgs e)
        {
            var point = GetRowFromPoint(e.X, e.Y);
            if ((point.X < 0) || (point.Y < 0)) return;
            this.metroGrid1.Rows[nRow].Cells[nColumn].Value = this.metroGrid1.Rows[point.X].Cells[point.Y].Value;
            this.metroGrid1.Rows[point.X].Cells[point.Y].Value = str1;
        }

        private void metroGrid1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void metroGrid1_DragEnter(object sender, DragEventArgs e)
        {
            //控制移动时鼠标的图形，否则是一个禁止移动的标识
            e.Effect = DragDropEffects.Move;
        }

        private void metroGrid1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //控制被移动的行始终是选中行
            if (_selectionIdx <= -1) return;
            metroGrid1.Rows[_selectionIdx].Selected = true;
            metroGrid1.CurrentCell = metroGrid1.Rows[_selectionIdx].Cells[0];
        }

        #endregion

        #region xml读取和写入

        private XmlDocument xdoc;

        private const string CurXmlPath = "data/";
        public string CurXmlName = "";

        /// <summary>
        /// 保存xml
        /// </summary>
        public void SaveXml()
        {
            if (xdoc.DocumentElement != null)
            {
                //会把以前的数据全部覆盖掉
                xdoc = new XmlDocument();
            }
            //xdoc.LoadXml("<Lists></Lists>");
            //创建注释
            //xdoc.AppendChild(xdoc.CreateXmlDeclaration("1.0", "utf-8", null));
            //根节点
            var eleLists = xdoc.CreateElement("Lists");
            xdoc.AppendChild(eleLists);
            //循环遍历Gridlist
            for (var index = 0; index < this.metroGrid1.Rows.Count; index++)
            {
                //代表每一行
                var row = this.metroGrid1.Rows[index];

                //节点
                var eleEach = xdoc.CreateElement("name");
                eleLists.AppendChild(eleEach);
                //属性
                var attrId = xdoc.CreateAttribute("name");
                //该行第一列的数据
                var cellValue = row.Cells[0].Value;
                if (cellValue != null)
                {
                    attrId.Value = cellValue.ToString();
                }
                eleEach.Attributes.Append(attrId);
            }

            //完整路径
            var fullPath = CurXmlPath + CurXmlName;

            //设置xml生成样式
            var xmlSetting = new XmlWriterSettings
            {
                Encoding = new UTF8Encoding(false),
                Indent = true
            };

            //保存xml文件
            var writer = XmlWriter.Create(fullPath, xmlSetting);
            xdoc.Save(writer);
            writer.Close();

            //xdoc.Save(fullPath);
        }

        public void ReadXml()
        {
            //清空grilview
            metroGrid1.Rows.Clear();

            //完整路径
            var fullPath = CurXmlPath + CurXmlName;
            if (!File.Exists(fullPath)) return;
            xdoc.Load(fullPath);
            // 得到根节点Lists
            var xn = xdoc.SelectSingleNode("Lists");

            // 得到根节点的所有子节点
            if (xn == null) return;
            var xnl = xn.ChildNodes;

            for (var index = 0; index < xnl.Count; index++)
            {
                var node = xnl.Item(index);
                var attrs = node.Attributes;
                //metroGrid1.Columns.Add();
            }

            var ll = (from XmlElement xe in xnl select new ListData(xe.GetAttribute("name").ToString())).ToList();
            //手动设置方法
            foreach (var each in ll)
            {
                var index = metroGrid1.Rows.Add();
                //System.Console.WriteLine("index" + index);
                metroGrid1.Rows[index].SetValues(each.name);
                //System.Console.WriteLine("name:" + each.name);
            }
            //DataSource设置方法
            //metroGrid1.DataSource = ll;
        }

        #endregion

        #region 按钮事件

        /// <summary>
        /// 选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_select_Click(object sender, EventArgs e)
        {
            var s = " ";

            for (var i = this.metroGrid1.SelectedRows.Count; i > 0; i--)
            {
                var row = metroGrid1.SelectedRows[i - 1];
                if (!row.IsNewRow) //新行不
                {
                    s += metroGrid1.SelectedRows[i - 1].Cells[0].Value.ToString() + " ";
                }
            }
            //去掉最后的逗号
            s = s.Substring(0, s.Length - 1);
            form1.setTextBoxText(s);
        }

        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_add_Click(object sender, EventArgs e)
        {
            var index = metroGrid1.Rows.Add();
            //选中
            this.metroGrid1.CurrentCell = this.metroGrid1.Rows[index].Cells[0];
            //            var datasource = (List<ListData>) metroGrid1.DataSource;
            //            datasource.Add(new ListData("1234"));
            //            metroGrid1.DataSource = datasource;
            //            metroGrid1.Update();
        }

        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_delete_Click(object sender, EventArgs e)
        {
            var RSS = MessageBox.Show(this, "确定要删除选中行数据码？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (RSS)
            {
                case DialogResult.Yes:
                    for (var i = this.metroGrid1.SelectedRows.Count; i > 0; i--)
                    {
                        var row = metroGrid1.SelectedRows[i - 1];
                        if (!row.IsNewRow) //新行不删除
                        {
                            metroGrid1.Rows.Remove(row);
                        }
                    }
                    break;
                case DialogResult.No:
                    break;
            }
        }

        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButton1_Click(object sender, EventArgs e)
        {
            //关闭窗口时候保存资料
            SaveXml();

            this.Hide();
        }

        /// <summary>
        /// 测试按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            SaveXml();
        }

        #endregion

        #region 窗口事件

        /// <summary>
        /// 关闭前保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Console.WriteLine("Form2_FormClosing");
            SaveXml();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            asc.ControllInitializeSize(this);
        }

        /// <summary>
        /// 显示事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                //适应高度
//                var height = metroGrid1.RowCount * 25;
//                metroGrid1.Height = height;
//                System.Console.WriteLine(height);
//
//                //按钮
//                Button_add.Top = height + 20;
//                Button_select.Top = height + 20;
//                Button_delete.Top = height + 20;
//                Button_close.Top = height + 20;
//
//                Panel_list.Height = height + 20 + Button_add.Height + 40;
//                this.Height = Panel_list.Height;


                //listview
                //                var width = this.Width;
                //                metroListView1.Width = metroListView1.Width = width;
                //                var collections = metroListView1.Columns;
                //                //表头
                //                var header1 = collections[0];
                //                header1.Width = metroListView1.Width - 20;
                //                //适应高度
                //                var height = metroListView1.Items.Count*25;
                //                if (height > 400)
                //                {
                //                    height = 400;
                //                }
                //                metroListView1.Height = height;


                //                var btnWidth = (width - 10*5)/4;
                //                Button_add.Width = Button_delete.Width = Button_select.Width = Button_close.Width = btnWidth;

                //this.Refresh();
                //System.Console.WriteLine("Panel_list.Size" + Panel_list.Size);
                //                System.Console.WriteLine("metroListView1.Size" + metroListView1.Size);
                //                System.Console.WriteLine("Button_delete.Location" + Button_delete.Location);

                //System.Console.WriteLine("xdoc.DocumentElement == null");                
                //System.Console.WriteLine(xdoc.DocumentElement==null);
                //System.Console.WriteLine(metroGrid1.Height);

                //ReadXml();
            }
            else
            {
            }
        }

        /// <summary>
        /// 大小改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            //System.Console.WriteLine("Form2_SizeChanged");
            asc.ControlAutoSize(this);
        }

        #endregion

        /// <summary>
        /// 从form1打开form2
        /// </summary>
        public void Openform(string XmlName)
        {
            //读取xml
            this.CurXmlName = XmlName;
            this.ReadXml();

            this.Show();
            this.Width = 400;
            Win32Api.SwitchToThisWindow(this.Handle, true);
        }

        /// <summary>
        /// 更改语言
        /// </summary>
        /// <param name="rm"></param>
        public void changeLanguageText(ResourceManager rm)
        {
            Button_add.Text = rm.GetString("form2_add");
            Button_delete.Text = rm.GetString("form2_delete");
            Button_select.Text = rm.GetString("form2_select");
            Button_close.Text = rm.GetString("form2_close");
        }

        /// <summary>
        /// 显示行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroGrid1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                metroGrid1.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                metroGrid1.RowHeadersDefaultCellStyle.Font,
                rectangle,
                metroGrid1.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_search_Click(object sender, EventArgs e)
        {
            //循环遍历Gridlist
            for (var index = 0; index < metroGrid1.Rows.Count; index++)
            {
                //metroGrid1.Rows[index];

            }
        }
    }
}