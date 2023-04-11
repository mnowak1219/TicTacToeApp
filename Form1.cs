using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TicTacToeApp
{
    public partial class baseWindow : Form
    {
        public baseWindow()
        {
            InitializeComponent();
        }

        bool playersTurn = true;
        string winner = "";
        bool[] isButtonDisabled = new bool[9] { false, false, false, false, false, false, false, false, false };
        private void btnRestartGame_Click(object sender, EventArgs e)
        {
            Restart();
            lblResultO.Text = "0";
            lblResultX.Text = "0";
            lblPlayer.Text = "O";
            lblPlayer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            playersTurn = true;
        }

        private void Restart()
        {
            lblMoveNumber.Text = "0";
            for (int i = 0; i < isButtonDisabled.Length; i++)
            {
                isButtonDisabled[i] = false;
            }
            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";
            btn9.Text = "";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (isButtonDisabled[0] == false)
            {
                isButtonDisabled[0] = true;
                ButtonHandle(sender);
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (isButtonDisabled[1] == false)
            {
                isButtonDisabled[1] = true;
                ButtonHandle(sender);
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (isButtonDisabled[2] == false)
            {
                isButtonDisabled[2] = true;
                ButtonHandle(sender);
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (isButtonDisabled[3] == false)
            {
                isButtonDisabled[3] = true;
                ButtonHandle(sender);
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (isButtonDisabled[4] == false)
            {
                isButtonDisabled[4] = true;
                ButtonHandle(sender);
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (isButtonDisabled[5] == false)
            {
                isButtonDisabled[5] = true;
                ButtonHandle(sender);
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (isButtonDisabled[6] == false)
            {
                isButtonDisabled[6] = true;
                ButtonHandle(sender);
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (isButtonDisabled[7] == false)
            {
                isButtonDisabled[7] = true;
                ButtonHandle(sender);
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (isButtonDisabled[8] == false)
            {
                isButtonDisabled[8] = true;
                ButtonHandle(sender);
            }
        }

        private void ButtonHandle(object sender)
        {
            //((Button)sender).Enabled = false;
            lblMoveNumber.Text = (int.Parse(lblMoveNumber.Text) + 1).ToString();
            ((Button)sender).Text = playersTurn ? "O" : "X";
            ((Button)sender).ForeColor = (((Button)sender).Text == "O" ? System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192))))) : System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))));
            if (int.Parse(lblMoveNumber.Text) >= 5)
            {
                CheckWin();
            }
            playersTurn = !playersTurn;
            lblPlayer.Text = playersTurn ? "O" : "X";
            lblPlayer.ForeColor = playersTurn ? System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192))))) : System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))); ;

        }

        private void CheckWin()
        {
            if ((btn1.Text != "" && btn1.Text == btn2.Text && btn1.Text == btn3.Text) ||
                (btn4.Text != "" && btn4.Text == btn5.Text && btn4.Text == btn6.Text) ||
                (btn7.Text != "" && btn7.Text == btn8.Text && btn7.Text == btn9.Text) ||
                (btn1.Text != "" && btn1.Text == btn4.Text && btn1.Text == btn7.Text) ||
                (btn2.Text != "" && btn2.Text == btn5.Text && btn2.Text == btn8.Text) ||
                (btn3.Text != "" && btn3.Text == btn6.Text && btn3.Text == btn9.Text) ||
                (btn1.Text != "" && btn1.Text == btn5.Text && btn1.Text == btn9.Text) ||
                (btn3.Text != "" && btn3.Text == btn5.Text && btn3.Text == btn7.Text))
            {
                Win();
            }
            else if (lblMoveNumber.Text == "9")
            {
                Draw();
            }
        }

        private void Draw()
        {
            MessageBox.Show("It was a fierce fight!\nNobody gets a point!", "Draw!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Restart();
        }

        private void Win()
        {
            winner = playersTurn ? "O" : "X";
            MessageBox.Show($"Congratulation!\nThe point goes to the {winner} player!", "We have the winner!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateResult(winner);
            if (int.Parse(lblMoveNumber.Text) % 2 == 0)
            {
                playersTurn = !playersTurn;
            }
            Restart();
        }

        private void UpdateResult(string winner)
        {
            if (winner == "O")
            {
                lblResultO.Text = (int.Parse(lblResultO.Text) + 1).ToString();

            }
            else
            {
                lblResultX.Text = (int.Parse(lblResultX.Text) + 1).ToString();
            }
        }

        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.Title = "Save game";

            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(btn1.Text);
                    writer.WriteLine(btn2.Text);
                    writer.WriteLine(btn3.Text);
                    writer.WriteLine(btn4.Text);
                    writer.WriteLine(btn5.Text);
                    writer.WriteLine(btn6.Text);
                    writer.WriteLine(btn7.Text);
                    writer.WriteLine(btn8.Text);
                    writer.WriteLine(btn9.Text);
                    writer.WriteLine(string.Join(",", isButtonDisabled));
                    writer.WriteLine(lblResultO.Text);
                    writer.WriteLine(lblResultX.Text);
                    writer.WriteLine(lblPlayer.Text);
                    writer.WriteLine(lblPlayer.ForeColor.ToArgb());
                    writer.WriteLine(playersTurn);
                    writer.WriteLine(lblMoveNumber.Text);                        
                    writer.Close();
                }
                MessageBox.Show("Game saved succesfully!");
            }
        }

        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            ColorConverter colorConverter = new ColorConverter();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Title = "Load game"; 
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName; 
                using (StreamReader reader = new StreamReader(filePath))
                {
                    btn1.Text = reader.ReadLine();
                    UpdateColor(btn1);
                    btn2.Text = reader.ReadLine();
                    UpdateColor(btn2);
                    btn3.Text = reader.ReadLine();
                    UpdateColor(btn3);
                    btn4.Text = reader.ReadLine();
                    UpdateColor(btn4);
                    btn5.Text = reader.ReadLine();
                    UpdateColor(btn5);
                    btn6.Text = reader.ReadLine();
                    UpdateColor(btn6);
                    btn7.Text = reader.ReadLine();
                    UpdateColor(btn7);
                    btn8.Text = reader.ReadLine();
                    UpdateColor(btn8);
                    btn9.Text = reader.ReadLine();
                    UpdateColor(btn9);
                    isButtonDisabled = Array.ConvertAll(reader.ReadLine().Split(','), bool.Parse);
                    lblResultO.Text = reader.ReadLine();
                    lblResultX.Text = reader.ReadLine();
                    lblPlayer.Text = reader.ReadLine();
                    lblPlayer.ForeColor = Color.FromArgb(Convert.ToInt32(reader.ReadLine()));
                    playersTurn = Convert.ToBoolean(reader.ReadLine());
                    lblMoveNumber.Text = reader.ReadLine();
                    reader.Close();
                }
                MessageBox.Show("Game loaded succesfully!");
            }
        }

        private void UpdateColor(Button btn)
        {
            btn.ForeColor = btn.Text == "O" ? System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192))))) : System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        }
    }
}
