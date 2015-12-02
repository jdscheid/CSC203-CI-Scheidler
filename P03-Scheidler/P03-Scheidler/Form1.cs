using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P03_Scheidler
{
    public partial class Form1 : Form
    {
        private char[,] board = new char[3, 3]; //3x3 array for the board
        private int count;  //spare varible for filling board
        private int play;      //the nth play made each game
        private char player;   //Player 1 = 'X',  Player 2 = 'O' 
        private int gameover;  //0 if the game is still going, 1 if someone won, -1 if it's a tie
        

        public Form1()
        {
            InitializeComponent();
        }


        /***** Main Buttons *****/

        //Play
        private void btnPlay_Click(object sender, EventArgs e)  //Clear the board and start a new game
        {
            //set board to values 0-8
            count = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = (char)count;
                    count++;
                }

            //call the "Reset" function
            ResetGame(ref play);
        }

        //Clear
        private void btnClear_Click(object sender, EventArgs e) //Clear the board and reset the game
        {
            //set board to values 0-8
            count = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = (char)count;
                    count++;
                }

            //call the "Reset" function
            ResetGame(ref play);
        }

        //Exit
        private void btnExit_Click(object sender, EventArgs e)  //Exit the program
        {
            this.Close();
        }



        /***** Secondary Buttons *****/

        /*
         * Each of these buttons will do the same process:
         * 1. Increment play and Determine the player
         * 2. Hide the button and display the symbol of player in its stead
         * 3. Store the play in the appropriate index of board
         * 4. Determine if the game is over (If there is a winner or if the move limit is reached)
         * 5. If the game is over display winner and disable further play
         * 
         * The first button has further descriptions of the processes
        */

        private void btnTopLeft_Click(object sender, EventArgs e)
        {
            //increment play
            play++;

            //determines which player made the move
            player = WhichPlayer(play);

            btnTopLeft.Visible = false; //hide the button

            //determines which image to display in the picture box
            pbTopLeft.Image = ChooseImage(player);

            //store the player value in board
            board[0, 0] = player;

            //checks if the game is over
            gameover = IsOver(board, play);

            //ends the game
            if (!(gameover == 0))
                EndGame(gameover, player);
        }

        private void btnTopMid_Click(object sender, EventArgs e)
        {
           
            play++;
            player = WhichPlayer(play);
            btnTopMid.Visible = false; 
            pbTopMid.Image = ChooseImage(player);
            board[0, 1] = player;
            gameover = IsOver(board, play);
            if (!(gameover == 0))
                EndGame(gameover, player);
        }

        private void btnTopRight_Click(object sender, EventArgs e)
        {
            play++;
            player = WhichPlayer(play);
            btnTopRight.Visible = false;
            pbTopRight.Image = ChooseImage(player);
            board[0, 2] = player;
            gameover = IsOver(board, play);
            if (!(gameover == 0))
                EndGame(gameover, player);

        }

        private void btnMidLeft_Click(object sender, EventArgs e)
        {
            play++;
            player = WhichPlayer(play);
            btnMidLeft.Visible = false;
            pbMidLeft.Image = ChooseImage(player);
            board[1, 0] = player;
            gameover = IsOver(board, play);
            if (!(gameover == 0))
                EndGame(gameover, player);
        }

        private void btnMidMid_Click(object sender, EventArgs e)
        {
            play++;
            player = WhichPlayer(play);
            btnMidMid.Visible = false;
            pbMidMid.Image = ChooseImage(player);
            board[1, 1] = player;
            gameover = IsOver(board, play);
            if (!(gameover == 0))
                EndGame(gameover, player);
        }

        private void btnMidRight_Click(object sender, EventArgs e)
        {
            play++;
            player = WhichPlayer(play);
            btnMidRight.Visible = false;
            pbMidRight.Image = ChooseImage(player);
            board[1, 2] = player;
            gameover = IsOver(board, play);
            if (!(gameover == 0))
                EndGame(gameover, player);
        }

        private void btnBotLeft_Click(object sender, EventArgs e)
        {
            play++;
            player = WhichPlayer(play);
            btnBotLeft.Visible = false;
            pbBotLeft.Image = ChooseImage(player);
            board[2, 0] = player;
            gameover = IsOver(board, play);
            if (!(gameover == 0))
                EndGame(gameover, player);
        }

        private void btnBotMid_Click(object sender, EventArgs e)
        {
            play++;
            player = WhichPlayer(play);
            btnBotMid.Visible = false;
            pbBotMid.Image = ChooseImage(player);
            board[2, 1] = player;
            gameover = IsOver(board, play);
            if (!(gameover == 0))
                EndGame(gameover, player);
        }

        private void btnBotRight_Click(object sender, EventArgs e)
        {
            play++;
            player = WhichPlayer(play);
            btnBotRight.Visible = false;
            pbBotRight.Image = ChooseImage(player);
            board[2, 2] = player;
            gameover = IsOver(board, play);
            if (!(gameover == 0))
                EndGame(gameover, player);
        }

        
        
        /***** Functions *****/

        //"Reset" function to reset play, start the game over, turn the buttons on, and clear the picture boxes
        private void ResetGame(ref int play)
        {

            //Reset the Play
            play = 0;

            //Start the game over
            gameover = 0;

            //Turn all of the buttons on
            btnTopLeft.Visible = true;
            btnTopMid.Visible = true;
            btnTopRight.Visible = true;
            btnMidLeft.Visible = true;
            btnMidMid.Visible = true;
            btnMidRight.Visible = true;
            btnBotLeft.Visible = true;
            btnBotMid.Visible = true;
            btnBotRight.Visible = true;

            //Enable all the buttons
            btnTopLeft.Enabled = true;
            btnTopMid.Enabled = true;
            btnTopRight.Enabled = true;
            btnMidLeft.Enabled = true;
            btnMidMid.Enabled = true;
            btnMidRight.Enabled = true;
            btnBotLeft.Enabled = true;
            btnBotMid.Enabled = true;
            btnBotRight.Enabled = true;


            //Clear all of the Picture Boxes
            pbTopLeft.Image = null;
            pbTopMid.Image = null;
            pbTopRight.Image = null;
            pbMidLeft.Image = null;
            pbMidMid.Image = null;
            pbMidRight.Image = null;
            pbBotLeft.Image = null;
            pbBotMid.Image = null;
            pbBotRight.Image = null;

        }
       
        //Determines which player made the move
        private char WhichPlayer(int play)
        {
            if (play % 2 == 1)
                return 'X';
            else
                return 'O';
        }

        //Find the appropriate file for the picture box
        private Image ChooseImage(char player)
        {
            Image image1 = Image.FromFile(".../.../.../x.jpg"); //variable to hold the picture of 'X'
            Image image2 = Image.FromFile(".../.../.../o.jpg"); //variable to hold the picture of 'O'

            //return image based on the player
            if (player == 'X')
                return (Image)image1.Clone();
            else
                return (Image)image2.Clone();
        }

        //Checks to see if the game is over
        private int IsOver(char[,] board, int play)
        {
            //check for a win
            for (int i = 0; i < 3; i++)
            {
                if (board[i,0] == board[i,1] && board[i,1] == board[i,2])   //Win horizontally
                    return 1;
                else if (board[0,i] == board[1,i] && board[1,i] == board[2,i])  //Win vertially
                    return 1;
            }

            //check for diagonal win
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                return 1;
            else if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                return 1;


            if (play >= 9)  //If the move limit is up return -1
                return -1;


            return 0;   // if none of the previous checks are true the function will return a 0 to continue the game
        }

        //display who won and end further play
        private void EndGame(int gameover, char player)
        {
            if (gameover == 1)
                MessageBox.Show(player + "'s win");
            else
                MessageBox.Show("The game is a tie");

            //Disable further play
            btnTopLeft.Enabled = false;
            btnTopMid.Enabled = false;
            btnTopRight.Enabled = false;
            btnMidLeft.Enabled = false;
            btnMidMid.Enabled = false;
            btnMidRight.Enabled = false;
            btnBotLeft.Enabled = false;
            btnBotMid.Enabled = false;
            btnBotRight.Enabled = false;

        }
    }
}
