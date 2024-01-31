#include <iostream>
#include <vector>

using namespace std;

const int N = 8;
const int moveX[8] = {1, 2, 2, 1, -1, -2, -2, -1};
const int moveY[8] = {-2, -1, 1, 2, 2, 1, -1, -2};

void printBoard(const vector<vector<int>>& board) 
{
    for (int i = 0; i < N; ++i) 
    {
        for (int j = 0; j < N; ++j) 
            cout << board[i][j] << " ";
        cout << endl;
    }
}

bool isValidMove(int x, int y, const vector<vector<int>>& board) 
{
    return (x >= 0 && x < N && y >= 0 && y < N && board[x][y] == -1);
}

bool solveKnightTour(int x, int y, int move, vector<vector<int>>& board) 
{
    if (move == N * N) return true;

    for (int i = 0; i < 8; ++i) 
    {
        int nextX = x + moveX[i];
        int nextY = y + moveY[i];

        if (isValidMove(nextX, nextY, board)) 
        {
            board[nextX][nextY] = move;
            if (solveKnightTour(nextX, nextY, move + 1, board))
                return true;
            else 
                board[nextX][nextY] = -1;
        }
    }

    return false;
}

int main() 
{
    vector<vector<int>> board(N, vector<int>(N, -1));
    int startX = 0;
    int startY = 0;

    board[startX][startY] = 0;
    if (solveKnightTour(startX, startY, 1, board)) 
    {
        cout << "Solução encontrada:" << endl;
        printBoard(board);
    } 
    else 
    {
        cout << "Nenhuma solução encontrada." << endl;
    }

    return 0;
}