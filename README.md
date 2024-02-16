# AlgorithmDesignAnalysis

Neste repositório apresento alguns estudos e implementações em diversas linguagens e ferramentas sobre algoritmos e problemas computacionais clássicos. O objectivo é entender melhor esses algoritmos e suas limitações.

## Organização do repositório

Cada subdiretório pode conter vários arquivos de implementações e análises dos problemas ou algoritmos indicados. A seguir apresento um guia geral sobre os diretórios principais.

### ConsoleAppGraph

O programa `ConsoleAppGraph` é uma aplicação de console desenvolvida em `C#`, focada em demonstrar e analisar algoritmos relacionados à teoria dos grafos. Este programa serve como uma ferramenta educativa e prática para explorar diferentes aspectos e algoritmos da teoria dos grafos, que é uma área fundamental em ciência da computação e matemática aplicada.

#### Características Principais

##### 1. Implementação em C#
- **Linguagem de Programação**: O programa é inteiramente escrito em `C#`, aproveitando as características orientadas a objetos e a eficiência da linguagem.
- **Estrutura do Código**: Organizado de forma clara e modular, facilitando o entendimento e a expansão do código.

##### 2. Manipulação de Grafos
- **Criação de Grafos**: Capacidade de criar grafos, tanto direcionados quanto não direcionados, com pesos nas arestas ou sem pesos.
- **Visualização de Grafos**: Ferramentas para visualizar grafos, o que pode incluir representação em texto ou gráfica (se suportada).

##### 3. Algoritmos Implementados
- **Algoritmos de Busca**: Implementações de busca em profundidade (DFS) e busca em largura (BFS), fundamentais para a exploração de grafos.
- **Caminho Mínimo**: Algoritmos como Dijkstra ou Bellman-Ford para encontrar o caminho mais curto entre os nós.
- **Árvores Geradoras Mínimas**: Algoritmos como Prim ou Kruskal para encontrar a árvore geradora mínima em grafos ponderados.

##### 4. Aplicações Práticas
- **Problemas de Roteamento**: Soluções para problemas clássicos de roteamento e caminhos em grafos.
- **Análise de Redes**: Utilidade em simulações de redes de computadores, redes sociais, ou qualquer estrutura que possa ser representada como um grafo.

#### Uso e Interface
- **Interface de Linha de Comando**: Como uma aplicação de console, o `ConsoleAppGraph` é operado via linha de comando.
- **Instruções de Uso**: Inclui um guia de comandos e opções disponíveis.

#### Extensibilidade
- **Código Aberto e Modular**: A estrutura do programa permite que outros desenvolvedores expandam e modifiquem facilmente, adicionando novos algoritmos ou funcionalidades.

#### Documentação
- **Documentação Integrada**: O programa inclui comentários e documentação no código para facilitar o entendimento de como os algoritmos de grafos são implementados e utilizados.

---

### KnightsTourProblem

Uma exploração detalhada do Problema do Passeio do Cavalo, destacando sua complexidade NP-completa e a abordagem de backtracking usada para resolvê-lo. Neste está incluso alguns exemplos de implementações em `C++`, `python` e algumas análises com `jupyter`.

O Problema do Passeio dos Cavalos, também conhecido como **Knight's Tour**, é um clássico desafio de xadrez e teoria dos grafos. O problema consiste em mover um cavalo de xadrez de forma que ele visite cada quadrado do tabuleiro exatamente uma vez. 

Em um tabuleiro de xadrez padrão de \(8 \times 8\), o cavalo pode se mover em "L", ou seja, duas casas em uma direção e uma casa em uma direção perpendicular. O desafio é encontrar uma sequência de movimentos que permita ao cavalo cobrir todo o tabuleiro sem repetir nenhum quadrado.

Este problema pode ser generalizado para tabuleiros de qualquer tamanho, não se limitando ao padrão \(8 \times 8\).

#### Solução do Problema

O Problema do Passeio dos Cavalos é conhecido por ser NP-completo em sua generalização, o que significa que não existe um algoritmo eficiente conhecido para resolvê-lo em todos os casos para tabuleiros de tamanho grande. No entanto, para tabuleiros de tamanho moderado, como o padrão \(8 \times 8\), existem várias técnicas para encontrar uma solução:

##### 1. Backtracking (Retrocesso)
- **Método**: Este é um método de força bruta que tenta todos os possíveis movimentos do cavalo de forma recursiva. Se um movimento leva a uma solução, o algoritmo prossegue; se não, ele retrocede e tenta outra rota.
- **Características**: Embora seja simples de entender e implementar, o backtracking pode ser muito lento para tabuleiros maiores, pois o número de possíveis caminhos cresce exponencialmente.

##### 2. Heurísticas
- **Abordagem de Warnsdorff**: Esta heurística escolhe o próximo movimento do cavalo com base no número de movimentos subsequentes possíveis. Em cada etapa, o cavalo move-se para a casa que tem o menor número de movimentos válidos seguintes.
- **Eficiência**: Warnsdorff melhora significativamente a eficiência em comparação com o backtracking puro, reduzindo a quantidade de retrocessos necessários.

##### 3. Programação Dinâmica
- **Técnica**: Para tabuleiros menores, a programação dinâmica pode ser usada para armazenar e reutilizar resultados de subproblemas, reduzindo assim o tempo de computação.

##### 4. Algoritmos Genéticos e Outras Técnicas de IA
- **Abordagem Moderna**: Técnicas mais avançadas como algoritmos genéticos e redes neurais têm sido exploradas para resolver o problema de maneiras mais eficientes, especialmente em tabuleiros de grande tamanho.

### Aplicações
Embora o Problema do Passeio dos Cavalos seja originário do xadrez, ele tem aplicações em áreas como teoria dos grafos, otimização de caminhos e até em problemas de circuito eletrônico. O estudo deste problema ajuda a entender melhor os princípios de algoritmos de busca e heurísticas.

---


### Algoritmo do Fluxo Máximo
 
O Algoritmo de Fluxo Máximo é uma técnica fundamental em teoria dos grafos, usada para determinar o maior fluxo possível que pode ser enviado através de uma rede de fluxo. Uma rede de fluxo é um grafo direcionado onde cada aresta tem uma capacidade e cada aresta recebe um fluxo que não deve exceder esta capacidade.

### Descrição do Algoritmo de Fluxo Máximo

O algoritmo opera em uma rede que consiste em um conjunto de nós interconectados por arestas. Cada aresta possui uma capacidade que limita o fluxo máximo que pode passar por ela. Há dois nós especiais na rede: a fonte, de onde o fluxo começa, e o sumidouro, onde o fluxo termina.

O objetivo do algoritmo é maximizar o fluxo total da fonte para o sumidouro. Para isso, ele busca encontrar o caminho de capacidade residual máxima (ou seja, a diferença entre a capacidade da aresta e o fluxo atual) em cada etapa do processo.

### Etapas do Algoritmo

1. **Inicialização**: Começa com fluxo zero em todas as arestas.

2. **Encontrando Caminhos**: Utiliza uma busca (como a busca em largura ou profundidade) para encontrar um caminho da fonte ao sumidouro, respeitando as capacidades residuais das arestas.

3. **Aumentando o Fluxo**: Quando um caminho é encontrado, o fluxo é aumentado ao longo do caminho pelo menor valor da capacidade residual encontrada.

4. **Repetição**: O processo é repetido até que não seja possível encontrar mais nenhum caminho da fonte ao sumidouro com capacidade residual positiva.

### Variações e Aplicações

- **Algoritmo de Ford-Fulkerson**: Uma das implementações mais conhecidas do problema de fluxo máximo, adequada para redes onde as capacidades são todas inteiras.
- **Algoritmo de Edmonds-Karp**: Uma variação do Ford-Fulkerson que usa busca em largura para encontrar o caminho de aumento, garantindo uma complexidade temporal polinomial.

O Algoritmo de Fluxo Máximo tem várias aplicações práticas, incluindo:
- Determinação da capacidade máxima de rede em sistemas de telecomunicações.
- Alocação de recursos em sistemas de logística.
- Modelagem de fluxos em redes de transporte.

Este algoritmo é um exemplo clássico de como a teoria dos grafos pode ser aplicada para resolver problemas complexos em diversas áreas.

---

### String Matcher Levenshtein

Relaciona duas listas de strings utilizando a distância de Levenshtein. [Veja o README no diretório para mais detalhes](./StringMatcherLevenshtein/README.md).


---

## Licença

Este projeto está licenciado sob a Licença MIT - veja o arquivo [LICENSE](LICENSE) para detalhes.

---

## Contribuição

Contribuições são sempre bem-vindas!

---
