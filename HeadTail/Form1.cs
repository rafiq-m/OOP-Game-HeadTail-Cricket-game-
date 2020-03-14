using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeadTail
{
    public partial class Form1 : Form
    {
        public static bool batt = true;
        Teams t;
        public Form1()
        {
            InitializeComponent();
            Overs.DropDownStyle = ComboBoxStyle.DropDownList;
            Players.DropDownStyle = ComboBoxStyle.DropDownList;
            for (int i = 2; i < 11; i += 2)
            {
                Overs.Items.Add(i);
            }
            for (int i = 2; i <= 5; i++)
            {
                Players.Items.Add(i);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Start_Click(object sender, EventArgs e)
        {
            t = new Teams();
            t.addTextBox(new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10 }, new Label[] { label3, label4 }, Players.SelectedItem.ToString());
            t.getOVers(Overs.SelectedItem.ToString());
        }

        private void Play_Click(object sender, EventArgs e)
        {
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Toss_Click(object sender, EventArgs e)
        {
            t.playersButtonGet(new Button[] { player1, player2, player3, player4, player5 });
            t.playing(new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10 }, Players.SelectedItem.ToString());
            t.toss(toss);
            foreach (Control c in this.Controls)
            {
                c.Visible = false;
            }
            if (Form1.batt)
            {
                hi1.Text = "Start " + "Team A's Batting";
                hi1.Visible = true;
            }
            else
            {
                
                hi1.Text = "Start" + "Team B's Batting";
            }
            t.gethi1(hi1);
            flowLayoutPanel1.Visible = true;
            flowLayoutPanel2.Visible = true;
            info.Visible = true;
            hi1.Visible = true;
        }

        private void Hi_Click(object sender, EventArgs e)
        {
            hi1.Text = "Start " + info.Text;
            allRuns.Visible = true;
            t.information(info);
            t.addButtons(flowLayoutPanel1);
            flowLayoutPanel2.Controls.Clear();
            t.displayNames(flowLayoutPanel2, Players.SelectedItem.ToString());  
            t.playersRun(new Button[] { player1, player2, player3, player4, player5 });
            t.allRunButton(allRuns);           
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

    }
}
