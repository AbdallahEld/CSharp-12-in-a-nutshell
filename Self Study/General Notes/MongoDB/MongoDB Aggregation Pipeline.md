## What is Aggregation Pipeline
### Basic Syntax
```JS
db.nyc.aggregate([
  { $stage1: { ... } },
  { $stage2: { ... } },
  { $stage3: { ... } }
])
```
---
## `$match` and `$group` 
### `$match` --- Filter Documents
Works exactly like `find()` but **inside** the pipeline.
```JS
// Find all Grade A restaurants in Queens
db.nyc.aggregate([
   { $match: { GRADE : "A", BOROUGH: "Queens"}}
])
```

```JS
// Match with operators
db.nyc.aggregate([
  { $match: { SCORE: { $lt: 5 } } }  // very clean restaurants
])
```
### `$group` --- Group & Calculate
This is where the magic happens --- like GROUP BY in SQL
#### Syntax
```JS
{ $group: {
    _id: "$FIELD_TO_GROUP_BY",   // group by this
    newField: { $operator: "$field" }  // calculate this
}}
```
#### Key Accumulator Operators

| Operator | What it does              |
| -------- | ------------------------- |
| `$sum`   | Add up values             |
| `$avg`   | Calculate average         |
| `$count` | Count documents           |
| `$min`   | Find minimum value        |
| `$max`   | Find maximum value        |
| `$push`  | Collect values into array |
#### Count restaurants per BOROUGH
```JS
db.nyc.aggregate([
  { $group: {
      _id: "$BOROUGH",
      totalRestaurants: { $sum: 1 }
  }}
])
```
##### Result will be something like that
```JS
{ _id: "Queens",    totalRestaurants: 6012 }
{ _id: "Brooklyn",  totalRestaurants: 6086 }
{ _id: "Manhattan", totalRestaurants: 10259 }
{ _id: "Bronx",     totalRestaurants: 2338 }
```
#### Average SCORE per BOROUGH:
```JS
db.nyc.aggregate([
  { $group: {
      _id: "$BOROUGH",
      avgScore: { $avg: "$SCORE" },
      totalRestaurants: { $sum: 1 }
  }}
])
```
#### You Can Combine between multiple aggregates
##### Get Average score of GRADE A restaurants per borough
```JS
db.nyc.aggregate([
  { $match: { GRADE: "A" } },           // Step 1: keep Grade A only
  { $group: {                            // Step 2: group & calculate
      _id: "$BOROUGH",
      avgScore: { $avg: "$SCORE" },
      count: { $sum: 1 }
  }}
])
```
##### Group by CUISINE and get min/max score:
```JS
db.nyc.aggregate([
  { $group: {
      _id: "$CUISINE_DESCRIPTION",
      bestScore:  { $min: "$SCORE" },   // lowest = cleanest
      worstScore: { $max: "$SCORE" },   // highest = most violations
      total:      { $sum: 1 }
  }}
])
```
---
## `$sort` and `$limit`
Same concept as `.sort` and `.limit()` but inside the pipeline --- so they work on the output of previous stages
### `$sort`
```JS
// 1 = ascending, -1 = descending
{ $sort: { field: 1 or -1 } }
```
### `$limit`
```JS
{ $limit: N }   // keep only first N documents
```
### Examples
#### Which BOROUGH has the most restaurants
```JS
db.nyc.aggregate([
  { $group: {
      _id: "$BOROUGH",
      total: { $sum: 1 }
  }},
  { $sort: { total: -1 } },     // highest count first
  { $limit: 3 }                  // top 3 only
])
```
#### Top 5 cuisines with best average score
```JS
db.nyc.aggregate([
  { $match: { GRADE: "A" } },
  { $group: {
      _id: "$CUISINE_DESCRIPTION",
      avgScore: { $avg: "$SCORE" },
      total: { $sum: 1 }
  }},
  { $sort: { avgScore: 1 } },    // lowest score = cleanest
  { $limit: 5 }
])
```
---
## `$project`, `$count`, and `$set`
### `$project`
Like projection in `find()`
```JS
// 1 = show, 0 = hide
db.nyc.aggregate([
  { $project: {
      _id: 0,
      RestaurantName: "$DBA",        // rename DBA → RestaurantName
      BOROUGH: 1,
      GRADE: 1
  }}
])
```
### `$count` --- Count documents in pipeline
```JS
// How many Grade A restaurants in Queens?
db.nyc.aggregate([
  { $match: { GRADE: "A", BOROUGH: "Queens" } },
  { $count: "GradeA_Queens_Total" }
])
```
### `$set` --- Add or Update Fields Temporarily:
`$set` adds new fields to documents **without** replacing anything
```JS
db.nyc.aggregate([
  { $set: {
      CLEANLINESS_LABEL: {
        $cond: {
          if:   { $lt: ["$SCORE", 5] },
          then: "Very Clean",
          else: "Needs Attention"
        }
      }
  }},
  { $project: { DBA: 1, SCORE: 1, CLEANLINESS_LABEL: 1, _id: 0 } }
])
```
---
## `$out` --- Save Results to a New Collection
`$out` takes your pipeline results and **saves them as a brand new collection** --- very useful for reports
### Syntax
```JS
db.nyc.aggregate([
  { ... pipeline stages ... },
  { $out: "new_collection_name" }
])
```