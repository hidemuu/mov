```mermaid
sequenceDiagram
    participant コントローラー
    participant サービス
    participant ドメインモデル
    コントローラー->>サービス: Hello John, how are you?
    サービス->>ドメインモデル: Great!
    loop Healthcheck
        ドメインモデル->>ドメインモデル: Fight against hypochondria
    end
    Note right of ドメインモデル: Rational thoughts <br/>prevail!
    ドメインモデル-->>サービス: Domain Exception
    サービス-->>コントローラー: Service Exception
```