```mermaid
flowchart LR
    
    subgraph PresentationLayer
        subgraph Analizer_Views
            direction BT
            Analizer.Views --> Analizer.ViewModels
        end
        subgraph Driver_Views
            direction BT
            Driver.Views --> Driver.ViewModels
        end
    end

    Analizer_Views --> Analizer_Services
    Driver_Views --> Driver_Services

    subgraph ApplicationLayer
        subgraph Analizer_Services
            direction BT
            Analizer.ServiceImplements --> Analizer.Service
        end
        
        subgraph Driver_Services
            direction BT
            Driver.ServiceImplements --> Driver.Service
        end
    end

    Analizer_Services --> Analizer_BusinessLogic
    Analizer_Services --> Analizer_DataAccess
    Driver_Services --> Driver_BusinessLogic
    Driver_Services --> Driver_DataAccess

    subgraph DomainLayer
        subgraph Analizer_BusinessLogic
            direction BT
            Analizer.Engine --> Analizer.Models
        end
        subgraph Analizer_DataAccess
            direction BT
            Analizer.RepositoryImplements[("RepositoryImplements")] --> Analizer.Repository
        end
        subgraph Driver_BusinessLogic
            direction BT
            Driver.Engine --> Driver.Models
        end
        subgraph Driver_DataAccess
            direction BT
            Driver.RepositoryImplements[("RepositoryImplements")] --> Driver.Repository
        end
    end
    
    subgraph InfrastructureLayer
        Analizer_BusinessLogic --> Accessor
        Driver_BusinessLogic --> Accessor
    end
    
```