## ACID Transactions
### Atomicity
```
"All or Nothing"

Either ALL operations succeed together
OR NONE of them happen at all

Restaurant Example:
→ Transfer ownership of COURT SQUARE DINER
   Step 1: Remove from owner "John"
   Step 2: Add to owner "Sarah"

If Step 2 fails → Step 1 is automatically UNDONE
The diner can't belong to nobody!
```
### Consistency
```
"Data must always be valid"

The database moves from one valid state
to another valid state - never in between

Restaurant Example:
→ A restaurant MUST have a BOROUGH 
→ A restaurant MUST have a GRADE 
→ These rules are never broken mid-transaction
```
### Isolation
```
"Transactions don't interfere with each other"

If two people update the same restaurant
at the same time → they don't see each other's
half-finished changes

Restaurant Example:
→ Inspector A is updating COURT SQUARE DINER score
→ Manager B reads the restaurant at same time
→ Manager B sees either the OLD data
   or the NEW data — never a broken mix
```
### Durability
```
"Once saved, it stays saved"

After a transaction commits successfully →
the data survives crashes, power cuts, anything

Restaurant Example:
→ Grade update committed
→ Server crashes 1 second later
→ Data is still there when server restarts
```
## Using Transactions in MongoDB
First lets see the Full Transaction Workflow:
```
1. Start a Session
2. Start a Transaction
3. Run your operations
4. Commit (save) OR Abort (cancel)
5. End the Session
```

```JS
// Start a Session
const session = db.getMongo().startSession()

// Start the Transaction
session.startTransaction()

// Run Operations
const restaurantsCollection = session.getDatabase("restaurants").nyc
const logsCollection = session.getDatabase("restaurants").inspection_logs

// Operation 1: Update the restaurant grade
restaurantsCollection.updateOne(
  { DBA: "COURT SQUARE DINER" },
  { $set: { GRADE: "B", SCORE: 17, LAST_INSPECTED: "2024-04-01" } }
)

// Operation 2: Log the inspection
logsCollection.insertOne({
  restaurant: "COURT SQUARE DINER",
  borough: "Queens",
  inspector: "John Smith",
  date: "2024-04-01",
  newGrade: "B",
  newScore: 17
})

// Commit Everything
// if everythign worked
session.commitTransaction()
// if something went wrong
session.abortTransaction

// End Session
session.endSession()
```
### Full Example
```JS
// The complete pattern you'll use every time

const session = db.getMongo().startSession()

try {
  session.startTransaction()

  const nyc = session.getDatabase("restaurants").nyc
  const logs = session.getDatabase("restaurants").inspection_logs

  // Operation 1
  nyc.updateOne(
    { DBA: "COURT SQUARE DINER" },
    { $set: { GRADE: "B", SCORE: 17 } }
  )

  // Operation 2
  logs.insertOne({
    restaurant: "COURT SQUARE DINER",
    inspector: "John Smith",
    date: "2024-04-01",
    grade: "B"
  })

  // If both succeeded → COMMIT
  session.commitTransaction()
  print("Transaction committed successfully!")

} catch (error) {
  // If anything failed → ABORT everything
  session.abortTransaction()
  print("Transaction aborted! Error: " + error)

} finally {
  // Always end the session
  session.endSession()
}
```