```mermaid
classDiagram
    class IEntityObject{
        <<interface>>
        +Id: Guid
    }
    class DbObject {
        +Id: Guid
        +Index: int
        +Code: string
        +ToHeaderString()
        +ToContentString()
    }
    class DbObjectNode {
        +Children: T[] where T: DbObject
    }

    DbObject ..|> IEntityObject
    DbObjectNode ..|> DbObject

    class IEntityObjectCollection{
        <<interface>>
        +Items: T[]
    }

    DbObjectCollection ..|> IEntityObjectCollection

    class DbObjectCollection {
        <<abstract>>
        +Items: T[] where T: DbObject
    }

    DbObjectCollection *..|> DbObject

  ```