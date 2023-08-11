```mermaid
flowchart BT
    
    direction BT
    Core["Core"] --> CoreImplements

    subgraph CoreImplements

        subgraph IO
            direction BT
            Accessors --> Repositories
            Repositories --> Resources
            Loggers
        end

        Repositories --> RepositoryService
        
        subgraph RepositoryService
            Configurators
            Errors
            Translators
        end

        subgraph BusinnessService
            Authorizers
            Learnings
            Schedulers
        end

        subgraph UI
            Layouts
            Graphicers  
        end
        
    end

```