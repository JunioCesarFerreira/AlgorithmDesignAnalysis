import numpy as np
import networkx as nx
import matplotlib.pyplot as plt

G = nx.Graph()

N = 5

count = 0
coords = {}

for i in range(1, N+1):
    for j in range(1, N+1):
        G.add_node(count)
        coords[count] = (i, j)
        count = count+1

def get_index(n, m):
    for key, value in coords.items():
        if value == (n, m):
            return key
    print("erro ", n, m)
    return -1

def get_next_pos(n, m):
    r_list = []
    if n + 2 <= N:
        if m + 1 <= N :
            r_list.append(get_index(n+2, m+1))
        if  m - 1 >= 1 :
            r_list.append(get_index(n+2, m-1))
    if n - 2 >= 1:
        if m + 1 <= N :
            r_list.append(get_index(n-2, m+1))
        if  m - 1 >= 1 :
            r_list.append(get_index(n-2, m-1))
    if m + 2 <= N:
        if n + 1 <= N :
            r_list.append(get_index(n+1, m+2))
        if n - 1 >= 1 :
            r_list.append(get_index(n-1, m+2))
    if m - 2 >= 1:
        if n + 1 <= N :
            r_list.append(get_index(n+1, m-2))
        if n - 1 >= 1 :
            r_list.append(get_index(n-1, m-2))
    return r_list

vertices = list(G.nodes())

print(vertices)

for v in vertices:
    arr = get_next_pos(coords[v][0], coords[v][1])
    print(v,"->",arr)
    for e in arr :
        G.add_edge(v, e)
        
        
pos = nx.spring_layout(G)

nx.draw(G, with_labels = True, node_size=400, pos=pos, node_color = 'gray')

plt.show()