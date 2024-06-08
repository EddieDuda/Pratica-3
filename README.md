# Pratica 3
Melhorias Implementadas
Algoritmo de Busca em Largura (BFS)

Para garantir que o menor caminho entre duas casas no condomínio seja encontrado corretamente, coloquei o Algoritmo de Busca em Largura no método FindPath da classe Pathfinder. Isso garante a menor distância entre as casas.

MapController
Modifiquei a classe MapController para melhorar a interação do usuário e a visualização do caminho encontrado:

    Manipulação de Seleção de Nós:
        Quando um nó é selecionado como ponto de partida (from), o nome do nó é exibido no display correspondente.
        Quando um segundo nó é selecionado como destino (to), o algoritmo BFS é executado para encontrar o menor caminho. O nome do nó de destino é exibido no display correspondente.

    Visualização do Caminho:
        Se um caminho é encontrado, ele é desenhado na tela utilizando o LineRenderer, e uma mensagem informando a quantidade de nós no caminho é exibida.
        Se o caminho não é possível, uma mensagem "Path not possible" é exibida no display de informações.
        Se o usuário clicar em um nó após o caminho ter sido desenhado, a seleção é reiniciada, permitindo que um novo caminho seja selecionado.
