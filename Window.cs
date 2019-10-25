 
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using W2___Strdef_Editor.Funções;

namespace W2___Strdef_Editor
{
    public class Window : Form
    {
        private IContainer components = (IContainer)null;
        private GroupBox groupBox1;
        private Button Salvar;
        private Button Carregar;
        private ListBox StrList;
        private Button button1;
        private LinkLabel linkLabel1;
        private Label label21;
        private TextBox strDefText;
        private Label label2;
        private Label label1;
        private Label strIndex;
        private TextBox search;
        private Label label3;
        private Button button2;
        private TextBox replace;
        private Label label4;

        public Window()
        {
            this.InitializeComponent();
            this.StrList.Items.Clear();
            this.linkLabel1.Links.Add(new LinkLabel.Link()
            {
                LinkData = (object)"http://www.webcheats.com.br/members/seitbnao.4781487/"
            });
        }

        public void _Update()
        {
            this.StrList.Items.Clear();
            //if (!Functions.ReadStrdef())
            //    return;
            for (int index = 0; index < 2000; ++index)
                this.StrList.Items.Add((object)("(" + (object)index + ") " + External.g_pStrdef.Strdef[index].Value.Replace('_', ' ')));
        }

        private void Carregar_Click(object sender, EventArgs e)
        {
            this.StrList.Items.Clear();
            if (!Functions.ReadStrdef())
                return;
            for (int index = 0; index < 2000; ++index)
                this.StrList.Items.Add((object)("(" + (object)index + ") " + External.g_pStrdef.Strdef[index].Value.Replace('_', ' ')));
        }

        private void Salvar_Click(object sender, EventArgs e)
        {
            if (this.StrList.Items.Count <= 1 || External.Index == -1)
                return;
            this.GetValue();
            for (int index = 0; index < 2000; ++index)
                External.g_pStrdef.Strdef[index].Value.Replace(' ', '_');
            Functions.SaveFile<Structs.STRUCT_STRDEF>(External.g_pStrdef);
            this._Update();
            int num = (int)MessageBox.Show("Strdef.bin salvo com sucesso", "W2 - Strdef Editor", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }

        private void SkillList_SelectedIndexChanged(object sender, EventArgs e)
        {
            External.Index = this.StrList.SelectedIndex;
            this.strIndex.Text = External.Index.ToString();
            if (External.Index == -1)
                return;
            this.strDefText.Text = External.g_pStrdef.Strdef[External.Index].Value;
            this.GetValue();
        }

        public void GetValue()
        {
            int index = External.Index;
            if (index == -1)
                return;
            External.g_pStrdef.Strdef[index].Value = this.strDefText.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (External.Index == -1)
                return;
            StreamWriter streamWriter = new StreamWriter("./Strdef.csv");
            streamWriter.WriteLine("#by Seitbnao ");
            streamWriter.WriteLine("#Index,Strdef\n");
            streamWriter.WriteLine("");
            for (int index = 0; index < 2000; ++index)
                streamWriter.WriteLine(index.ToString() + "," + External.g_pStrdef.Strdef[index].Value.Replace(' ', '_'));
            streamWriter.Close();
            int num = (int)MessageBox.Show("Strdef.csv gerado com sucesso", "W2 - Strdef Editor", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (!(this.search.Text != string.Empty))
                return;
            int index = this.StrList.FindString(this.search.Text);
            if (index != -1)
                this.StrList.SetSelected(index, true);
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if (!(this.search.Text != string.Empty))
                return;
            int index = this.StrList.FindString(this.search.Text);
            if (index != -1)
                this.StrList.SetSelected(index, true);
        }

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!(this.search.Text != string.Empty))
                return;
            int index = this.StrList.FindString(this.search.Text);
            if (index != -1)
                this.StrList.SetSelected(index, true);
        }

        private void Window_MouseClick(object sender, MouseEventArgs e)
        {
            if (!(this.search.Text != string.Empty))
                return;
            int index = this.StrList.FindString(this.search.Text);
            if (index != -1)
                this.StrList.SetSelected(index, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.StrList.Items.Count < 1)
                return;
            string oldValue = this.search.Text.Replace(' ', '_').ToString();
            if (string.IsNullOrEmpty(oldValue))
                return;
            string newValue = this.replace.Text.Replace(' ', '_').ToString();
            for (int index = 0; index < 2000; ++index)
            {
                string str = External.g_pStrdef.Strdef[index].Value;
                External.g_pStrdef.Strdef[index].Value = str.Replace(oldValue, newValue);
            }
            this.GetValue();
            for (int index = 0; index < 2000; ++index)
                External.g_pStrdef.Strdef[index].Value.Replace(' ', '_');
            Functions.SaveFile<Structs.STRUCT_STRDEF>(External.g_pStrdef);
            this._Update();
            int num = (int)MessageBox.Show("Ocorrências trocadas com sucesso", "W2 - Strdef Editor", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }


        private void InitializeComponent()
        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Window));
            this.groupBox1 = new GroupBox();
            this.search = new TextBox();
            this.label3 = new Label();
            this.strIndex = new Label();
            this.strDefText = new TextBox();
            this.label2 = new Label();
            this.label1 = new Label();
            this.label21 = new Label();
            this.button1 = new Button();
            this.linkLabel1 = new LinkLabel();
            this.Salvar = new Button();
            this.Carregar = new Button();
            this.StrList = new ListBox();
            this.replace = new TextBox();
            this.label4 = new Label();
            this.button2 = new Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            this.groupBox1.Controls.Add((Control)this.button2);
            this.groupBox1.Controls.Add((Control)this.replace);
            this.groupBox1.Controls.Add((Control)this.label4);
            this.groupBox1.Controls.Add((Control)this.search);
            this.groupBox1.Controls.Add((Control)this.label3);
            this.groupBox1.Controls.Add((Control)this.strIndex);
            this.groupBox1.Controls.Add((Control)this.strDefText);
            this.groupBox1.Controls.Add((Control)this.label2);
            this.groupBox1.Controls.Add((Control)this.label1);
            this.groupBox1.Controls.Add((Control)this.label21);
            this.groupBox1.Controls.Add((Control)this.button1);
            this.groupBox1.Controls.Add((Control)this.linkLabel1);
            this.groupBox1.Controls.Add((Control)this.Salvar);
            this.groupBox1.Controls.Add((Control)this.Carregar);
            this.groupBox1.Controls.Add((Control)this.StrList);
            this.groupBox1.Location = new Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(887, 395);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "String Definitions";
            this.search.Location = new Point(143, 19);
            this.search.Name = "search";
            this.search.Size = new Size(264, 20);
            this.search.TabIndex = 39;
            this.search.Leave += new EventHandler(this.textBox1_Leave);
            this.search.MouseLeave += new EventHandler(this.textBox1_MouseLeave);
            this.search.MouseMove += new MouseEventHandler(this.textBox1_MouseMove);
            this.label3.AutoSize = true;
            this.label3.Location = new Point(96, 22);
            this.label3.Name = "label3";
            this.label3.Size = new Size(41, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Trocar:";
            this.strIndex.AutoSize = true;
            this.strIndex.Location = new Point(48, 22);
            this.strIndex.Name = "strIndex";
            this.strIndex.Size = new Size(16, 13);
            this.strIndex.TabIndex = 37;
            this.strIndex.Text = "-1";
            this.strDefText.Location = new Point(50, 48);
            this.strDefText.MaxLength = 128;
            this.strDefText.Name = "strDefText";
            this.strDefText.Size = new Size(731, 20);
            this.strDefText.TabIndex = 36;
            this.strDefText.Text = "Selecione...";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new Size(36, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Index:";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(6, 51);
            this.label1.Name = "label1";
            this.label1.Size = new Size(38, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Strdef:";
            this.label21.AutoSize = true;
            this.label21.Location = new Point(395, 373);
            this.label21.Name = "label21";
            this.label21.Size = new Size(94, 13);
            this.label21.TabIndex = 3;
            this.label21.Text = "Versão: 20180804";
            this.button1.Location = new Point(678, 363);
            this.button1.Name = "button1";
            this.button1.Size = new Size(94, 23);
            this.button1.TabIndex = 33;
            this.button1.Text = "Gerar CSV";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new Point(371, 360);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new Size(149, 13);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Copyright @ 2018 - SeiTbNao";
            this.linkLabel1.TextAlign = ContentAlignment.TopCenter;
            this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            this.Salvar.Location = new Point(787, 46);
            this.Salvar.Name = "Salvar";
            this.Salvar.Size = new Size(94, 23);
            this.Salvar.TabIndex = 2;
            this.Salvar.Text = "Salvar";
            this.Salvar.UseVisualStyleBackColor = true;
            this.Salvar.Click += new EventHandler(this.Salvar_Click);
            this.Carregar.Location = new Point(778, 363);
            this.Carregar.Name = "Carregar";
            this.Carregar.Size = new Size(94, 23);
            this.Carregar.TabIndex = 1;
            this.Carregar.Text = "Recarregar";
            this.Carregar.UseVisualStyleBackColor = true;
            this.Carregar.Click += new EventHandler(this.Carregar_Click);
            this.StrList.FormattingEnabled = true;
            this.StrList.Location = new Point(6, 80);
            this.StrList.Name = "StrList";
            this.StrList.Size = new Size(875, 277);
            this.StrList.TabIndex = 0;
            this.StrList.SelectedIndexChanged += new EventHandler(this.SkillList_SelectedIndexChanged);
            this.replace.Location = new Point(445, 19);
            this.replace.Name = "replace";
            this.replace.Size = new Size(336, 20);
            this.replace.TabIndex = 41;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(413, 22);
            this.label4.Name = "label4";
            this.label4.Size = new Size(26, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Por:";
            this.button2.Location = new Point(787, 17);
            this.button2.Name = "button2";
            this.button2.Size = new Size(94, 23);
            this.button2.TabIndex = 42;
            this.button2.Text = "Confirma";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = Color.Silver;
            this.ClientSize = new Size(912, 415);
            this.Controls.Add((Control)this.groupBox1);
            this.ForeColor = Color.Black;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.ImeMode = ImeMode.Off;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(Window);
            this.ShowInTaskbar = false;
            this.Text = "W2 - StrDef Editor";
            this.MouseClick += new MouseEventHandler(this.Window_MouseClick);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
