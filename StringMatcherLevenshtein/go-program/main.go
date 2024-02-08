package main

import (
	"bufio"
	"fmt"
	"os"
)

// Função para calcular a distância de Levenshtein entre duas strings
func levenshteinDistance(s, t string) int {
	d := make([][]int, len(s)+1)
	for i := range d {
		d[i] = make([]int, len(t)+1)
	}

	for i := range d {
		d[i][0] = i
	}
	for j := range d[0] {
		d[0][j] = j
	}

	for j := 1; j <= len(t); j++ {
		for i := 1; i <= len(s); i++ {
			if s[i-1] == t[j-1] {
				d[i][j] = d[i-1][j-1] // no operation required
			} else {
				min := d[i-1][j]     // a deletion
				if d[i][j-1] < min { // an insertion
					min = d[i][j-1]
				}
				if d[i-1][j-1] < min { // a substitution
					min = d[i-1][j-1]
				}
				d[i][j] = min + 1
			}
		}
	}
	return d[len(s)][len(t)]
}

// Função principal para encontrar e imprimir os pares mais próximos
func findClosestPairs(list1, list2 []string) {
	for _, s1 := range list1 {
		minDistance := -1
		closest := ""
		for _, s2 := range list2 {
			distance := levenshteinDistance(s1, s2)
			if minDistance == -1 || distance < minDistance {
				minDistance = distance
				closest = s2
			}
		}
		fmt.Printf("f(%s)='%s' d= %d\n", s1, closest, minDistance)
	}
}

// Função para ler strings da entrada padrão até uma linha em branco
func readStrings() []string {
	var lines []string
	scanner := bufio.NewScanner(os.Stdin)

	for scanner.Scan() {
		line := scanner.Text()
		if line == "" { // Linha em branco indica o fim da lista
			break
		}
		lines = append(lines, line)
	}

	return lines
}

func main() {
	list1 := []string{"gato", "cão", "pássaro", "passado", "passageiro", "pato", "são"}
	list2 := []string{"rato", "cão", "passarinho"}

	fmt.Printf("\nlist1-->list2 |list1|=%d |list2|=%d\n", len(list1), len(list2))
	findClosestPairs(list1, list2)

	fmt.Printf("\nlist2-->list1 |list1|=%d |list2|=%d\n", len(list1), len(list2))
	findClosestPairs(list2, list1)
}
