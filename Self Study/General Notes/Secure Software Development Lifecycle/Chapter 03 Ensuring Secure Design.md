## Secure Design Principles
### Least Privilege
When My Application have more than one rule and some critical functionality so we give certain rules  to certain users depend on their need of this functionality (The minimum level of privilege in the shortest time).
One if best practices we can use is have more than one level of **Administration** and each one has its own set of **~={orange}Permissions=~** instead of having one Super User that have access to all my functionality
**==Note==**: Its recommended developers use Modular Programming to implement minimum level of privilege
### Separation of Duties
Separate my functionality in multiple conditions
### Defense in Depth
It also called layered defense we have multiple defense layers so if someone pass security layer he cant pass the others
#### Examples
- Use of **input validation** and **prepared statements** before SQL query is executed to defend against **injection attacks**
- Use of **output encoding** to defend against **Cross Site Scripting**
- Applying the validations on both frontend and backend
### Fali Secure
Make sure system can function even after an attack, it focus more on availability
#### Examples
- After the maximum number of access attempts is tried, the user is denied access by default and locked out.
- Not designing the software to ignore error and resume next operation.
- Errors and exceptions are explicitly handled and the error messages are concise and short
## Threat Modeling
Attack Surface can be measured  by how much application exploits can happen so any application feature could be a potential threat to the security and here come Threat Modeling: its Structured security technique used to develop hack-resilient software.

### What we do
- Identify Security Objectives
- Identify Threats
- Identify Vulnerabilities
We try to Identify entry and exit points that might be exploited by an attacker. It provides the software development team with an attackers view point and helps team take key decisions during the design phase from a security viewpoint, the design flow can be addressed before code is written
### Threat Modeling Challenges
- Can be a time-consuming process when done correctly
- Require a fairly mature SDLC
- requires training of employees to correctly model threats and address vulnerabilities
- Often deemed to not be very preferential activity. Developers prefer coding and quality assurance personnel prefer testing over threat modeling
### Threat Modeling Process (Diagram Application Architecture)
#### Identify the physical Topology
Identify How and where the application will be deployed
- An internal application
- Deployed on DMZ
- Hosted on cloud
#### Identify the Logical Topology
Determine components, services, protocols and ports that need to be developed for the application.
Determine how authentication will be designed in the application
- Form based
- Certificate base
- Token based
- Biometrics
#### Identify Human and Non-Human Actors of the System
**For Example** E-Commerce application
- Customers
- Admins
- Sales agents
- Database admins
#### Identify Data Elements
#### Generate a Data Access Control Matrix
To Determine the privileges for each user or role
### Threat Modeling Process (Identify Threats)
We can follow Microsoft **STRIDE** methodology (STRIDE is the first letter of every type of Threat)
#### Spoofing
Where an attacker **Impersonate** another user or identity => Violation for **Authentication**
#### Tampering 
Where the data be **Tampered** with while it is in transit or in storage or archives => Violation For **Integrity**
#### Repudiation
Can the attacker **deny** the attack => Violation for **Accountability**
#### Information Disclosure 
Can Information be disclosed to unauthorized users => Violation for Confidentiality
#### Denial of Service
Is denial of service a possibility ? => Violation for Availability
#### Elevation of Privilege
Can the attacker bypass least privilege implementation ? => Violation for Authorization
### Threat Modeling Process (Identify, Prioritize and Implement Controls)
You can prioritize controls based on Risk Level
### Threat Modeling Process (Document and Validate)
We need to document every possible threat either in Text document or diagrams
**Example**:

| Threat Identifier      |                                               |
| ---------------------- | --------------------------------------------- |
| **Threat Descritpion** |                                               |
| **Threat Targets**     |                                               |
| **Attack Techniques**  | Attacker injects SQL commands in SQL query.   |
| **Security Impact**    |                                               |
| **Risk**               |                                               |
| **Migration Controls** | Validate Input, User Parameterized query, ETC |
Each period of time we need to validate this document to make sure the application architecture is accurate and up to date
