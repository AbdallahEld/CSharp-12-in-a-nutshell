## Sorting & Limiting Query Results
### SORTING with `.sort()`
Sort controls the **order** documents come back in
```JSON
// 1 = Ascending (A→Z or 0→9)
// -1 = Descending (Z→A or 9→0)
```
#### Sort restaurants by SCORE lowest to highest
```JS
db.nyc.find().sort({ SCORE: 1 })
```
#### Sort by SCORE highest to lowest
```JS
db.nyc.find().sort({ SCORE: -1 })
```
#### Sort by BOROUGH first, then by SCORE
```JS
db.nyc.find().sort({ BOROUGH: 1, SCORE: -1 })
// Groups by borough alphabetically
// Within each borough → highest score first
```
---
### LIMITING with `.limit()`
Limit controls **how many documents** come back.
#### Get only 5 restaurants
```JS
db.nyc.find().limit(5)
```
#### Get Only 3 Grade A restaurants
```JS
db.nyc.find({ GRADE: "A" }).limit(3)
```
---
### Combining sort() + limit()
```JS
// Top 5 restaurants with LOWEST score (cleanest!)
db.nyc.find().sort({ SCORE: 1 }).limit(5)

// Top 10 worst restaurants (highest score = more violations)
db.nyc.find().sort({ SCORE: -1 }).limit(10)

// Best 3 restaurants in Queens
db.nyc.find({ BOROUGH: "Queens" }).sort({ SCORE: 1 }).limit(3)

// Top 5 Grade A restaurants in Brooklyn alphabetically
db.nyc.find({ BOROUGH: "Brooklyn", GRADE: "A" }).sort({ DBA: 1 }).limit(5)
```
---
## Returning Specific Fields (Projection)
Projection let you **choose which fields** to show or hide in results - like SELECT in SQL.
### Syntax
```JS
db.nyc.find(
  { filter },           // what to find
  { field: 1 or 0 }    // what to show/hide
)
```

```JS
// 1 = SHOW this field
// 0 = HIDE this field
```
#### Show only restaurants name and grade
```JS
db.nyc.find(
  {},
  { DBA: 1, GRADE: 1, _id: 0 }
)
```
Returns
```JS
{ DBA: "COURT SQUARE DINER", GRADE: "A" }
{ DBA: "NILE PALACE", GRADE: "A" }
...
```
#### Show name, borough, score for Grade A only
```JS
db.nyc.find(
  { GRADE: "A" },
  { DBA: 1, BOROUGH: 1, SCORE: 1, _id: 0 }
)
```
---
## Counting Documents
`countDocuments()` --- Count how many match a filter
#### How many restaurants total?
```JS
db.nyc.countDocuments()
```
#### How many Grade A restaurants
```JS
db.nyc.countDocuments({ GRADE: "A" })
```
#### How many American restaurants with GRADE A
```JS
db.nyc.countDocuments({
  CUISINE_DESCRIPTION: "American",
  GRADE: "A"
})
```
#### How many restaurants scored below 5
```JS
db.nyc.countDocuments({ SCORE: { $lt: 5 } })
```
#### How many Brooklyn restaurants have Grade B or C?
```JS
db.nyc.countDocuments({
  BOROUGH: "Brooklyn",
  GRADE: { $in: ["B", "C"] }
})
```
---
## Cover All What We Learned
#### Get The Name, Location of Top 10 Restaurants with GRADE A Food
```JS
db.nyc.find(
  { GRADE : "A" },
  { DBA: 1, BOROUGH: 1, _id: 0 }
).sort({ SCORE: 1}).limit(10)
```