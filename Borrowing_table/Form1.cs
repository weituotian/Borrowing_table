using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace Borrowing_table
{
    public partial class Form1 : MetroForm
    {
        private Form2 _list_form;
        private OutPut _outPut;

        public Form1()
        {
            InitializeComponent();
            _list_form = new Form2(this);
            _outPut = new OutPut();

            System.Console.WriteLine(this.Label_motion.Font.Name);
            System.Console.WriteLine(this.Font.Name);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //语言选择下拉框
            ComboBox_language.SelectedIndex = 0;
            //
            //metroListView1.Height = 600;
        }

        #region 语言选择

        /// <summary>
        /// 语言下拉框被选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_language_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = ComboBox_language.SelectedIndex;
            switch (index)
            {
                case 0:
                    //中文
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-Hans");
                    break;
                case 1:
                    //日文
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ja-JP");
                    break;
                case 2:
                    //英语
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                    break;
                case 3:
                    //俄语
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("be");
                    break;
                case 4:
                    //韩语
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ko-kR");
                    break;
                default:

                    break;
            }
            UpDataMainFormUiLanguage();
        }

        private void UpDataMainFormUiLanguage()
        {
            var rm = new ResourceManager(typeof(Form1));
            UpDataMainFormMenuLanguage(rm);
            UpDataMainFormToolBarLanguage(rm);
            this.Refresh();
        }

        private string _txt_animator;
        private string _txt_pose;
        private string _txt_attachment;
        private string _txt_model;
        private string _txt_stage;
        private string _txt_motion;
        private string _txt_cam;
        private string _txt_BGM;
        private string _txt_MME;


        /// <summary>
        /// 更新主窗口的文本
        /// </summary>
        /// <param name="rm"></param>
        protected virtual void UpDataMainFormToolBarLanguage(ResourceManager rm)
        {
            this.Text = rm.GetString("form_title");


            //label
            _txt_animator = rm.GetString("animator");
            label_animator.Text = _txt_animator + " :";

            _txt_pose = rm.GetString("pose");
            label_pose.Text = _txt_pose + "(.vmd):";

            _txt_attachment = rm.GetString("attachment");
            label_attachment.Text = _txt_attachment + "(pmd-pmx-x):";

            _txt_model = rm.GetString("model");
            label_model.Text = _txt_model + "(PMX-PMD):";

            _txt_stage = rm.GetString("stage");
            Label_stage.Text = _txt_stage + "(pmd-pmx-x)";

            _txt_motion = rm.GetString("motion");
            Label_motion.Text = _txt_motion + "(VMD)：";

            _txt_cam = rm.GetString("cam");
            Label_cam.Text = _txt_cam + "(VMD)：";
            //Label_background.Text = rm.GetString("background");

            _txt_BGM = rm.GetString("bgm");
            Label_BGM.Text = _txt_BGM + "(WAV)：";

            _txt_MME = rm.GetString("mme");
            Label_MME.Text = _txt_MME;

            //输出按钮
            button_output.Text = rm.GetString("button_output");

            //form2
            _list_form.changeLanguageText(rm);

            Link_about.Text = rm.GetString("Link_about");
        }

        protected virtual void UpDataMainFormMenuLanguage(ResourceManager rm)
        {
        }

        #endregion

        #region 打开常用按钮

        /// <summary>
        /// 获得控件距离屏幕的坐标
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private Point LocationOnClient(Control c)
        {
            var retval = new Point(0, 0);
            for (; c.Parent != null; c = c.Parent)
            {
                retval.Offset(c.Location);
            }
            retval.Offset(this.Location);
            return retval;
        }

        /// <summary>
        /// 打开常用按钮通用函数
        /// </summary>
        private void link_click()
        {
            //先隐藏一次
            //_list_form.Hide();
            //_list_form.Refresh();

            //显示窗体
            _list_form.Show();
            //位置
            //var point = LocationOnClient(TextBox_model);
            // point.Y += TextBox_model.Height;
            // _list_form.Location = point;

            //宽度
            _list_form.Width = TextBox_model.Width;

            //最前端显示
            // _list_form.TopMost = true;
            Win32Api.SwitchToThisWindow(_list_form.Handle, true);

            //_list_form.Size=new Size(400,400);
            //System.Console.WriteLine(@"Top:" + _list_form.Top);
            //System.Console.WriteLine(@"Left:" + _list_form.Left);
        }

        /// <summary>
        /// 设置textbox的值
        /// </summary>
        /// <param name="s"></param>
        public void setTextBoxText(string s)
        {
            _currentTextBox.Text += s;
        }

        //当前编辑器
        private MetroTextBox _currentTextBox;

        /// <summary>
        /// 舞台
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Link_stage_Click(object sender, EventArgs e)
        {
            _currentTextBox = TextBox_stage;
            _list_form.Openform("stage.xml");
        }

        /// <summary>
        /// 模型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void link_model_Click(object sender, EventArgs e)
        {
            _currentTextBox = TextBox_model;

            _list_form.Openform("model.xml");
        }

        /// <summary>
        /// 动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Link_motion_Click(object sender, EventArgs e)
        {
            _currentTextBox = TextBox_motion;

            _list_form.Openform("motion.xml");
        }

        /// <summary>
        /// 镜头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Link_cam_Click(object sender, EventArgs e)
        {
            _currentTextBox = TextBox_cam;

            _list_form.Openform("cam.xml");
        }

        /// <summary>
        /// 背景
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Link_background_Click(object sender, EventArgs e)
        {
            _currentTextBox = TextBox_background;

            _list_form.Openform("background.xml");
        }

        /// <summary>
        /// MME
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Link_MME_Click(object sender, EventArgs e)
        {
            _currentTextBox = TextBox_MME;

            _list_form.Openform("mme.xml");
        }

        /// <summary>
        /// BGM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Link_BGM_Click(object sender, EventArgs e)
        {
            _currentTextBox = TextBox_BGM;

            _list_form.Openform("bgm.xml");
        }

        /// <summary>
        /// 视频作者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Link_animator_Click(object sender, EventArgs e)
        {
            _currentTextBox = TextBox_animator;

            _list_form.Openform("animator.xml");
        }

        /// <summary>
        /// 姿势数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Link_pose_Click(object sender, EventArgs e)
        {
            _currentTextBox = TextBox_pose;

            _list_form.Openform("pose.xml");
        }

        /// <summary>
        /// 附件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Link_attachment_Click(object sender, EventArgs e)
        {
            _currentTextBox = TextBox_attachment;

            _list_form.Openform("attachment.xml");
        }

        #endregion

        /// <summary>
        /// 输出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButton1_Click(object sender, EventArgs e)
        {
            var str = "";
            //动画作者
            if (TextBox_animator.Text != "")
            {
                str += _txt_animator + " : " + TextBox_animator.Text + "\r\n";
            }
            //模型
            if (TextBox_model.Text != "")
            {
                str += _txt_model + " : " + TextBox_model.Text + "\r\n";
            }
            //场景
            if (TextBox_stage.Text != "")
            {
                str += _txt_stage + " : " + TextBox_stage.Text + "\r\n";
            }

            //动作
            if (TextBox_motion.Text != "")
            {
                str += _txt_motion + " : " + TextBox_motion.Text + "\r\n";
            }
            //姿势
            if (TextBox_pose.Text != "")
            {
                str += _txt_pose + " : " + TextBox_pose.Text + "\r\n";
            }
            //镜头
            if (TextBox_cam.Text != "")
            {
                str += _txt_cam + " : " + TextBox_cam.Text + "\r\n";
            }
//            if (TextBox_background.Text != "") //背景
//            {
//                str += Label_background.Text + TextBox_background.Text + "\r\n";
//            }
            //mme
            if (TextBox_MME.Text != "")
            {
                str += _txt_MME + " : " + TextBox_MME.Text + "\r\n";
            }
            //附件
            if (TextBox_attachment.Text != "")
            {
                str += _txt_attachment + " : " + TextBox_attachment.Text + "\r\n";
            }
            //音乐
            if (TextBox_BGM.Text != "")
            {
                str += _txt_BGM + " : " + TextBox_BGM.Text + "\r\n";
            }

            _outPut.setText(str);
            _outPut.Show();
        }

        /// <summary>
        /// 关于我们
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Link_about_Click(object sender, EventArgs e)
        {
            var about = new About();
            about.ShowDialog();
        }
    }
}