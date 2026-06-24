## What is NoSQL?
**NoSQL** stands for "**Not Only SQL**" its a broad term to describe databases that do not follow the traditional relational model (tables, rows, columns, and strict schemas). Instead, they use more flexible data models.
### Key Ideas
- **Data Model:** NoSQL databases often store data in formats like documents (JSON in MongoDB), key-value pairs, wide-column stores, or graphs.
    
- **Schema Flexibility:** Unlike SQL databases, you don’t need to predefine a rigid schema. You can add new fields to documents without altering the whole database structure.
    
- **Scalability:** NoSQL databases are designed to scale horizontally (adding more servers) more easily than many traditional SQL systems.
    
- **Query Language:** They don’t use SQL; instead, each NoSQL type has its own way of querying. For MongoDB, you query using JSON-like syntax.
---
## ACID VS BASE
ACID Is The standard for RDBMS (Atomicity, Consistency, Isolation, Durability),  BASE:
- **Basically Available**: The System is guaranteed to be available for querying by all users
- **Soft State:** The values stored in the system may change because of the eventual consistency model, as described in the next bullet.
- **Eventually Consistent:** As data is added to the system, the system state is gradually replicated across all nodes
---
## CAP Theorem
The CAP Theorem states that it is impossible for a distributed computer system to simultaneously provide all three of the following
- Consistency
- Availability
- Partition Tolerance
So I Have to pick two of these three
- CP Category => There is a risk of some data becoming unavailable
- AP Category => Clients may read inconsistent data
- CA Category => Network problem might stop the system.
