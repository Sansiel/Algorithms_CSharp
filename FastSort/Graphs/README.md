# Alhorithms of list
- - - - - - -
Списки
---------
Двусвязный
```    
    Node
    {
        Value { get; set; }
        Previous_Node { get; set; }
        Next_Node { get; set; }
    }
```
![image](https://user-images.githubusercontent.com/37710447/119268459-27e2d400-bc04-11eb-98df-7db8a9aec702.png)

- - - - - - - -
Кольцевой
```
    Node
    {
        Value { get; set; }
        Next_Node { get; set; }
    }
```
Next_Node на последнем эллементе ссылается на head   
![image](https://user-images.githubusercontent.com/37710447/119268465-30d3a580-bc04-11eb-916a-38de0b6f566b.png)

- - - - - - - -


Бинарное дерево
---------
```
        Node
        {
            LeftNode { get; set; }
            RightNode { get; set; }
            Value { get; set; }
        }
```
Они бывают разные
* двоичное древо поиска ![image](https://user-images.githubusercontent.com/37710447/119268592-bce5cd00-bc04-11eb-9c45-905e74a612a4.png)

* двоичная куча ![image](https://user-images.githubusercontent.com/37710447/119268557-89a33e00-bc04-11eb-8804-babf9dbdc42e.png)

- - - - - - - -


Матрица смежности
---------
обход в глубину:
![image](https://user-images.githubusercontent.com/37710447/119268097-71caba80-bc02-11eb-96df-4d5249ced190.png)
обход в ширину:
![image](https://user-images.githubusercontent.com/37710447/119268101-7a22f580-bc02-11eb-82ad-eaa1dfcf6d4e.png)



Список смежности => матрица смежности
* W[1] = [2, 3, 4] 
* W[2] = [1, 4, 5] 
* W[3] = [1, 4] 
* W[4] = [1, 2, 3, 5] 
* W[5] = [2, 4]
* array = [
            [0,1,1,1,0],
            [1,0,0,1,1],
            [1,0,0,1,0],
            [1,1,1,0,1],
            [0,1,0,1,0],
        ]

- - - - - - - - - -
Хеш-таблица
---------
Метод цепочек (открытое хеширование) — все элементы данных с совпадающем хешем объединяются в список.
![image](https://user-images.githubusercontent.com/37710447/119317200-e3e5e280-bc88-11eb-9d22-ded38e54d87e.png)
