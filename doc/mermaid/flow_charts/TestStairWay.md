```mermaid
flowchart LR
    
    subgraph ApplicationLayer
        direction RL
        Analizer.Service --> Analizer.Models
        Analizer.Repository --> Analizer.Models    
    end
    
    ConsoleApp --> ApplicationLayer
    WebApp --> ApplicationLayer
    
```