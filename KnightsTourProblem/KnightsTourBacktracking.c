#include <stdio.h>
#include <time.h>

#define N 9 // Dimensão do tabuleiro.

#define INVERSE_MOVE // Utilizando apenas backtracking a ordem de escolha dos movimentos gera soluções diferentes.
#define WARNSDORFF_HEURISTIC // Habilita uso da heurística de Warnsdorf.

#define M 8 // Quantidade fixa de possíveis movimentos.

#ifndef  INVERSE_MOVE
const int xMove[M] = { 2, 1, -1, -2, -2, -1, 1, 2 };
const int yMove[M] = { 1, 2, 2, 1, -1, -2, -2, -1 };
#else
const int xMove[M] = { 2, 1, -1, -2, -2, -1, 1, 2 };
const int yMove[M] = { -1, -2, -2, -1, 1, 2, 2, 1 };
#endif 

  
int isSafe(int x, int y, int board[N][N])
{
    return (x >= 0 && x < N && y >= 0 && y < N && board[x][y] == -1);
}

#ifdef WARNSDORFF_HEURISTIC

int getDegree(int board[N][N], int x, int y)
{
    int count = 0;
    for (int i = 0; i < M; i++)
        if (isSafe(x + xMove[i], y + yMove[i], board)) count++;
 
    return count;
}

int nextMove(int board[N][N], int *x, int *y)
{
    int min_deg_idx = -1;
    int min_deg = M;
 
    for (int i = 0; i < M; i++)
    {
        int next_x = *x + xMove[i];
        int next_y = *y + yMove[i];
        if (isSafe(next_x, next_y, board))
        {
            int deg = getDegree(board, next_x, next_y);
            if (deg < min_deg)
            {
                min_deg_idx = i;
                min_deg = deg;
            }
        }
    }
 
    if (min_deg_idx == -1) return 0;
 
    *x += xMove[min_deg_idx];
    *y += yMove[min_deg_idx];
 
    return 1;
}
      
// A recursive utility function to solve Knight Tour problem.
int knightsTour(int x, int y, int move_i, int board[N][N])
{
    int k, next_x = x, next_y = y;

    if (move_i == N * N) return 1;
  
    if (nextMove(board, &next_x, &next_y) == 1) 
    {
        board[next_x][next_y] = move_i;
        if (knightsTour(next_x, next_y, move_i + 1, board) == 1)
            return 1;
        else
            board[next_x][next_y] = -1; // backtracking
    }

    return 0;
}

#else

int knightsTour(int x, int y, int move_i, int board[N][N])
{
    int k, next_x, next_y;

    if (move_i == N * N) return 1;
  
    for (k = 0; k < M; k++) 
    {
        next_x = x + xMove[k];
        next_y = y + yMove[k];
        if (isSafe(next_x, next_y, board)) 
        {
            board[next_x][next_y] = move_i;
            if (knightsTour(next_x, next_y, move_i + 1, board) == 1)
                return 1;
            else
                board[next_x][next_y] = -1; // backtracking
        }
    }
  
    return 0;
}

#endif

void printMatrix(int board[N][N])
{
    for (int x = 0; x < N; x++) 
    {
        for (int y = 0; y < N; y++)
            printf(" %2d ", board[x][y]);
        printf("\n");
    }
}
  
/* Driver Code */
int main()
{
    clock_t start_time = clock();
    int board[N][N];
    int sol[N][N];
    
    for (int x_start=0; x_start<N; x_start++)
    {
        for (int y_start=0; y_start<N; y_start++)
        {
            printf("start position (%d, %d)", x_start, y_start);
        
            // Inicializa tabuleiro.
            for (int x = 0; x < N; x++)
                for (int y = 0; y < N; y++)
                    board[x][y] = -1;
            
            // Marca inicio do passeio do cavalo
            board[x_start][y_start] = 0;
        
            if (knightsTour(x_start, y_start, 1, board) == 0) 
            {
                printf(" -> Solution does not exist.\n");
                sol[x_start][y_start] = 0;
            }
            else
            {
                printf(" -> Solution:\n\n");
                sol[x_start][y_start] = 1;
                printMatrix(board);
            }
            printf("\n");
        }
    }
    
    printMatrix(sol);

    clock_t end_time = clock();
    double interval = (double)(end_time - start_time) / CLOCKS_PER_SEC * 1000.0;
    printf("\n\nruntime: %.3lf ms\n", interval);
     
    return 0;
}