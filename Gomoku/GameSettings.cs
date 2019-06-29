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

        public GameSettings()
        {
            InitializeComponent();
        }

        private void GameSettings_Load(object sender, EventArgs e)
        {
            difficultyCombo.DataSource = Enum.GetValues(typeof(DIFFICULTY));
        }

        private void difficultyCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cDifficulty = (DIFFICULTY)difficultyCombo.SelectedValue;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(cDifficulty);
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
    }
}
