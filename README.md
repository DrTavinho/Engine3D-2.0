Engine3D 2.0

Uma engine gráfica 3D desenvolvida inteiramente em C# (.NET Framework) utilizando Windows Forms, criada com o objetivo de estudar e implementar manualmente os principais conceitos de Computação Gráfica, Geometria Computacional e Álgebra Linear.

Ao contrário de engines tradicionais, este projeto não utiliza OpenGL, DirectX, Unity, Godot ou qualquer outra API gráfica para renderização 3D. Todo o pipeline gráfico foi implementado manualmente, desde as transformações dos objetos até a projeção em perspectiva e a renderização em tela.

Objetivos

O principal objetivo do projeto é compreender profundamente como funciona uma engine gráfica internamente, implementando cada etapa do processo de renderização utilizando apenas recursos nativos do Windows Forms.

Entre os tópicos abordados estão:

Álgebra Linear
Geometria Analítica
Computação Gráfica
Geometria Computacional
Estruturas de Dados
Programação Orientada a Objetos
Renderização Wireframe
Pipeline Gráfico
Projeção em Perspectiva
Transformações 3D
Tecnologias Utilizadas
C#
.NET Framework
Windows Forms
GDI+
MIConvexHull (cálculo automático das faces)
Funcionalidades
Criação Procedural de Poliedros

A engine permite criar diversos sólidos tridimensionais diretamente pela interface.

Atualmente estão disponíveis:

Cubo
Paralelepípedo
Prisma
Pirâmide
Tronco de Pirâmide
Tetraedro
Octaedro
Icosaedro
Dodecaedro

ADICIONAR IMAGEM DO MENU DE CRIAÇÃO

ADICIONAR GIF CRIANDO DIFERENTES POLIEDROS

Transformações dos Objetos

Cada objeto possui transformações independentes.

É possível alterar:

Posição
Escala
Rotação em X
Rotação em Y
Rotação em Z

Todas as transformações são aplicadas em tempo real.

ADICIONAR GIF EDITANDO TRANSFORMAÇÕES

PropertyGrid Dinâmica

A PropertyGrid foi totalmente customizada utilizando ICustomTypeDescriptor.

Além das propriedades tradicionais do objeto, todos os vértices são adicionados dinamicamente.

Cada vértice pode ser expandido individualmente para editar suas coordenadas X, Y e Z.

ADICIONAR IMAGEM DA PROPERTYGRID

Seleção de Objetos

Os objetos podem ser selecionados de diversas maneiras:

clicando diretamente na viewport;
selecionando na lista da cena;
através da PropertyGrid.

Todos os componentes permanecem sincronizados automaticamente.

ADICIONAR GIF DA SELEÇÃO DE OBJETOS

Seleção Individual de Vértices

Cada vértice pode ser selecionado diretamente na viewport.

Ao selecionar um vértice:

ele recebe destaque visual;
o poliedro correspondente é selecionado;
a PropertyGrid navega automaticamente até aquele vértice;
a lista de objetos da cena também é atualizada.

ADICIONAR GIF DA SELEÇÃO DE VÉRTICES

Exclusão Inteligente de Vértices

A engine permite remover vértices individualmente.

Após a remoção:

identifica os vértices vizinhos;
calcula o centroide da região;
estima a normal da nova face;
reconecta automaticamente a geometria.

Esse processo permite alterar a estrutura dos sólidos dinamicamente.

ADICIONAR GIF REMOVENDO VÉRTICES

Cálculo Automático das Faces

As faces não são armazenadas manualmente.

Sempre que um poliedro é criado ou sofre alterações estruturais, é executado automaticamente o algoritmo Convex Hull, através da biblioteca MIConvexHull, reconstruindo toda a malha do sólido.

Isso permite que novos poliedros sejam gerados dinamicamente sem necessidade de definir manualmente todas as faces.

ADICIONAR GIF MOSTRANDO O RECÁLCULO DAS FACES

Renderização Wireframe

Toda a renderização wireframe é realizada manualmente.

O processo consiste em:

transformação dos vértices;
conversão para espaço da câmera;
projeção em perspectiva;
desenho das arestas utilizando GDI+.

Nenhuma biblioteca gráfica externa é utilizada.

ADICIONAR GIF DA RENDERIZAÇÃO

Sombreamento

Após o cálculo das faces, a engine também realiza uma renderização preenchida.

Cada face possui:

cálculo da normal;
iluminação difusa simples;
intensidade calculada através do produto escalar (modelo de Lambert).

Isso permite visualizar melhor o volume dos objetos.

ADICIONAR GIF DO SOMBREAMENTO

Câmera Livre

A câmera possui movimentação semelhante à encontrada em engines profissionais.

Recursos:

movimentação WASD;
movimentação vertical;
rotação por mouse;
controle do Field of View (FOV);
movimentação baseada na orientação da câmera.

ADICIONAR GIF DA NAVEGAÇÃO

Sistema de Grid

A viewport possui um grid tridimensional para auxiliar na orientação espacial.

Também é possível alterar dinamicamente o espaçamento entre as linhas.

ADICIONAR IMAGEM DO GRID

Interface

A interface foi inspirada em softwares CAD e modeladores 3D.

Ela é composta por:

viewport;
PropertyGrid;
lista de objetos;
barra de menus;
barra de ferramentas;
barra de status.

Todo o sistema permanece sincronizado em tempo real.

ADICIONAR IMAGEM GERAL DA INTERFACE

Estrutura do Projeto
Engine3D_2.0
│
├── Camera.cs
├── MainForm.cs
├── Polyhedron.cs
├── PolyFactory.cs
├── Vector3.cs
├── Vertex3D.cs
├── VertexPropertyDescriptor.cs
│
├── Forms/
├── Resources/
└── Properties/
Conceitos Implementados

Durante o desenvolvimento foram implementados manualmente diversos conceitos fundamentais da Computação Gráfica.

Matemática
Vetores 3D
Produto Escalar
Produto Vetorial
Normalização
Magnitude
Distância Euclidiana
Centroide
Interpolação Linear (LERP)
Transformações
Escala
Rotação
Translação
Matrizes de Rotação
Computação Gráfica
Espaço do Mundo
Espaço da Câmera
Projeção Perspectiva
Clipping básico
Wireframe
Renderização de Faces
Iluminação Difusa
Geometria Computacional
Convex Hull
Reconstrução Automática de Faces
Cálculo de Normais
Reconexão Automática de Arestas
Bibliotecas Utilizadas
MIConvexHull

Utilizada exclusivamente para reconstrução automática das faces convexas dos poliedros após alterações estruturais.

Repositório oficial:

https://github.com/DesignEngrLab/MIConvexHull

Próximas Funcionalidades
Ocultação de faces (Back-Face Culling)
Z-Buffer
Renderização sólida completa
Importação de modelos OBJ
Exportação de modelos
Sistema de materiais
Múltiplas luzes
Texturização
Gizmos de transformação
Undo / Redo
Sistema de cena hierárquica
Viewports ortográficas
Ferramentas de modelagem
Autor

Desenvolvido por Gustavo Rodrigues Muti Pacheco como projeto de estudo em Computação Gráfica, com foco na implementação manual dos principais algoritmos utilizados em engines 3D.
