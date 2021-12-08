# Estudo de funcionamento de conceitos de uma RNA
#### sem utilizar bibliotecas sobre o assunto pré existentes.
----
### Conceito de rede neural 
[Conceito de rede neural Wikipedia](https://pt.wikipedia.org/wiki/Rede_neural_artificial)

### Aplicação

Nos conceitos de RNA, as informações de comportamento não se encontram nos neuronios (vertices) mas sim nas arestas que possuem um peso da informação do vertice anterior.
- Os vertices possuem um estado transitório sendo importante apenas no momento do seu calculo. 
Por esse motivo foquei em transformar as arestas em camadas de matrizes bidimensionais.
* Por exemplo em uma rede neural com 3 entradas uma camada intermediaria de 4 neuronios e 2 saidas terá duas matrizes uma com [3,4] e outra [4,2].
* A Matriz irá calcular o valor do vertice com base no valor das arestas de entrada e o estado do vertice. 
* Cada aresta terá um peso do vertice anterior
  * Quanto mais importante for o vertice anterior mais perto de 1 será o valor da aresta.
  * Quanto menos importante for a informação do vertice anterior para esse vertice, mais perto de 0 será o valor da aresta.