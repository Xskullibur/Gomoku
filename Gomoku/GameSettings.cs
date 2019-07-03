using System;
using System.Windows.Forms;

namespace Gomoku
{

    public enum DIFFICULTY
    {
        EASY, NORMAL, HARD
    }

    public partial class GameSettings : Form
    {

        public GameSettings refGameSettings { get; set; }

        DIFFICULTY cDifficulty = new DIFFICULTY();
        Users currentUser = new Users();


        // Constructors
        public GameSettings()
        {
            InitializeComponent();
            Scoreboard scoreboard = new Scoreboard(currentUser);
        }

        public GameSettings(Users user)
        {
            InitializeComponent();
            Scoreboard scoreboard = new Scoreboard(currentUser);
            currentUser = user;
        }

        private void GameSettings_Load(object sender, EventArgs e)
        {
            difficultyCombo.DataSource = Enum.GetValues(typeof(DIFFICULTY));
            nameLbl.Text = currentUser.playerName;
        }

        private void difficultyCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cDifficulty = (DIFFICULTY)difficultyCombo.SelectedValue;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(cDifficulty, currentUser);
            this.Hide();
            form1.ShowDialog();
            this.Close();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void scoreBtn_Click(object sender, EventArgs e)
        {
            HighscoreForm highscoreForm = new HighscoreForm(currentUser);
            highscoreForm.Show();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(currentUser);
            loginForm.ShowDialog();
            nameLbl.Text = currentUser.playerName;
        }
    }
}
