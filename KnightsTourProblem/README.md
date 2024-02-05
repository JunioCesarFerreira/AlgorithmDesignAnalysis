# Problema do Passeio do Cavalo

O problema do passeio do cavalo é um desafio matemático e de programação que consiste em encontrar um caminho para um cavalo se mover em um 
tabuleiro de xadrez de dimensão N x N, passando por todas as casas exatamente uma vez. O problema é considerado NP-completo, o que significa 
que não há algoritmo eficiente conhecido que possa resolver o problema em tempo polinomial para tabuleiros de tamanho arbitrário.

Uma solução comum para o problema do passeio do cavalo é utilizar a técnica de backtracking, que é uma estratégia de busca exaustiva que tenta 
construir uma solução recursivamente, fazendo escolhas em cada etapa e desfazendo-as se necessário. O backtracking é eficiente porque evita a 
busca em ramos do espaço de soluções que não têm potencial para levar a uma solução viável.

O algoritmo de backtracking para o problema do passeio do cavalo pode ser implementado da seguinte forma:

1. Iniciar com uma posição inicial do cavalo no tabuleiro.
2. Marcar a posição como visitada.
3. Tentar todos os movimentos possíveis do cavalo a partir da posição atual para casas não visitadas.
4. Escolher um dos movimentos possíveis e avançar recursivamente para a próxima etapa.
5. Repetir os passos 2-4 até que todas as casas tenham sido visitadas ou até que não haja mais movimentos possíveis.
6. Se todas as casas foram visitadas, retornar a solução encontrada.
7. Caso contrário, fazer "backtrack" (desfazer o movimento anterior) e tentar outra opção.
8. Se não houver mais opções, retroceder novamente até encontrar uma solução ou até que todo o espaço de busca seja explorado.

[Wikipedia](https://en.wikipedia.org/wiki/Knight%27s_tour)
