using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HeadTail
{
    class Teams
    {
        List<TeamA> teama = new List<TeamA>();
        Button[] buttons;
        List<TeamB> teamb = new List<TeamB>();
        Button hi1;
        int playersCount= 0;
        int pro;
        int wicket = 0;
        static int ballCount= 0;
        int balls = 0;
        int AllRuns;
        int team1Runs;
        int match = 0;
        String team1;
        Label info;
        FlowLayoutPanel flow = new FlowLayoutPanel();
        Button allRuns;
        public void addTextBox(TextBox[] textBoxes, Label[] labels, String selectedValue)
        {
            labels[0].Visible = true;
            labels[1].Visible = true;
            for (int i = 0; i < Convert.ToInt32(selectedValue) * 2; i++)
            {
                textBoxes[i].Visible = true;

            }
            playersCount = Convert.ToInt32(selectedValue);
        }
        public void playing(TextBox[] textBoxes, String selectedValue)
        {
            for (int i = 0; i < Convert.ToInt32(selectedValue) * 2; i++)
            {
                if (i % 2 == 0)
                {
                    teama.Add(new TeamA(textBoxes[i].Text));
                }
                else
                {
                    teamb.Add(new TeamB(textBoxes[i].Text));
                }
            }
        }
        public void getOVers(String overs)
        {
            ballCount = Convert.ToInt32(overs) * 6;
        }    
        public void toss(Button button)
        {
            Random random = new Random();
            int x = random.Next();
            if (x % 2 == 0)
            {
                button.Text = " Team A will bat";
                Form1.batt = true;
            }
            else
            {
                button.Text = "Team B will bat";
                Form1.batt = false;
            }
            for (int i = 0; i < playersCount; i++)
            {
                this.buttons[i].Text = null;
            }
        }
        public void addButtons(FlowLayoutPanel flowLayoutPanel)
        {
            for (int i = 1; i < 7; i++)
            {
                var button = addButton(i);
                flowLayoutPanel.Controls.Add(button);
                button.Click += new EventHandler(this.buttonClick);
            }
            flow = flowLayoutPanel;
        }
        public void buttonClick(object sender, EventArgs e)
        {
            if (match == 2)
            {
                if (AllRuns > team1Runs)
                {
                    MessageBox.Show(team1 + " Wins " + "with " + pro + " Runs");
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show(team1 + " didnot win" + " and required " + pro + " Runs");
                    Application.Exit();
                }
            }
            else
            {
                if (playersCount == wicket)
                {
                    MessageBox.Show("All out");
                    allRuns.Text = AllRuns.ToString() + "/" + wicket;
                    if (Form1.batt)
                    {
                        Form1.batt = false;
                        hi1.Text = "Start " + " Team B's Batting";
                        flow.Controls.Clear();
                    }
                    else
                    {
                        Form1.batt = true;
                        hi1.Text = "Start " + " Team A's Batting";
                        flow.Controls.Clear();
                    }
                    match++;
                    if(match == 2)
                    {
                        pro = Math.Abs(AllRuns - team1Runs);
                        hi1.Visible = false;
                        buttonClick(null, EventArgs.Empty);
                    }
                    wicket = 0;
                    team1Runs = AllRuns;
                    AllRuns = 0;
                    balls = 0;
                    for (int i = 0 ; i < playersCount ; i++)
                    {
                        buttons[i].Text = "";
                    }
                }
                else
                {
                    if (ballCount == balls)
                    {
                        MessageBox.Show("OVERS COMPLETED");
                        if (Form1.batt)
                        {
                            Form1.batt = false;
                            hi1.Text = "Start " + " Team B's Batting";
                            flow.Controls.Clear();
                        }
                        else
                        {
                            Form1.batt = true;
                            hi1.Text = "Start " + " Team A's Batting";
                            flow.Controls.Clear();
                        }
                        match++;
                        if (match == 2) { pro = Math.Abs(AllRuns - team1Runs); hi1.Visible = false; buttonClick(null, EventArgs.Empty); }
                        wicket = 0;
                        team1Runs = AllRuns;
                        AllRuns = 0;                      
                        balls = 0;
                        for (int i = 0; i < playersCount; i++)
                        {
                            buttons[i].Text = "";
                        }
                    }
                    else
                    {
                        Button currentButton = (Button)sender;
                        if (Convert.ToInt32(currentButton.Text) == randomGenerator())
                        {
                            wicket++;
                            MessageBox.Show("Player Number: " + (wicket) + " is OUT !!");
                            allRuns.Text = AllRuns.ToString() + "/" + wicket;
                        }
                        else
                        {
                            if (Form1.batt)
                            {
                                teama.ElementAt(wicket).runs = teama.ElementAt(wicket).runs + Convert.ToInt32(currentButton.Text);
                                this.buttons[wicket].Text = teama.ElementAt(wicket).runs.ToString();
                                AllRuns += Convert.ToInt32(currentButton.Text);
                                allRuns.Text = AllRuns.ToString() + "/" + wicket;
                                balls++;
                                if(match == 0) { team1 = "Team A"; }
                            }
                            else
                            {
                                teamb.ElementAt(wicket).runs = teamb.ElementAt(wicket).runs + Convert.ToInt32(currentButton.Text);
                                this.buttons[wicket].Text = teamb.ElementAt(wicket).runs.ToString();
                                AllRuns += Convert.ToInt32(currentButton.Text);
                                allRuns.Text = AllRuns.ToString() + "/" + wicket;
                                if (match == 0) { team1 = "Team B"; }
                                balls++;
                            }
                        }
                    }
                }
            }
        }
        public void allRunButton(Button buttons)
        {
            this.allRuns = buttons;
        }
        public Button addButton(int i)
        {
            var button = new Button();
            button.BackColor = Color.LightBlue;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.DarkBlue;
            button.FlatAppearance.BorderSize = 2;
            button.Font = new Font(button.Font, FontStyle.Bold);
            button.Name = "button" + i.ToString();
            button.Text = (i).ToString();
            button.Height = 80;
            button.Width = 74;
            return button;
        }
        public void displayNames(FlowLayoutPanel flowLayoutPanel, String selectedValue)
        {
            for (int i = 0; i < Convert.ToInt32(selectedValue); i++)
            {
                var textBox = addTextBox(i);
                flowLayoutPanel.Controls.Add(textBox);
            }
        }
        public TextBox addTextBox(int i)
        {
            if (Form1.batt)
            {
                var textBox = new TextBox();
                textBox.Name = teama.ElementAt(i).getName().ToString();
                textBox.Text = teama.ElementAt(i).getName().ToString();
                textBox.Height = 80;
                textBox.Width = 74;
                return textBox;
            }
            else
            {
                var textBox = new TextBox();
                textBox.Name = teamb.ElementAt(i).getName().ToString();
                textBox.Text = teamb.ElementAt(i).getName().ToString();
                textBox.Height = 80;
                textBox.Width = 74;
                return textBox;
            }
        }
        public void playersRun(Button[] buttons)
        {
            for(int i =0; i < playersCount;i++)
            {
                buttons[i].Visible = true;
            }

        }
        public void information(Label label)
        {
            info = label;
            if (Form1.batt)
            {
                label.Text = "Team A's batting.";
                
            }
            else
            {
                label.Text = "Team B's Batting.";
            }
        }
        public int randomGenerator()
        {
            Random random = new Random();
            int x = random.Next(1, 10);
            return x;
        }
        public void gethi1(Button button)
        {
            hi1 = new Button();
            hi1 = button;
        }
        public void playersButtonGet(Button[] button)
        {
            this.buttons = new Button[5];
            this.buttons = button;
        }
    }
}
