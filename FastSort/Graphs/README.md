Alhorithms of list

Списки
Двусвязный
    Node
    {
        Value { get; set; }
        Previous_Node { get; set; }
        Next_Node { get; set; }
    }
Кольцевой
    Node
    {
        Value { get; set; }
        Next_Node { get; set; }
    }
Next_Node на последнем эллементе ссылается на head    


Бинарное дерево
        Node
        {
            LeftNode { get; set; }
            RightNode { get; set; }
            Value { get; set; }
        }
Они бывают 3 типов


Матрица смежности
обход в глубину:

обход в ширину:


Список смежности => матрица смежности
W[1] = [2, 3, 4] 
W[2] = [1, 4, 5] 
W[3] = [1, 4] 
W[4] = [1, 2, 3, 5] 
W[5] = [2, 4]
-----------------
array = [
            [0,1,1,1,0]
            [1,0,0,1,1]
            [1,0,0,1,0]
            [1,1,1,0,1]
            [0,1,0,1,0]
        ]