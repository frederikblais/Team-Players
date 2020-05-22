using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Team_Payers_LAB10
{
    public partial class Form1 : Form
    {
        // Create a new list for teams
        private List<Team> Teams = new List<Team>();
        private List<Player> Players = new List<Player>();

        public Form1()
        {
            InitializeComponent();
        }
        private void ReadFile()
        {
            try
            {
                StreamReader inputFile; // Read The file
                string line;

                // Create a instance of teams
                Team currentTeam = new Team();
                Player player = new Player();

                // Create delimiter array
                char[] delim = { ',' };

                // Open CSV to specified path
                inputFile = File.OpenText( "teams_payers.csv" );

                // Read Lines
                while(!inputFile.EndOfStream)
                {
                    // Read lines inputFile
                    line = inputFile.ReadLine();

                    // Tokenize
                    string[] tokens = line.Split(delim);

                    if (tokens[0] == "Team")
                    {
                        currentTeam = new Team();
                        currentTeam.Name = tokens[1];
                        currentTeam.Code = tokens[2];
                        currentTeam.Founded = tokens[3];

                        Players = new List<Player>();

                        Teams.Add(currentTeam);

                        teamsListBox.Items.Add(currentTeam.Name);
                    }
                    else if(tokens[0] == "EndTeam")
                    {
                        currentTeam.Players = Players;
                    }
                    else
                    {
                        player = new Player();
                        player.FullName = tokens[0];
                        player.Pos = tokens[1];
                        player.Gp = int.Parse(tokens[2]);
                        player.G = int.Parse(tokens[3]);
                        player.A = int.Parse(tokens[4]);
                        player.Sog = int.Parse(tokens[5]);

                        Players.Add(player);
                    }
                }
            }
            catch (Exception ex)
            {
                // Display error message
                MessageBox.Show(ex.Message);
            }
        }

        int selectedTeam;
        private void teamsListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            selectedTeam = teamsListBox.SelectedIndex;

            // Clear Player ListBox, PlayerInfolabels
            playersListBox.Items.Clear();
            positionLabel.Text = "";
            goalsLabel.Text = "";
            gameLabel.Text = "";
            assistsLabel.Text = "";
            shotLabel.Text = "";

            // Display the code
            codeLabel.Text = Teams[teamsListBox.SelectedIndex].Code;

            // Display the Foundation
            foundedLabel.Text = Teams[teamsListBox.SelectedIndex].Founded;

            // Display players
            for (int i = 0; i < Teams[teamsListBox.SelectedIndex].Players.Count ; i++)
            {
                playersListBox.Items.Add(Teams[teamsListBox.SelectedIndex].Players[i].FullName); 
            }
        }

        int selectedPlayer;
        private void playersListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            selectedPlayer = playersListBox.SelectedIndex;

            // Display pos
            positionLabel.Text = Players[playersListBox.SelectedIndex].Pos;

            // Display GP
            gameLabel.Text = Players[playersListBox.SelectedIndex].Gp.ToString();

            // Display G
            goalsLabel.Text = Players[playersListBox.SelectedIndex].G.ToString();

            // Display A
            assistsLabel.Text = Players[playersListBox.SelectedIndex].A.ToString();

            // Display Sog
            shotLabel.Text = Players[playersListBox.SelectedIndex].Sog.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadFile();
        }
    }
}
