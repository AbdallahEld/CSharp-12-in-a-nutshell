## Atlas Search Fundamentals
```
Regular find() query:
→ Exact matches only
→ db.nyc.find({ DBA: "court square diner" }) // won't find it
→ db.nyc.find({ DBA: "COURT SQUARE DINER" }) // exact match only

Atlas Search:
→ Fuzzy matching, partial words, typos
→ Searches like Google 
→ "court square"     → finds COURT SQUARE DINER // work
→ "cort squere"      → still finds it (typo tolerance) // work
→ "diner queens"     → still finds it  // work
```
### How Atlas Search Work
```
1. You create a Search Index
   → Atlas scans your collection 
   → Builds an inverted index (like a book index)
   
2. User types "pizza brooklyn"
   
3. Atlas Search checks the inverted index
   "pizza" → found in docs 3, 7, 12, 45... 
   "brooklyn" → found in docs 2, 7, 19, 45... 
   overlap → docs 7 and 45 match both
   
4. Results ranked by RELEVANCE SCORE
   Most relevant → appears first
```
BTW Atlas Search only works on MongoDB Atlas (cloud)
### Atlas Search Example
```JS
db.movies.createSearchIndex(
  "plotIndex",
  {
    "mappings": { // specify what you wanna add the search on (filds)
      "fields": { // specify the field name to the search Index ("plot")
        "plot": { // specify the type of the field (string)
          "type": "string"
        }
      }
    }
  }
)
```
after that we can use it in Aggregation Pipeline `$search`
```JS
db.movies.aggregate([
  {
    $search: {
      index: "plotIndex",
      text: {
        query: "hero",
        path: "plot"
      }
    }
  }
])
```
---
## Dynamic vs Static Mappings
when you create a Search Index, you choose how fields are mapped:
### Dynamic Mapping - Index Everything Automatically
```
Pros:
→ Zero configuration — works immediately
→ All fields indexed automatically
→ Great for getting started fast

Cons:
→ Uses more storage
→ Indexes fields you never search
→ Slower for large collections
```
---
## Data Types in Atlas Search
Each field type needs the right mapping:
```JS
{
  "mappings": {
    "dynamic": false,
    "fields": {

      "DBA": {
        "type": "string"
      },

      "SCORE": {
        "type": "number"
      },

      "GRADE": {
        "type": "string",
        "analyzer": "lucene.keyword"
      },

      "ZIPCODE": {
        "type": "number"
      },

      "BOROUGH": {
        "type": "string"
      },

      "LAST_INSPECTED": {
        "type": "date"
      }
    }
  }
}
```
### Analyzers
is How Text Gets Processed:
```
When you index "COURT SQUARE DINER" with standard analyzer:
→ Breaks into tokens: ["court", "square", "diner"]
→ Lowercases everything 
→ Now searchable by any single word!

lucene.standard → breaks text into words, lowercase (default)
lucene.keyword → treats entire field as ONE token (exact match)
lucene.english → understands English (running = run = runs)
lucene.whitespace → splits only on spaces
```
so in our nyc collection we can specify analyzers that could work with each field
```
DBA (restaurant name) → lucene.standard  (search by any word)
GRADE ("A","B","C")   → lucene.keyword   (exact match only)
BOROUGH               → lucene.keyword   (exact match)
CUISINE_DESCRIPTION   → lucene.standard  (search by word)
```
---
## `$search` Operators: `text` and `equals`
### `text` Operator - Full Text Search:
```JS
// Search for any restaurant with "pizza" in the name
db.nyc.aggregate([
  { $search: {
      index: "default",
      text: {
        query: "pizza",
        path: "DBA"
      }
  }},
  { $limit: 5 },
  { $project: { DBA: 1, BOROUGH: 1, GRADE: 1, _id: 0 }}
])
```
you can also search in multiple fields at once:
```JS
// Search "pizza" in BOTH name AND cuisine
db.nyc.aggregate([
  { $search: {
      index: "default",
      text: {
        query: "pizza",
        path: ["DBA", "CUISINE_DESCRIPTION"]
      }
  }},
  { $limit: 5 },
  { $project: { DBA: 1, CUISINE_DESCRIPTION: 1, GRADE: 1, _id: 0 }}
])
```
you can also specify the tolerance rate of equality in the word you searching for using `fuzzy`
```JS
// "Piza" typo still finds Pizza restaurants!
db.nyc.aggregate([
  { $search: {
      index: "default",
      text: {
        query: "piza",           // typo!
        path: "CUISINE_DESCRIPTION",
        fuzzy: {
          maxEdits: 1            // allow 1 character difference
        }
      }
  }},
  { $limit: 5 },
  { $project: { DBA: 1, CUISINE_DESCRIPTION: 1, _id: 0 }}
])
```
### `equals` Operator - Exact Value Match
```JS
// Find all Grade A restaurants exactly
db.nyc.aggregate([
  { $search: {
      index: "default",
      equals: {
        path: "GRADE",
        value: "A"
      }
  }},
  { $limit: 5 },
  { $project: { DBA: 1, GRADE: 1, BOROUGH: 1, _id: 0 }}
])
```
you can **Combine** both `equals`, `text` 
```JS
// Pizza restaurants that are Grade A
db.nyc.aggregate([
  { $search: {
      index: "default",
      compound: {
        must: [
          { text: {
              query: "pizza",
              path: "CUISINE_DESCRIPTION"
          }},
          { equals: {
              path: "GRADE",
              value: "A"
          }}
        ]
      }
  }},
  { $project: { DBA: 1, CUISINE_DESCRIPTION: 1, GRADE: 1, _id: 0 }}
])
```
---
## `$search` Operators: `near` and `range`
### `range` Operator - Search within a Range
```JS
// Restaurants with SCORE between 0 and 7 (cleanest)
db.nyc.aggregate([
  { $search: {
      index: "default",
      range: {
        path: "SCORE",
        gte: 0,
        lte: 7
      }
  }},
  { $project: { DBA: 1, SCORE: 1, GRADE: 1, _id: 0 }},
  { $limit: 10 }
])
```
### `near` Operator - Score by Closeness to a Value
```JS
// Restaurants with score NEAR 5 (ranked by closeness to 5)
db.nyc.aggregate([
  { $search: {
      index: "default",
      near: {
        path: "SCORE",
        origin: 5,       // target value
        pivot: 3         // how quickly score drops off
      }
  }},
  { $project: {
      DBA: 1,
      SCORE: 1,
      score: { $meta: "searchScore" },   // relevance score
      _id: 0
  }},
  { $limit: 10 }
])
```