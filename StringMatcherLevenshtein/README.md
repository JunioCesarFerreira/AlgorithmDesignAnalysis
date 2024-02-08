# String Matcher Levenshtein

Este programa monta uma função $f:D\rightarrow C$ sendo $D=\\{s_1,s_2,...,s_n\\}$ e $C=\\{t_1,t_2,...,t_m\\} duas listas de strings. A função $f$ é definida por:

$$
f(s_i)=t_j \Leftrightarrow d(s_i,t_j)=\min\\{d(s,t)|s\in D, t\in C\\}
$$

sendo $d$ a distância de Levenshtein.

## Distância de Levenshtein

A distância de Levenshtein, também conhecida como distância de edição, é uma métrica para medir a diferença entre duas sequências de caracteres (por exemplo, strings). Ela é definida como o número mínimo de operações de edição necessárias para transformar uma string na outra. As operações permitidas são:

1. Inserção de um caractere.
2. Remoção de um caractere.
3. Substituição de um caractere por outro.

A formulação matemática para calcular a distância de Levenshtein entre duas strings, $s$ de comprimento $n$ e $t$ de comprimento $m$, pode ser definida recursivamente da seguinte maneira:

Seja $d[i, j]$ o custo (ou distância) para transformar os primeiros $i$ caracteres de $s$ nos primeiros $j$ caracteres de $t$. Então, $d[i, j]$ pode ser calculado como:

1. **Caso base:**
   - $d[i, 0] = i$, para $0 \leq i \leq n$.
   - $d[0, j] = j$, para $0 \leq j \leq m$.

   Estes casos base representam a transformação de uma string vazia em outra por meio de inserções ou remoções.

2. **Passo recursivo:**
   - Para $i > 0$ e $j > 0$, $d[i, j]$ é o mínimo das seguintes opções:
     - $d[i-1, j] + 1$: Remoção de um caractere (transformar $s[1..i-1]$ em $t[1..j]$ e remover o caractere $s[i]$).
     - $d[i, j-1] + 1$: Inserção de um caractere (transformar $s[1..i]$ em $t[1..j-1]$ e inserir $t[j]$).
     - $d[i-1, j-1] + \text{custo}$: Substituição (ou manutenção, se $s[i] = t[j]$) de um caractere, onde:
       - $\text{custo} = 0$, se $s[i] = t[j]$ (os caracteres são iguais, nenhuma operação necessária).
       - $\text{custo} = 1$, se $s[i] \neq t[j]$ (substituir $s[i]$ por $t[j]$).

A distância de Levenshtein entre $s$ e $t$ é então dada por $d(s,t):=d[n, m]$, representando o custo mínimo para transformar completamente $s$ em $t$.

Essa abordagem pode ser otimizada para usar espaço linear, mantendo apenas a linha atual e a linha anterior da matriz $d$, embora a complexidade de tempo permaneça $O(nm)$.

---

## Pré-requisitos
Para executar este programa, você precisará de:
- [Go](https://golang.org/dl/) (para a versão Go do programa)
- [.NET Core](https://dotnet.microsoft.com/download) (para a versão C# do programa)

## Como Instalar
1. Clone o repositório para sua máquina local:
   ```
   git clone https://github.com/seu-usuario/StringMatcherLevenshtein.git
   ```
2. Navegue até o diretório do projeto clonado.

### Para a versão Go:
   ```
   cd go-version
   ```
### Para a versão C#:
   ```
   cd csharp-version
   ```

## Como Usar
Depois de instalar os pré-requisitos e clonar o repositório, você pode executar o programa seguindo estas etapas:

### Para a versão Go:
1. No diretório `go-program`, execute o comando:
   ```
   go run main.go
   ```

### Para a versão C#:
1. No diretório `cs-program`, compile e execute o programa com:
   ```
   dotnet run
   ```
