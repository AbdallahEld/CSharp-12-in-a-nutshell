## Vulnerability Database
Third Stage in SSDLC Is **Secure Coding** when Incident happen we blame the developer despite the fact its not only Developer who is working on the SDLC.
Most security Incidents its root cause or one of these
- Design Flow
- Coding Issues
- Improper Configurations and Operations
### Vulnerability Databases 
it consist of some details like 
- Vulnerability Name
- Description
- How to Exploit
- Impact
- Mitigation Recommendation
One of the most popular Vulnerability Databases
- NVD (contain Security checklists, Software flaws, Products misconfigurations, Affected products, Impact metrics)
- US-CERT
- OSV (Open Source Vulnerabilities)
- CVE (A dictionary of publicly known vulnerabilities)
- CWE (Common Weakness Enumeration (it focus on Architectural issues, Design issues, Coding security weaknesses))
## Vulnerability Examples
### Injection Flaws
Its type of attack where it exploit vulnerability through injecting commands or unwanted code in user inputs and its goal to force system to make commands he should not be making Examples:
- SQL Injection
- OS Command Injection
- LDAP Injection
- CRLF Injection
- Code Injection
- XSS
#### SQL Injection
SQL Injection Example #1
```php
$username = $_GET['username']; // Take Username form input user can type in
$result = mysql_query('SELECT * FROM users WHERE username = "'.$username'"'); 
// Give it directly to result 

//lets say attacker insert something like '' or 1=1;
//SQL Query Will Be Like This SELECT * FROM users WHERE username = '' or 1=1;
//This will literally return all users in database which is bad 
```
---
SQL Injection Example #2
```php
$file_db = new PDO('sqlite:../database/database.sqlite');

if (NULL == $_GET['id']) $_GET['id'] = 1;

$sql = 'SELECT * FROM employees WHERE employeeId' = '. $GET['id']';

foreach ($file_db->query($sql) as $row)
{
    $employee = $row['LastName'] . " - " . $row['Email'] . "\n";
    
    echo $employee;
}
```

##### How To Stop SQL Injection Attacks
by making input validation like preventing user from entering special characters like the ones in SQL SERVER, Or by making prepared Statements
#### OS Command Injection
is when attacker try run commands on the OS of the server where application work which can result in full control on application or data
##### How To Stop OS Command Injection
Try avoiding functions that execute shell commands like `system()`, do not take input from user direct without any Sanitization 
#### Cross Site Scripting (XSS)
its when attacker try injecting some JS scripts in web pages and it could result in unauthorized code to be executed like its part of the website 
##### How To Stop XSS
Input validation, Output Encoding, CSP (Content Security Policy (not allowing unauthorized scripts to run on your browser))
## Secure Implementation Processes
there are some implementation Process we need to implement like

### Versioning
We need to use version control to make we are working with the correct version of code, ability to rollback to a previous version, ability to track ownership and changes of code.
### Code Analysis
it can either be Static Code Analysis (Without Executing code ,Manual Code review, Automated tool, source code analyzers) or Dynamic Code Analysis (Executing code)
### Code Peer Review
Static code review, where another developer review code of another developer (focus on syntax issues , performance and security issues)
### Securing Build Environments
- Testing Environment
- Staging Environment
- Simulated Environment
- Production Environment
## Secure Code Review 
- We can use function to check for bugs like matching/Grep in PHP.
- Following user input.
- Reading source code randomly
- Read all the code
- Check one functionality at a time
### What to look for in a Secure Code Review
- Strange Behavior
- Complexity
- Security Checks
- Comparisons
- Regular Expression