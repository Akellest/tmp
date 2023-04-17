@startuml
actor Игрок
actor Машина
participant Game
participant Dice

activate Game
Игрок -> Game: Бросить кубики
Game -> Dice: roll()
Dice -> Game: result
Game -> Игрок: Показать результат броска
Game -> Машина: Показать результат броска
deactivate Game
@enduml
