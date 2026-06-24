## 1. Document Databases
Data is stored as self contained documents, typically in JSON or BSON format. Each document can have a completely different structure. There is no rigid schema enforced upfront.
```js
{
  "_id": "user_001",
  "name": "Sara Ahmed",
  "age": 29,
  "address": {
    "city": "Cairo",
    "zip": "11511"
  },
  "hobbies": ["reading", "hiking"]
}
```
to make something like this in SQL `address` , `hobbies` it will take multiple tables.
- **Main use cases**: Content management systems, e-commerce product catalogs, user profile, blogging platforms, any domain where each record has a different shape.
- **Advantages**: Schema flexibility (add a new field without migrating the whole database), data locality (everything about a user is in one place), rich query language to search inside nested fields.
- **vs. Relational**: In SQL you need a `users` table, an `addresses` table, and a `hobbies` table joined together. In MongoDB, it is one document read --- much faster for "get me everything about this user".
---
## 2. Key-Value Stores
The simplest NoSQL model. Every piece of data is stored as a key -> value pair. The key is unique; the value can be a string, number, list, or any blob. There is no structure imposed on the value
```
session:abc123  →  { "userId": "user_001", "loggedIn": true }
cart:user_001   →  ["item_A", "item_B", "item_C"]
counter:views   →  14892
```
- **Main use cases**: Session management (storing login state), caching (store database result temporarily), rate limiting, real-time leaderboards, pub/sub messaging.
- **Advantages**: Blazing fast --- Redis keep data in RAM, so reads/writes happen in microseconds. Extremely simple mental model. Scales horizontally with ease
- **vs. Relational**: A relation database is designed to let you ask complex questions about your data. A key-value store does not care about the data it only care about the key. it trades query power for raw speed
---
## 3. Column-Oriented Databases
Data is organized into rows and columns like a table, but internally it is stored by column, not by row. Each row has a primary key, and columns can be sparse (a row does not need a value for every column). Rows are grouped into "column families."
```
Row key: "user_001"
  name: "Sara Ahmed"
  city: "Cairo"
  last_login: "2026-04-01"

Row key: "user_002"
  name: "Ali Hassan"
  plan: "premium"     ← sparse: user_001 doesn't have this column
```
Cassandra also distributes these rows across many machines automatically, using the row key to decide which node stores which data.
- **Main use cases**: Time series data (sensor readings, logs, stock prices), large scale analytics, IoT data, recommendation engines at scale (Netflix, Spotify). Cassandra is designed to handle millions of writes per second across multiple data centers
- **Advantages**: Incredible write throughput. Linear Horizontal Scalability --- add more nodes, get more capacity. High availability by design (no single point of failure). Efficient column scans for analytics.
- **vs. Relational**: A traditional database like PostrgresSQL, reads entire rows even when you only need one column. Columnar storage only read columns you ask for, which is much faster for aggregations  
---
## 4. Graph Databases
Data is stored as nodes (Entities) and edges (Relationships). Both nodes and edges can have properties.
```
Node: (Sara {name: "Sara", age: 29})
Node: (Ali  {name: "Ali",  job: "Engineer"})
Node: (Acme {name: "Acme Corp"})

Edge: Sara –[FRIENDS_WITH]–> Ali
Edge: Ali  –[WORKS_AT]–>     Acme
Edge: Sara –[FOLLOWS]–>      Acme
```
A query like "find all friends of friends of Sara who work at tech companies" is natural and fast in Neo4j. In SQL, the same query requires recursive self-JOINs that become increasingly slow with scale.
- **Main use cases:** Social networks, fraud detection (unusual connection patterns), recommendation engines ("people like you also bought…"), knowledge graphs, network/IT infrastructure mapping, identity access management.
- **Advantages:** Traversing relationships is O(1) per hop — the speed doesn't degrade as the network grows. Highly intuitive for relationship-heavy data. Powerful pattern-matching query language (Cypher).
- **vs. Relational:** In a relational database, relationships are computed using JOINs across tables. For deep or recursive relationships (find connections 5 hops away), the performance drops exponentially. A graph database stores connections as direct pointers — traversal is always fast, regardless of depth.