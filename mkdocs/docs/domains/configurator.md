# Configurator

## DomainModel

### スキーマ

- UserSetting

  |  名称  |  型  |  説明  |  例  |
  | ---- | ---- | ---- | ---- |
  |  Category  |  string  |  |  |
  |  Name  |  string  |  |  |

### クラス図

```mermaid
classDiagram
  class UserSetting {
    +Name: double
    +Category: double
    +Icon: RegionType
    +ControlType: string
    +Schema: string
    +DefaultValue: int
    +GetProperties()
  }
  class SystemSetting {
    +Name: double
    +Category: double
    +Icon: RegionType
    +ControlType: string
    +Schema: string
    +DefaultValue: int
    +GetProperties()
  }
  class Language {
    +Height: double
    +Width: double
    +Location: RegionType
    +BackgroundColor: string
    +BorderColor: string
    +BorderThickness: int
    +GetProperties()
  }
  
```

## BusinnessLogic

``` mermaid
sequenceDiagram
  autonumber
  Alice->>John: Hello John, how are you?
  loop Healthcheck
      John->>John: Fight against hypochondria
  end
  Note right of John: Rational thoughts!
  John-->>Alice: Great!
  John->>Bob: How about you?
  Bob-->>John: Jolly good!
```

## UseCase