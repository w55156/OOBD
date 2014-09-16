using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace OpenErpMB
{
    public partial class Form1 : Form
    {
        public Form1()  //
        {
            InitializeComponent();
        }

        private static bool CkDataGridRowValid(DataGridViewRow row)  //验证行是否有效
        {
            return row.Cells["FieldLabel"].Value != null && row.Cells["FieldType"].Value != null && row.Cells["FieldName"].Value != null;
        }

        private void button1_Click(object sender, EventArgs e)  //按钮单击事件
        {
            Generate();

        }

        private bool Generate()  //生成模块方法
        {
            #region 获取变量
            string model_discrib = tbMname.Text.Trim();
            string model_name = tbTable.Text.Trim();
            string model_name2 = model_name;
            if (model_name2.Contains("_"))
            {
                model_name2 = model_name2.Replace('_','.');
            }
            string model_info = tbMdescription.Text.Trim();
            string model_depend = tbMdepends.Text.Trim();
            string website = this.tbWebsite.Text.Trim();  //网站URL
            string pMenuID = this.tbPmenuID.Text.Trim();  //（父）上级菜单ID
            if (string.IsNullOrEmpty(model_discrib))
            {
                MessageBox.Show("模块名称 不能为空!!!");
                return false;
            }
            if (string.IsNullOrEmpty(model_name))
            {
                MessageBox.Show("数据表 不能为空!!!");
                return false;
            }
            if (string.IsNullOrEmpty(pMenuID))
            {
                MessageBox.Show("父菜单 不能为空!!!");
                return false;
            }
            #endregion

            //打开保存对话构
            FolderBrowserDialog fbdg = new FolderBrowserDialog();
            fbdg.ShowNewFolderButton = true;
            fbdg.Description = "请选择保存路径";

            if (fbdg.ShowDialog() == DialogResult.OK)
            {
                #region  验证字段成功
                string base_on = tbMdepends.Text.Trim();  //所依赖的模块列表
                string creater = tbAuthor.Text.Trim();  //作者，创建者
                string path_model_folder = fbdg.SelectedPath + "\\" + model_name;  //模型文件夹路径
                string path_init = path_model_folder + @"\__init__.py";  //__init__文件路径
                string path_openerp = path_model_folder + @"\__openerp__.py";  //__openerp__文件路径
                string path_model = path_model_folder + @"\" + model_name + ".py";  //model文件路径
                string path_model_view = path_model_folder + @"\" + model_name + "_view.xml";  //视图xml文件路径
                try
                {

                    if (!Directory.Exists(path_model_folder))  //模型文件目录不存在,则创建
                    {
                        #region 创建文件夹
                        Directory.CreateDirectory(path_model_folder);
                        Directory.CreateDirectory(path_model_folder + @"\i18n");  //语言文件夹
                        Directory.CreateDirectory(path_model_folder + @"\images");  //图片文件夹
                        Directory.CreateDirectory(path_model_folder + @"\report");  //报表文件夹
                        Directory.CreateDirectory(path_model_folder + @"\security");  //权限文件夹
                        Directory.CreateDirectory(path_model_folder + @"\static");  //web标识文件夹
                        Directory.CreateDirectory(path_model_folder + @"\wizard");  //向导文件夹
                        #endregion

                        #region 写入文件__init__.py
                        FileStream fs_init = new FileStream(path_init, FileMode.Create, FileAccess.Write);  //写入文件__init__.py
                        StreamWriter sw_init = new StreamWriter(fs_init, Encoding.UTF8);
                        sw_init.WriteLine("# -*- encoding: utf-8 -*-");
                        sw_init.WriteLine("");
                        sw_init.WriteLine("");
                        sw_init.WriteLine("import " + model_name2);
                        sw_init.Close();
                        fs_init.Close();
                        #endregion

                        #region  写入文件__openerp__.py
                        FileStream fs_openerp = new FileStream(path_openerp, FileMode.Create, FileAccess.Write);  //写入文件__openerp__.py文件
                        StreamWriter sw_openerp = new StreamWriter(fs_openerp, Encoding.UTF8);
                        sw_openerp.WriteLine("# -*- encoding: utf-8 -*-");
                        sw_openerp.WriteLine("");
                        sw_openerp.WriteLine("");
                        sw_openerp.WriteLine("{");
                        sw_openerp.WriteLine("  \'name\': \'" + model_discrib + "\',");
                        sw_openerp.WriteLine("  \'version\': \'0.1\',");
                        sw_openerp.WriteLine("  \"category\" : \"Generic Modules/Others\",");
                        sw_openerp.WriteLine("  \'description\': \"" + model_info + "\",");
                        sw_openerp.WriteLine("  \'author\': \'" + creater + "\',");
                        sw_openerp.WriteLine("  \'website\': \'" + website + "\',");
                        sw_openerp.WriteLine("  \'depends\': [" + model_depend + "],");
                        sw_openerp.WriteLine("  \'data\': [\'" + model_name + "_view.xml\'," + "],");
                        sw_openerp.WriteLine("  \'demo\': [],");
                        sw_openerp.WriteLine("  \'test\': [],");
                        sw_openerp.WriteLine("  \'images\': [\'images/" + model_name + ".jpeg\'," + "],");
                        sw_openerp.WriteLine("  \'css\': [\'static/src/css/" + model_name + ".css\'," + "],");
                        sw_openerp.WriteLine("  \'installable\': True,");
                        sw_openerp.WriteLine("  \'auto_install\': False,");
                        sw_openerp.WriteLine("}");
                        sw_openerp.Close();
                        fs_openerp.Close();
                        #endregion

                        #region  写入文件 model_name.py
                        FileStream fs_model = new FileStream(path_model, FileMode.Create, FileAccess.Write);
                        StreamWriter sw_model = new StreamWriter(fs_model, Encoding.UTF8);
                        sw_model.WriteLine("# -*- encoding: utf-8 -*-");
                        sw_model.WriteLine("");
                        sw_model.WriteLine("########################################################################################################################################");
                        sw_model.WriteLine("#");
                        sw_model.WriteLine("#    Created by OpenERP ModelBuilder, ChunLai Wang, NingBo ZheJiang China, @2013, QQ:363682158");
                        sw_model.WriteLine("#");
                        sw_model.WriteLine("#-------------------------------------------对象定义的完整属性说明-----------------------------------------------------------------");
                        sw_model.WriteLine("#");
                        sw_model.WriteLine("#_auto：是否自动创建对象对应的Table，缺省值为: True,");
                        sw_model.WriteLine("#　　当安装或升级模块时，OpenERP会自动在数据库中为模块中定义的每个对象创建相应的Table,");
                        sw_model.WriteLine("#　　当这个属性设为False时，OpenERP不会自动创建Table，这通常表示数据库表已经存在，");
                        sw_model.WriteLine("#　　例如，当对象是从数据库视图（View）中读取数据时，通常设为False,当_auto的值为False时，");
                        sw_model.WriteLine("#　　OE不会自动在数据库中创建相应的表，开发者可以在对应类的init()方法中定义表或视图的SQL。");
                        sw_model.WriteLine("#_name：对象的唯一标识符，必须是全局唯一,");
                        sw_model.WriteLine("#　　这个标识符用于存取对象，其格式通常是 ModuleName.ClassName,");
                        sw_model.WriteLine("#　　对应的，系统会字段创建数据库表 ModuleName_ClassName。");
                        sw_model.WriteLine("#　　当使用_inherit时可以与被继承的类的_name一致，_name一致表示不创建新的数据库表，而直接在原表上修改");
                        sw_model.WriteLine("#_descript：对象说明性文字，任意文字。");
                        sw_model.WriteLine("#_log_access：是否自动在对应的数据表中增加create_uid, create_date, write_uid, write_date");
                        sw_model.WriteLine("#　　四个字段，缺省值为True，即字段增加,这四个字段分布记录record的创建人，");
                        sw_model.WriteLine("#　　创建日期，修改人，修改日期。这四个字段值可以 用对象的方法（perm_read）读取。");
                        sw_model.WriteLine("#_constraints: 定义于对象上的约束（constraints），通常是定义一个检查函数。");
                        sw_model.WriteLine("#　　用法：_constraints = [(method,'error message',list_of_field_names),] ");
                        sw_model.WriteLine("#_defaults: 定义字段的缺省值。当创建一条新记录（record or resource）时，记录中各字段的缺省值在此定义。");
                        sw_model.WriteLine("#　　用法：_defaults = {'field_name':function,}");
                        sw_model.WriteLine("#_order: 定义search()和read()方法的结果记录的排序规则，和SQL语句中的order 类似，缺省值是id,即按id升序排序。");
                        sw_model.WriteLine("#_rec_name: 标识record name的字段。缺省情况（name_get没被重载的话）方法name_get()返回本字段值。_rec_name通常用于记录的显示，");
                        sw_model.WriteLine("#　　例如，销售订单中包含业务伙伴，当在销售订单上显示业务伙伴时，系统缺省的是显示业务伙伴记录的_rec_name。");
                        sw_model.WriteLine("#_sequence: 数据库表的id字段的序列采集器，缺省值为: None。OpenERP创建数据库表时，会自动增加id字段作为主键，并自动为该表创建一个序列");
                        sw_model.WriteLine("#　　（名字通常是“表名_id_seq”）作为id字段值的采集器。如果想使用数据库中已有的序列器，则在此处定义序列器名。");
                        sw_model.WriteLine("#_sql: _auto为True时，可以在这里定义创建数据库表的SQL语句。不过5.0以后好像不支持了，不建议使用。");
                        sw_model.WriteLine("#_sql_constraints: 定义于对象上的约束（constraints），和SQL文中的约束类似，用法：_sql_constraints =");
                        sw_model.WriteLine("#　　 [('code_company_uniq', 'unique (code,company_id)', 'The code of the account must be unique per company !'), ]");
                        sw_model.WriteLine("#_table: 待创建的数据库表名，缺省值是和_name一样，只是将.替换成_");
                        sw_model.WriteLine("#_inherits,_inherit: _inherits和_inherit都用于对象的继承。");
                        sw_model.WriteLine("#");
                        sw_model.WriteLine("######################################################################################################################################");
                        sw_model.WriteLine("");
                        sw_model.WriteLine("");
                        sw_model.WriteLine("from openerp.osv import osv");
                        sw_model.WriteLine("from openerp.osv import fields");
                        sw_model.WriteLine("");
                        sw_model.WriteLine("class " + model_name + "(osv.osv):");
                        sw_model.WriteLine("    _name = \'" + model_name2 + "\'");
                        sw_model.WriteLine("    _description = u\'" + model_discrib + "\'");
                        sw_model.WriteLine("    _log_access = True");
                        sw_model.WriteLine("    _auto = True");

                        #region  写入字段
                        sw_model.WriteLine("    _columns = {");
                        try
                        {

                            foreach (DataGridViewRow row in this.dataGridView1.Rows)
                            {
                                while (CkDataGridRowValid(row))
                                {
                                    string field_label = row.Cells["FieldLabel"].Value.ToString().Trim();
                                    string field_name = row.Cells["FieldName"].Value.ToString().Trim();
                                    string required = row.Cells["Required"].Value.ToString().Trim();
                                    string fied_type = row.Cells["FieldType"].Value.ToString().Trim();
                                    string searchable = row.Cells["Searchable"].Value.ToString().Trim();
                                    string read_only = row.Cells["ReadOnly"].Value.ToString().Trim();
                                    string translate = row.Cells["Translate"].Value.ToString().Trim();
                                    sw_model.WriteLine("           \'" + field_name + "\' : fields." + fied_type + "(u\'" + field_label + "\',readonly=" + read_only + ",required=" + required + ",translate=" + translate + "),  ");
                                    break;
                                }

                            }

                        }
                        catch (Exception e_str)
                        {

                            MessageBox.Show("写入文件 model_name.py：写入字段 程序出错,请联系作者!!!" + e_str.ToString());
                        }
                        sw_model.WriteLine("          }");
                        #endregion

                        //sw_model.WriteLine(model_name + "() #对象定义结束");  2014.09.04
                        sw_model.WriteLine("#对象定义结束");
                        sw_model.Close();
                        fs_model.Close();
                        #endregion

                        #region  写入文件 model_name_view.xml
                        FileStream fs_model_view = new FileStream(path_model_view, FileMode.Create, FileAccess.Write);
                        StreamWriter sw_model_view = new StreamWriter(fs_model_view, Encoding.UTF8);
                        sw_model_view.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                        sw_model_view.WriteLine("<openerp>");
                        sw_model_view.WriteLine("  <data>");

                        #region 搜索视图定义
                        sw_model_view.WriteLine("");
                        sw_model_view.WriteLine("");
                        sw_model_view.WriteLine("    <!-- Search View -->");
                        sw_model_view.WriteLine("    <record model=\"ir.ui.view\" id=\"view_" + model_name + "_search\">");
                        sw_model_view.WriteLine("      <field name=\"name\">" + model_name + ".search</field>");
                        sw_model_view.WriteLine("      <field name=\"model\">" + model_name2 + "</field>");
                        sw_model_view.WriteLine("      <field name=\"type\">search</field>");
                        sw_model_view.WriteLine("      <field name=\"arch\" type=\"xml\">");
                        sw_model_view.WriteLine("        <search string=\"" + model_name + "\">");

                        #region  写入字段
                        try
                        {

                            foreach (DataGridViewRow row in this.dataGridView1.Rows)
                            {
                                while (CkDataGridRowValid(row))
                                {
                                    string field_name = row.Cells["FieldName"].Value.ToString().Trim();

                                    if (row.Cells["Searchable"].Value.ToString() == "True")
                                    {

                                        sw_model_view.WriteLine("          <field name=\"" + field_name + "\" />");  //字段
                                        break;
                                    }

                                }

                            }

                        }
                        catch (Exception e_str)
                        {

                            MessageBox.Show("搜索视图定义：写入字段 程序出错,请联系作者!!!" + e_str.ToString());
                        }
                        #endregion

                        sw_model_view.WriteLine("        </search>");
                        sw_model_view.WriteLine("      </field>");
                        sw_model_view.WriteLine("    </record>");
                        #endregion

                        #region 树形视图定义
                        sw_model_view.WriteLine("");
                        sw_model_view.WriteLine("");
                        sw_model_view.WriteLine("    <!-- tree view -->");
                        sw_model_view.WriteLine("    <record model=\"ir.ui.view\" id=\"view_" + model_name + "_tree\">");
                        sw_model_view.WriteLine("      <field name=\"name\">" + model_name + ".tree</field>");
                        sw_model_view.WriteLine("      <field name=\"model\">" + model_name2 + "</field>");
                        sw_model_view.WriteLine("      <field name=\"type\">tree</field>");
                        sw_model_view.WriteLine("      <field name=\"arch\" type=\"xml\">");
                        sw_model_view.WriteLine("        <tree string=\"" + model_name + "\">");

                        #region  写入字段
                        try
                        {

                            foreach (DataGridViewRow row in this.dataGridView1.Rows)
                            {
                                while (CkDataGridRowValid(row))
                                {
                                    string field_name = row.Cells["FieldName"].Value.ToString().Trim();
                                    string slt = "0";
                                    string tview = "1";
                                    if (row.Cells["Searchable"].Value.ToString() == "True")
                                    {
                                        slt = "1";
                                    }
                                    if (row.Cells["TView"].Value.ToString() == "True")
                                    {
                                        tview = "0";
                                    }
                                    sw_model_view.WriteLine("          <field name=\"" + field_name + "\" select=\"" + slt + "\" invisible=\"" + tview + "\" />");  //字段
                                    break;
                                }

                            }

                        }
                        catch (Exception e_str)
                        {

                            MessageBox.Show("树形视图定义：写入字段 程序出错,请联系作者!!!" + e_str.ToString());
                        }
                        #endregion

                        sw_model_view.WriteLine("        </tree>");
                        sw_model_view.WriteLine("      </field>");
                        sw_model_view.WriteLine("    </record>");
                        #endregion

                        #region  表单视图定义
                        #region sheet视图
                        if (this.rb1.Checked)
                        {
                            sw_model_view.WriteLine("");
                            sw_model_view.WriteLine("");
                            sw_model_view.WriteLine("    <!-- form view -->");
                            sw_model_view.WriteLine("    <record model=\"ir.ui.view\" id=\"view_" + model_name + "_form\">");
                            sw_model_view.WriteLine("      <field name=\"name\">" + model_name + ".form</field>");
                            sw_model_view.WriteLine("      <field name=\"model\">" + model_name2 + "</field>");
                            sw_model_view.WriteLine("      <field name=\"type\">form</field>");
                            sw_model_view.WriteLine("      <field name=\"arch\" type=\"xml\">");
                            sw_model_view.WriteLine("        <form string=\"" + model_name + "\" version=\"7.0\">");
                            sw_model_view.WriteLine("          <header>");
                            sw_model_view.WriteLine("          </header>");
                            sw_model_view.WriteLine("          <sheet>");
                            sw_model_view.WriteLine("            <group>");
                            #region  写入字段
                            try
                            {

                                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                                {
                                    while (CkDataGridRowValid(row))
                                    {
                                        string field_name = row.Cells["FieldName"].Value.ToString().Trim();
                                        string fview = "1";
                                        if (row.Cells["FView"].Value.ToString() == "True")
                                        {
                                            fview = "0";
                                        }
                                        //sw_model_view.WriteLine("            <label for=\"" + field_name + "\" />");  //字段
                                        sw_model_view.WriteLine("              <field name=\"" + field_name + "\" invisible=\"" + fview + "\" />");  //字段
                                        break;
                                    }

                                }

                            }
                            catch (Exception e_str)
                            {

                                MessageBox.Show("表单视图定义：写入字段 程序出错,请联系作者!!!" + e_str.ToString());
                            }
                            #endregion
                            sw_model_view.WriteLine("            </group>");
                            sw_model_view.WriteLine("          </sheet>");
                            sw_model_view.WriteLine("        </form>");
                            sw_model_view.WriteLine("      </field>");
                            sw_model_view.WriteLine("    </record>");
                        }
                        #endregion
                        
                        #region 普通视图
                        else
                        {
                            sw_model_view.WriteLine("");
                            sw_model_view.WriteLine("");
                            sw_model_view.WriteLine("    <!-- form view -->");
                            sw_model_view.WriteLine("    <record model=\"ir.ui.view\" id=\"view_" + model_name + "_form\">");
                            sw_model_view.WriteLine("      <field name=\"name\">" + model_name + ".form</field>");
                            sw_model_view.WriteLine("      <field name=\"model\">" + model_name2 + "</field>");
                            sw_model_view.WriteLine("      <field name=\"type\">form</field>");
                            sw_model_view.WriteLine("      <field name=\"arch\" type=\"xml\">");
                            sw_model_view.WriteLine("        <form string=\"" + model_name + "\" version=\"7.0\">");
                            sw_model_view.WriteLine("          <group>");
                            #region  写入字段
                            try
                            {

                                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                                {
                                    while (CkDataGridRowValid(row))
                                    {
                                        string field_name = row.Cells["FieldName"].Value.ToString().Trim();
                                        string fview = "1";
                                        if (row.Cells["FView"].Value.ToString() == "True")
                                        {
                                            fview = "0";
                                        }
                                        sw_model_view.WriteLine("            <field name=\"" + field_name + "\" invisible=\"" + fview + "\" />");  //字段
                                        break;
                                    }

                                }

                            }
                            catch (Exception e_str)
                            {

                                MessageBox.Show("表单视图定义：写入字段 程序出错,请联系作者!!!" + e_str.ToString());
                            }
                            #endregion
                            sw_model_view.WriteLine("          </group>");
                            sw_model_view.WriteLine("        </form>");
                            sw_model_view.WriteLine("      </field>");
                            sw_model_view.WriteLine("    </record>");
                        }
                        #endregion
                        #endregion

                        #region  动作定义
                        sw_model_view.WriteLine("");
                        sw_model_view.WriteLine("");
                        sw_model_view.WriteLine("    <!-- actions -->");
                        sw_model_view.WriteLine("    <record model=\"ir.actions.act_window\" id=\"action_" + model_name + "_form\">");
                        sw_model_view.WriteLine("      <field name=\"name\">" + model_discrib + "</field>");
                        sw_model_view.WriteLine("      <field name=\"type\">ir.actions.act_window</field>");
                        sw_model_view.WriteLine("      <field name=\"res_model\">" + model_name2 + "</field>");
                        sw_model_view.WriteLine("      <field name=\"view_type\">form</field>");
                        sw_model_view.WriteLine("      <field name=\"view_mode\">tree,form</field>");
                        sw_model_view.WriteLine("      <field name=\"view_id\" ref=\"view_" + model_name + "_tree\"/>");
                        sw_model_view.WriteLine("      <field name=\"search_view_id\" ref=\"view_" + model_name + "_search\"/>");
                        sw_model_view.WriteLine("    </record>");
                        #endregion

                        #region  菜单定义
                        sw_model_view.WriteLine("");
                        sw_model_view.WriteLine("");
                        sw_model_view.WriteLine("    <!-- menuitem -->");
                        sw_model_view.WriteLine("    <menuitem name=\"" + model_discrib + "\" id=\"menu_" + model_name + "_form\" parent=\"" + pMenuID + "\" action=\"action_" + model_name + "_form\"/>");
                        sw_model_view.WriteLine("  </data>");
                        sw_model_view.WriteLine("</openerp>");
                        #endregion

                        sw_model_view.Close();
                        fs_model_view.Close();
                        #endregion

                        MessageBox.Show("模型自动创建成功,保存在:" + path_model_folder.ToString() + ",请查看!");
                    }
                    else
                    {
                        MessageBox.Show("模型目录已经存在，请删除同名目录后再操作!!!");
                    }
                }
                catch (Exception e_str)
                {

                    MessageBox.Show("The process failed:" + e_str.ToString());
                }
                finally { }
                #endregion
            }
            return true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)  //单元格内容单击事件
        {

        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)  //单元格内容默认值设置
        {
            e.Row.Cells["FieldType"].Value = "char";
            e.Row.Cells["Required"].Value = true;
            e.Row.Cells["ReadOnly"].Value = false;
            e.Row.Cells["Searchable"].Value = true;
            e.Row.Cells["Translate"].Value = true;
            e.Row.Cells["TView"].Value = true;
            e.Row.Cells["FView"].Value = true;
        }

        private void Form1_Load(object sender, EventArgs e)  //窗口加载事件
        {

        }

        private bool CheckFormIsOpen(string asFormName)  //判断窗口是否打开
        {
            bool bResult = false;
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == asFormName)
                {
                    bResult = true;
                    break;
                }
            }
            return bResult;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)  //字段标签内容更改事件
        {
            if (CheckFormIsOpen("Form1"))
            {
                if (e.ColumnIndex == this.dataGridView1.Columns[0].Index)
                {

                    string cell_str = this.dataGridView1.Rows[e.RowIndex].Cells["FieldLabel"].Value.ToString();
                    char[] cell_arr = cell_str.ToCharArray();
                    string num_one = ChineseToPinYin.ToPinYin(cell_arr[0].ToString());
                    for (int i = 1; i < cell_arr.Length; i++)
                    {
                        num_one = num_one + ChineseToPinYin.ToPinYin(cell_arr[i].ToString()).Substring(0, 1);
                    }
                    if (cbPreX.Checked)
                    {
                        this.dataGridView1.Rows[e.RowIndex].Cells["FieldName"].Value = "x_" + num_one;
                    }
                    else
                    {
                        this.dataGridView1.Rows[e.RowIndex].Cells["FieldName"].Value = num_one;
                    }
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)  //模型描述 更改事件
        {
            if (tbMname.Text.Trim() != "")
            {
                string text_str = tbMname.Text.Trim();
                string num_one = ChineseToPinYin.ToPinYin(text_str);
                if (cbPreX.Checked)
                {
                    this.tbTable.Text = "x_" + num_one;
                }
                else
                {
                    this.tbTable.Text = num_one;
                }
            }
            else
            {
                this.tbTable.Text = "";
            }

        }

        private void button2_Click(object sender, EventArgs e)  //关于按钮事件
        {
            AboutBox1 about_box = new AboutBox1();
            about_box.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdg = new FolderBrowserDialog();
            fbdg.ShowNewFolderButton = true;
            fbdg.Description = "请选择保存路径";



        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)  //当添加一行
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                this.dataGridView1.Rows[e.RowIndex + i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView1.Rows[e.RowIndex + i].HeaderCell.Value = (e.RowIndex + i + 1).ToString();
            }
            for (int i = e.RowIndex + e.RowCount; i < this.dataGridView1.Rows.Count; i++)
            {
                this.dataGridView1.Rows[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }

        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)  //当删除一行
        {
            if (dataGridView1.Rows.Count != 0)
            {
                for (int i = 0; i < e.RowCount; i++)
                {
                    this.dataGridView1.Rows[e.RowIndex + i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dataGridView1.Rows[e.RowIndex + i].HeaderCell.Value = (e.RowIndex + i + 1).ToString();
                }

                for (int i = e.RowIndex + e.RowCount; i < this.dataGridView1.Rows.Count; i++)
                {
                    this.dataGridView1.Rows[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
                }

            }
        }
    };
}
