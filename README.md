# Engine3D 2.0

Uma engine gráfica 3D desenvolvida inteiramente em **C# (.NET Framework) utilizando Windows Forms**, criada com o objetivo de estudar e implementar manualmente os principais conceitos de Computação Gráfica, Geometria Computacional e Álgebra Linear.

Ao contrário de engines tradicionais, este projeto **não utiliza OpenGL, DirectX, Unity, Godot ou qualquer outra API gráfica para renderização 3D**. Todo o pipeline gráfico foi implementado manualmente, desde as transformações dos objetos até a projeção em perspectiva e a renderização em tela.

---

# Objetivos

O principal objetivo do projeto é compreender profundamente como funciona uma engine gráfica internamente, implementando cada etapa do processo de renderização utilizando apenas recursos nativos do Windows Forms.

Entre os tópicos abordados estão:

- Álgebra Linear
- Geometria Analítica
- Computação Gráfica
- Geometria Computacional
- Estruturas de Dados
- Programação Orientada a Objetos
- Renderização Wireframe
- Pipeline Gráfico
- Projeção em Perspectiva
- Transformações 3D

---

# Tecnologias Utilizadas

- C#
- .NET Framework
- Windows Forms
- GDI+
- MIConvexHull (cálculo automático das faces)

---

# Funcionalidades

## Criação Procedural de Poliedros

A engine permite criar diversos sólidos tridimensionais diretamente pela interface.

Estão disponíveis inicialmente:

- Cubo
- Pirâmide
- Tronco de Pirâmide
- Prisma
- Prisma Reto
- Icosaedro
- Dodecaedro

Porém cada poliedro pode ser editado individualmente e pode ter seu estado inicial de criação modificado.

<img width="456" height="188" alt="image" src="https://github.com/user-attachments/assets/0455ca13-3607-4be2-9407-3a6c58fbee85" />

<img width="784" height="538" alt="2026-07-2822-28-46-ezgif com-optimize" src="https://github.com/user-attachments/assets/6c8ea42b-633c-4b62-a7d0-2836dd9e5ccc" />
<img width="784" height="542" alt="ezgif com-optimize" src="https://github.com/user-attachments/assets/e797c05e-0eec-489a-bcd8-f5dd25e3b044" />

---

## Transformações dos Objetos

Cada objeto possui transformações independentes.

É possível alterar:

- Posição
- Escala
- Rotação em X
- Rotação em Y
- Rotação em Z

Todas as transformações são aplicadas em tempo real.

> **ADICIONAR GIF EDITANDO TRANSFORMAÇÕES**

---

## PropertyGrid Dinâmica

A PropertyGrid foi totalmente customizada utilizando `ICustomTypeDescriptor`.

Além das propriedades tradicionais do objeto, todos os vértices são adicionados dinamicamente.

Cada vértice pode ser expandido individualmente para editar suas coordenadas X, Y e Z.

<img width="223" height="366" alt="image" src="https://github.com/user-attachments/assets/3f887f3f-9a5d-4f63-86fd-8e0aad382aa2" />

---

## Seleção Individual de Objetos e Vértices

Cada vértice pode ser selecionado diretamente na viewport.

Ao selecionar um vértice:

- ele recebe destaque visual;
- o poliedro correspondente é selecionado;
- a PropertyGrid navega automaticamente até aquele vértice;
- a lista de objetos da cena também é atualizada.

> **ADICIONAR GIF DA SELEÇÃO DE VÉRTICES**

---

## Exclusão Inteligente de Vértices

A engine permite remover vértices individualmente.

Após a remoção:

- identifica os vértices vizinhos;
- calcula o centroide da região;
- estima a normal da nova face;
- reconecta automaticamente a geometria.

Esse processo permite alterar a estrutura dos sólidos dinamicamente.

> **ADICIONAR GIF REMOVENDO VÉRTICES**

---

## Cálculo Automático das Faces

As faces não são armazenadas manualmente.

Sempre que um poliedro é criado ou sofre alterações estruturais, é executado automaticamente o algoritmo **Convex Hull**, através da biblioteca **MIConvexHull**, reconstruindo toda a malha do sólido.

Isso permite que novos poliedros sejam gerados dinamicamente sem necessidade de definir manualmente todas as faces.

> **ADICIONAR GIF MOSTRANDO O RECÁLCULO DAS FACES**

---

## Renderização Wireframe

Toda a renderização wireframe é realizada manualmente.

O processo consiste em:

- transformação dos vértices;
- conversão para espaço da câmera;
- projeção em perspectiva;
- desenho das arestas utilizando GDI+.

Nenhuma biblioteca gráfica externa é utilizada.

<img width="302" height="296" alt="image" src="https://github.com/user-attachments/assets/8938d211-fbff-4759-a07b-dc2bffed9c18" />

---

## Sombreamento

Após o cálculo das faces, a engine também realiza uma renderização preenchida.

Cada face possui:

- cálculo da normal;
- iluminação difusa simples;
- intensidade calculada através do produto escalar (modelo de Lambert).

Isso permite visualizar melhor o volume dos objetos.

*Este recurso é experimental e não funciona corretamente com múltiplos poliedros na cena.*

<img width="282" height="284" alt="image" src="https://github.com/user-attachments/assets/07198a2d-4838-49dc-a6ca-bd1bc772394b" />

---

## Câmera Livre

A câmera possui movimentação semelhante à encontrada em engines profissionais.

Recursos:

- movimentação WASD;
- movimentação vertical;
- rotação por mouse;
- controle do Field of View (FOV);
- movimentação baseada na orientação da câmera.
- sensibilidade da câmera segundo o DPI do mouse
- ajuste da velocidade de voo da câmera no espaço

<img width="274" height="147" alt="image" src="https://github.com/user-attachments/assets/13a0b7bb-e35a-4056-a224-ba6be2bff67a" />
<img width="258" height="295" alt="image" src="https://github.com/user-attachments/assets/8c102c89-78ea-43aa-92ef-abf5f9176c9a" />

> **ADICIONAR GIF DA NAVEGAÇÃO**

---

## Sistema de Grid

A viewport possui um grid tridimensional para auxiliar na orientação espacial.

Também é possível alterar dinamicamente o espaçamento entre as linhas.

<img width="541" height="604" alt="image" src="https://github.com/user-attachments/assets/9d918737-419f-42ee-92ec-8715cc49032c" />

---

## Interface

A interface foi inspirada em softwares CAD e modeladores 3D.

Ela é composta por:

- viewport;
- PropertyGrid;
- lista de objetos;
- barra de menus;
- barra de ferramentas;
- barra de status.

Todo o sistema permanece sincronizado em tempo real.

<img width="783" height="669" alt="image" src="https://github.com/user-attachments/assets/a5faa6fb-ae2f-46d0-b562-ac34c7ccaedd" />

---

# Estrutura do Projeto

```text
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
```

---

# Conceitos Implementados

Durante o desenvolvimento foram implementados manualmente diversos conceitos fundamentais da Computação Gráfica.

## Matemática

- Vetores 3D
- Produto Escalar (Dot Product)
- Produto Vetorial (Cross Product)
- Normalização
- Magnitude
- Distância Euclidiana
- Centroide
- Interpolação Linear (LERP)

## Transformações

- Escala
- Rotação
- Translação
- Matrizes de Rotação

## Computação Gráfica

- Espaço do Mundo (World Space)
- Espaço da Câmera (Camera Space)
- Projeção em Perspectiva
- Clipping básico
- Wireframe
- Renderização de Faces
- Iluminação Difusa (Lambert)

## Geometria Computacional

- Convex Hull
- Reconstrução Automática de Faces
- Cálculo de Normais
- Reconexão Automática de Arestas

---

# Bibliotecas Utilizadas

## MIConvexHull

Utilizada exclusivamente para reconstrução automática das faces convexas dos poliedros após alterações estruturais.

Repositório oficial:

https://github.com/DesignEngrLab/MIConvexHull

---

# Possíveis melhorias futuras

- Back-Face Culling
- Z-Buffer
- Renderização sólida completa
- Importação de modelos OBJ
- Exportação de modelos OBJ
- Sistema de materiais
- Múltiplas fontes de iluminação
- Texturização
- Gizmos de transformação
- Undo / Redo
- Sistema de cena hierárquica
- Viewports ortográficas
- Ferramentas de modelagem
- Seleção por caixa (Box Selection)
- Seleção múltipla de objetos

---

# Autor

Desenvolvido por **Gustavo Rodrigues Muti Pacheco** como projeto de estudo em Computação Gráfica, com foco na implementação manual dos principais algoritmos utilizados em engines 3D.
