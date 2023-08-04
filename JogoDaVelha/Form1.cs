using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDaVelha
{
    public partial class Form1 : Form
    {
        private char[,] board = new char[3, 3];
        private char currentPlayer = 'X';

        public Form1()
        {
            InitializeComponent();
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = ' ';
                }
            }
            // Percorre todos os botões e redefine o texto para vazio
            foreach (Control control in Controls)
            {
                if (control is Button button)
                {
                    button.Text = "";
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int row = int.Parse(clickedButton.Name[6].ToString());
            int col = int.Parse(clickedButton.Name[7].ToString());

            if (board[row, col] == ' ')
            {
                board[row, col] = currentPlayer;
                clickedButton.Text = currentPlayer.ToString();

                if (CheckWinner(currentPlayer))
                {
                    MessageBox.Show($"O jogador {currentPlayer} venceu!");
                    InitializeBoard();

                }
                else if (IsBoardFull())
                {
                    MessageBox.Show("Empate! O jogo terminou sem vencedor.");
                    InitializeBoard();
                }
                else
                {
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                }
            }
        }


        private bool CheckWinner(char player)
        {
            // Lógica para verificar se há um vencedor (linhas, colunas, diagonais)
            // Verificação de linhas
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] == player && board[row, 1] == player && board[row, 2] == player)
                {
                    return true; // Jogador venceu na linha 'row'
                }
            }

            // Verificação de colunas
            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] == player && board[1, col] == player && board[2, col] == player)
                {
                    return true; // Jogador venceu na coluna 'col'
                }
            }

            // Verificação de diagonais
            if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
            {
                return true; // Jogador venceu na diagonal principal
            }
            if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
            {
                return true; // Jogador venceu na diagonal secundária
            }

            return false; // Nenhum jogador venceu
        }

        private bool IsBoardFull()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == ' ')
                    {
                        return false; // Ainda há espaços vazios
                    }
                }
            }
            return true; // Todos os campos estão preenchidos
        }

    }
}
