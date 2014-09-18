namespace OpenErpMB
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbMname = new System.Windows.Forms.TextBox();
            this.tbTable = new System.Windows.Forms.TextBox();
            this.tbAuthor = new System.Windows.Forms.TextBox();
            this.tbMdepends = new System.Windows.Forms.TextBox();
            this.cbPreX = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMdescription = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tbPmenuID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbWebsite = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.FieldLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Required = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TView = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FView = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(915, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "生成模型";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "模块名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "数据表";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(514, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "依赖模块";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(902, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "添加前缀x";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(768, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "作者";
            // 
            // tbMname
            // 
            this.tbMname.Location = new System.Drawing.Point(74, 7);
            this.tbMname.Name = "tbMname";
            this.tbMname.Size = new System.Drawing.Size(180, 21);
            this.tbMname.TabIndex = 7;
            this.toolTip1.SetToolTip(this.tbMname, "中文名称，模块对象及对应的数据表默认是模块名称的全拼");
            this.tbMname.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tbTable
            // 
            this.tbTable.Location = new System.Drawing.Point(316, 8);
            this.tbTable.Name = "tbTable";
            this.tbTable.Size = new System.Drawing.Size(180, 21);
            this.tbTable.TabIndex = 8;
            // 
            // tbAuthor
            // 
            this.tbAuthor.Location = new System.Drawing.Point(802, 64);
            this.tbAuthor.Name = "tbAuthor";
            this.tbAuthor.Size = new System.Drawing.Size(67, 21);
            this.tbAuthor.TabIndex = 10;
            this.tbAuthor.Text = "王春来";
            // 
            // tbMdepends
            // 
            this.tbMdepends.Location = new System.Drawing.Point(578, 8);
            this.tbMdepends.Name = "tbMdepends";
            this.tbMdepends.Size = new System.Drawing.Size(291, 21);
            this.tbMdepends.TabIndex = 11;
            this.tbMdepends.Text = "\'base\',";
            // 
            // cbPreX
            // 
            this.cbPreX.AutoSize = true;
            this.cbPreX.Location = new System.Drawing.Point(969, 12);
            this.cbPreX.Name = "cbPreX";
            this.cbPreX.Size = new System.Drawing.Size(15, 14);
            this.cbPreX.TabIndex = 12;
            this.cbPreX.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FieldLabel,
            this.FieldName,
            this.FieldType,
            this.Required,
            this.TView,
            this.FView});
            this.dataGridView1.Location = new System.Drawing.Point(3, 124);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(993, 446);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_DefaultValuesNeeded);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(915, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "关于";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "模块说明";
            // 
            // tbMdescription
            // 
            this.tbMdescription.Location = new System.Drawing.Point(73, 37);
            this.tbMdescription.Multiline = true;
            this.tbMdescription.Name = "tbMdescription";
            this.tbMdescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMdescription.Size = new System.Drawing.Size(423, 77);
            this.tbMdescription.TabIndex = 16;
            this.toolTip1.SetToolTip(this.tbMdescription, "内容将写入__openerp__.py的description对应值");
            // 
            // tbPmenuID
            // 
            this.tbPmenuID.Location = new System.Drawing.Point(578, 35);
            this.tbPmenuID.Name = "tbPmenuID";
            this.tbPmenuID.Size = new System.Drawing.Size(291, 21);
            this.tbPmenuID.TabIndex = 18;
            this.toolTip1.SetToolTip(this.tbPmenuID, "请指定一个父菜单ID，可以激活odoo的开发者模式找到您想要的上级菜单。");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(514, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "父菜单ID";
            // 
            // tbWebsite
            // 
            this.tbWebsite.Location = new System.Drawing.Point(578, 64);
            this.tbWebsite.Name = "tbWebsite";
            this.tbWebsite.Size = new System.Drawing.Size(169, 21);
            this.tbWebsite.TabIndex = 20;
            this.tbWebsite.Text = "http://";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(538, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "网站";
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Location = new System.Drawing.Point(657, 97);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(71, 16);
            this.rb2.TabIndex = 21;
            this.rb2.Text = "普通视图";
            this.rb2.UseVisualStyleBackColor = true;
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(578, 97);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(77, 16);
            this.rb1.TabIndex = 22;
            this.rb1.TabStop = true;
            this.rb1.Text = "sheet视图";
            this.rb1.UseVisualStyleBackColor = true;
            // 
            // FieldLabel
            // 
            this.FieldLabel.FillWeight = 29.06375F;
            this.FieldLabel.HeaderText = "字段标签";
            this.FieldLabel.Name = "FieldLabel";
            this.FieldLabel.ToolTipText = "字段描述,请输入中文汉字";
            // 
            // FieldName
            // 
            this.FieldName.FillWeight = 29.06375F;
            this.FieldName.HeaderText = "字段";
            this.FieldName.Name = "FieldName";
            this.FieldName.ToolTipText = "对应数据库里的字段,可以根据字段标签自动转换而来,默认以x_开始,表明是自定义字段";
            // 
            // FieldType
            // 
            this.FieldType.FillWeight = 29.06375F;
            this.FieldType.HeaderText = "字段类型";
            this.FieldType.Items.AddRange(new object[] {
            "binary",
            "boolean",
            "char",
            "date",
            "datetime",
            "float",
            "html",
            "integer",
            "many2many",
            "many2one",
            "one2many",
            "reference",
            "selection",
            "serialize",
            "text"});
            this.FieldType.Name = "FieldType";
            this.FieldType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FieldType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Required
            // 
            this.Required.FillWeight = 29.06375F;
            this.Required.HeaderText = "必填";
            this.Required.Name = "Required";
            this.Required.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Required.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Required.ToolTipText = "勾选表示该字段为必填项。";
            // 
            // TView
            // 
            this.TView.FalseValue = "";
            this.TView.FillWeight = 32F;
            this.TView.HeaderText = "TreeView可见";
            this.TView.Name = "TView";
            this.TView.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TView.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TView.ToolTipText = "默认为可见";
            this.TView.TrueValue = "";
            // 
            // FView
            // 
            this.FView.FillWeight = 30F;
            this.FView.HeaderText = "FormView可见";
            this.FView.Name = "FView";
            this.FView.ToolTipText = "默认为可见";
            this.FView.TrueValue = "1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1001, 575);
            this.Controls.Add(this.rb1);
            this.Controls.Add(this.rb2);
            this.Controls.Add(this.tbWebsite);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbPmenuID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbMdescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbPreX);
            this.Controls.Add(this.tbMdepends);
            this.Controls.Add(this.tbAuthor);
            this.Controls.Add(this.tbTable);
            this.Controls.Add(this.tbMname);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OOBD-模块生成器";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbMname;
        private System.Windows.Forms.TextBox tbTable;
        private System.Windows.Forms.TextBox tbAuthor;
        private System.Windows.Forms.TextBox tbMdepends;
        private System.Windows.Forms.CheckBox cbPreX;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbMdescription;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox tbPmenuID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbWebsite;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldName;
        private System.Windows.Forms.DataGridViewComboBoxColumn FieldType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Required;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn FView;
    }
}

