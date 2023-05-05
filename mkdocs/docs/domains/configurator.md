# Configurator

## Domain Model

---

### Schema

- UserSetting

  | 名称 | 型 | 説明 | 例 |
  | ---- | ---- | ---- | ---- |
  | Category | string |  |  |
  | Name | string |  |  |
  | Value | string |  |  |
  | Default | string |  |  |
  | Description | string |  |  |
  | AccessLv | int |  |  |

### Class Diagram

```mermaid
classDiagram
  class UserSetting {
    +Category: string
    +Name: string
    +Value: string
    +Default: string
    +Description: string
    +AccessLv: int
    +GetProperties()
  }
  class SystemSetting {
    +Category: string
    +Name: string
    +Value: string
    +Default: string
    +Description: string
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

---

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

---
