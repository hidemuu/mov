# Schema

## DbObject

### Schema

- DbObject

  | 名称 | 型 | 説明 | 例 |
  | ---- | ---- | ---- | ---- |
  | Id | Guid | データベースの主キー |  |
  | Index | int | 並び順のインデックス番号 |  |
  | Code | string | キーコード |  |

### Class Diagram

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
```