This MD will contain Some BSON to show you how we can make simple querries in our Database 
i will be using **==FINAL_NYC_restaurants_full_database.csv==** you will find it ready in the MongoDB Collection notes just set up your connection in Mongo Compass and make a database and you are free to start

---
## MongoDB CRUD - Insert & Find Documents
we are gonna use **Mongosh** to type most of our querries
### Inserting Documents

`insertOne()` - Add a single document
```JS
db["nyc"].insertOne({
  DBA: "QUEENS BURGER HOUSE",
  STREET: "45 STREET",
  INCOME_LEVEL: "low income",
  BOROUGH: "Queens",
  ZIPCODE: 11103,
  CUISINE_DESCRIPTION: "Hamburgers",
  SCORE: 12,
  GRADE: "B"
})
```
MongoDB auto generate id for each document if you do not provide one

`insertMany` - add multiple documents at once
```JS
db["nyc"].insertMany([
  {
    DBA: "NILE PALACE",
    STREET: "STEINWAY STREET",
    INCOME_LEVEL: "medium income",
    BOROUGH: "Queens",
    ZIPCODE: 11103,
    CUISINE_DESCRIPTION: "Egyptian",
    SCORE: 5,
    GRADE: "A"
  },
  {
    DBA: "BROOKLYN PIZZA CO",
    STREET: "FLATBUSH AVE",
    INCOME_LEVEL: "high income",
    BOROUGH: "Brooklyn",
    ZIPCODE: 11201,
    CUISINE_DESCRIPTION: "Pizza",
    SCORE: 9,
    GRADE: "A"
  }
])
```
---
### Finding Documents

`findOne()` - Get the first match
```JS
// Find one American restaurant in Queens
db["nyc"].findOne({
  BOROUGH: "Queens",
  CUISINE_DESCRIPTION: "American"
})
```

`find()` - Get all matches
```JS
// Find ALL Grade A restaurants
db["nyc"].find({ GRADE: "A" })
```
---
### Query Operators
#### Comparison Operators

| Operator | Meaning                 | Example                           |
| -------- | ----------------------- | --------------------------------- |
| `$gt`    | greater than            | SCORE > 10                        |
| `$lt`    | less than               | SCORE < 5                         |
| `$gte`   | greater or equal        | SCORE >= 7                        |
| `$lte`   | less or equal           | SCORE <= 7                        |
| `$ne`    | not equal               | GRADE ≠ "C"                       |
| `$in`    | match any value on list | BOROUGH in ["Queens", "Brooklyn"] |

```js
// Restaurants with score higher than 10 (more violations = worse)
db["nyc"].find({ SCORE: { $gt: 10 } })

// Grade A restaurants in medium income areas
db["nyc"].find({
  GRADE: "A",
  INCOME_LEVEL: "medium income"
})
```
---
### Projections (choose which fields to show)
```JS
// Show only name, borough, grade — hide everything else 
db["nyc"].find( 
    { GRADE: "A" },
    { DBA: 1, BOROUGH: 1, GRADE: 1, _id: 0 }
)
```
