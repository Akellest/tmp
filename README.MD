@startuml
!theme crt-amber

title FIRST

(Login)
actor client

usecase (Exit)

rectangle bank {
client -- (take money)
client -- (transfer money)
(take money) -> (check money) : include
(transfer money) -> (???) : extend
}
@enduml
