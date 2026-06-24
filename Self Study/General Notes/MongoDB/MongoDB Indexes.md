## What are Indexes & Why Do They Matter?
### Without an Index
```
MongoDB reads EVERY single document one by one
until it finds what you need.

db.nyc.find({ DBA: "COURT SQUARE DINER" })

→ Reads doc 1... not it
→ Reads doc 2... not it
→ Reads doc 3... FOUND IT!
→ But keeps reading just in case...
→ Reads all 50,000 docs 
```
### With an Index
```
MongoDB jumps DIRECTLY to the document.

→ Checks index → goes straight to doc
→ Done. No waste.
```
So simply index is **much faster for Reading** queries but **Slightly slower for writing operations** and take **Extra disk space** 
### `explain()` --- See if your query uses an index

```JS
// This shows you HOW MongoDB ran your query
db.nyc.find({ BOROUGH: "Queens" }).explain("executionStats")
```
#### Look for these two key things in the output 
```
// BAD — no index being used 
"stage": "COLLSCAN"   // Collection Scan = reads everything

// GOOD — index is being used 
"stage": "IXSCAN"     // Index Scan = fast!
```
---
## Single Field Index
Index on **one field** only.
#### Create a Single Field Index
```JS
// Syntax
db.nyc.createIndex({ field: 1 or -1 })

// 1  = ascending index
// -1 = descending index
```
### Unique Index 
```JS
// If every restaurant had a license number, make it unique
db.nyc.createIndex({ LICENSE_NO: 1 }, { unique: true })

// Now inserting two docs with same LICENSE_NO will ERROR
```
---
## Multi Key Index
A **Multikey Index** is automatically created when you index a field that contains an **array**.
### Add a Tags array to restaurant
```JS
db.nyc.updateOne(
  { DBA: "COURT SQUARE DINER" },
  { $set: { TAGS: ["breakfast", "diner", "24hours", "cheap"] } }
)
```
#### Create Index on the array field
```JS
db.nyc.createIndex({ TAGS: 1 })
// MongoDB automatically makes this a MULTIKEY index
// It indexes EACH element in the array separately
```
#### Now this query is fast
```
// Find all restaurants tagged "breakfast"
db.nyc.find({ TAGS: "breakfast" })
// Uses the multikey index 
```
---
## Compound Index
Index on **multiple fields** together --- very powerful!
### Syntax
```JS
db.nyc.createIndex({ field1: 1, field2: 1, field3: 1 })
```
### Index on BOROUGH + GRADE together
```JS
db.nyc.createIndex({ BOROUGH: 1, GRADE: 1 })
```
### Now ALL of these queries use that ONE index
```JS
db.nyc.find({ BOROUGH: "Queens" })                    //  uses index
db.nyc.find({ BOROUGH: "Queens", GRADE: "A" })        //  uses index
db.nyc.find({ BOROUGH: "Queens" }).sort({ GRADE: 1 }) //  uses index
db.nyc.find({ GRADE: "A" })                           //  does NOT use it
```
### ESR Rule --- How To Enter fields in compound index
```
E → Equality fields first    (fields you filter with = )
S → Sort fields second       (fields you use in .sort())
R → Range fields last        (fields you use with $gt $lt etc)
```

```JS
// Query: find Queens restaurants, sort by DBA, score > 5
db.nyc.find({
  BOROUGH: "Queens",       // E - Equality
  SCORE: { $gt: 5 }       // R - Range
}).sort({ DBA: 1 })       // S - Sort

// Correct index order following ESR:
db.nyc.createIndex({ BOROUGH: 1, DBA: 1, SCORE: 1 })
//                    E            S        R
```
---
## Deleting Indexes
### Drop a Single Index by NAME
```JS
// Drop the BOROUGH index
db.nyc.dropIndex("BOROUGH_1")
```
### Drop a Single Index by KEY
```JS
db.nyc.dropIndex({ BOROUGH: 1 })
```
### Drop ALL indexes at once (except `_id`)
```JS
db.nyc.dropIndexes()
```
### Drop specific multiple indexes
```JS
db.nyc.dropIndexes(["BOROUGH_1", "GRADE_1"])
```