## Types of Security Requirements
Its separated in 4 Categories

### Core 
it focus on core pillars we speak about in the previous chapter
- C.I.A Triad
- A.A.A Triad
### General
This Focus on other security considerations like 
- Session Management
- Error & Exception Management
- Configuration Parameters Management
### Operational
-  Deployment Environment
- Archiving
- Anti Piracy
### Other
- Sequencing & Timing
- International 
- Procurement

==**We Will Discuss Them All Later**==
## Confidentiality Protection Mechanisms
### Confidentiality Requirements
In Phases Like
- Data In Transit (Where Data Transmitted over unprotected networks.)
- Data In Processing (Data is held in computer memory or media for processing)
- Data In Storage (Data at rest which means data is physically stored in database, archive files, or documents).
we need to put into consideration how are we gonna protect our data

### Confidentiality Controls
There are some controls to control the Confidentiality of our data like
- **Secret Writing** (the way to protect data and prevent it from being revealed and it include some mechanisms like Overt, Covert)
-  Masking (Turn data  into asterisk.)
#### Overt Mechanism
Data is visible but its incomprehensible and its also Called **Cryptography** and it has Mechanisms Like
##### Encryption

```
            Encryption
Clear Text -------------> Cipher text
Clear Text <------------- Cipher text
            Decryption
```
##### Hashing
```
             Encryption
Clear Text --------------> Cipher Text
// One Way Function 
```
Hashing is Used With things like Password 
#### Covert Mechanism
Data is invisible it cant be seen
##### Steganography 
Sender send data for Receiver but only both of them know it has a secret message or secret data
##### Digital Watermarking
Method of embedding data into a digital signal
### Examples on Confidentiality Requirements
- Personal health information **must be** encrypted or restricted to specific roles.
- Password and other sensitive input fields need to be **masked**
- Passwords must not be stored in clear text in backend systems and when stored must be **hashed** with at least an equivalent to the SHA-256 hash function.
- Implementing Secure Socket Layer (**SSL**) and Transport Layer Security (**TLS**) to protect against man in the middle attacks
- Non-secure protocols such as File Transfer Protocol (**FTP**) should Not be used to transmit sensitive data.
- Sensitive data recorded in log files must Not be stored in clear text. Instead, sensitive data must be encrypted

## Integrity Requirements
Integrity ensures that No unauthorized modification is made to data like SQL injection attack where attacker Changes/Access Data
### Examples
- All Input forms and Query String inputs need to be validated against a set of allowable inputs Before the software accepts it for processing
- Software that is published should provide the recipient with computed checksum and the hash function used to compute the checksum
- All systems and batch processes need to be identified, monitored and prevented from altering data, unless explicitly authorized to.
## Availability Requirements
Ensure my system is always available for Users 24/7, so to specify the requirements we need to measure things like
- **MTD** (Maximum Tolerable Downtime) The total amount of time system can be disrupted
- **RPO** (Recovery Point Objective) The Maximum amount of data that can be lost
- **RTO** (Recovery Time Objective) The Tolerable amount of downtime
These Things need to be listed in the **~={red}SLA=~** (Service Level Agreement)

### Availability Requirements Example
- The Software ensure high availability of five nines (99.999%)
- The number of users your application can handle at any one given point
- Data should be replicated across data centers to provide load balancing
- How will the software functionalities resume and how long it will take to recover after down time

## Authentication Requirements
At software early stages you need to specify The Authentication Factors (Something you **Know**, Something you **Have**, Something you **Are**)
### Authentication Types
- Anonymous Authentication
- Basic Authentication 
- Digest Authentication
- Integrated Authentication
- Client Certificates Authentication
- Forms Authentication
- Token Authentication
- Smart Cards Authentication
- Biometrics Authentication
## Authorization Requirements 
You Need to specify the Subject (User, Process), Objects (Resources) and Actions (CRUDS), so you can be able to control **Who** can Access **What** and **How**

### Access Control Types
- Resource Based Access Control => can be used with Distributed and multi tiered Architectures 
- Mandatory Access Control
- Discretionary Access Control
- Non Discretionary Access Control
### Authorization Requirements Examples
- Access to sensitive data will be restricted to high level users
- User should not be required to send their credentials once they have authenticated themselves successfully and received a unique token
## Accountability Requirements
it help us have History in all actions User do by doing Auditing, where i can investigate unusual actions done by user or Troubleshooting Errors. so Auditing It self has requirements like **Who** made **What** and **Where** and **When** did he do it. I Have to **log** all this 
### Accountability Requirements Examples
- All failed login attempts will be logged along with the internet protocol and the timestamp.
- if data pricing has been modified and changed, I should know this information => (The identity of the subject, the product that changed on, the timestamp).
- The audit Logs files should always append and Never be overwritten.
- The audit logs must be securely  retained for specific time decided by the business owners.
## Session Management Requirements
When User Insert his credentials correctly, after that i generate token to user, This token used to verify if this user authenticated or not (This token be Invalid by either Expiry date or logout process)
### Session Management Examples
- Each user should have only one active session at a time so that users activities can be uniquely tracked
- The user should not be required to provide  user credentials once authenticated
- When does the session end ? => (When user log out, When user closes browser, after certain time)
- Session identifiers must Not be passed in clear text or easily predicted
## Error & Exceptions Management Requirements
This could be a Crucial Part where not handling it correctly could cause some reveal to Sensitive data or Architecture used on our System.
### Error & Exceptions Management Requirements Examples
- All exceptions are to be explicitly handled using try, catch
- Error messages that are displayed to the end user will Not reveal any sensitive information or internal system error details
- Errors should be logged in a secure place
- Monitoring security exception details
## Configuration Parameters Management Requirements
Our Code need to be protected against any attacker so we need to specify the security level in Each stage

### Examples
- The web application configuration file must encrypt sensitive database connections settings and other sensitive application Settings (Like Connection String, SMS Gateway, Token Data (JWT Secret key))
- Passwords must Not be hard coded in line code
- Monitoring Initialization and disposal of global variable.
- Session and/or Application OnStart and OnEnd events must include protection of configuration information as a safeguard against disclosure threats
## Operational Requirements
Why is it important ? to make sure deployment does not face any issues like How many Database Connection for current Access.
### Examples
- Cryptographic keys used by the application should be protected and maintained with restricted access controls.
- Data backups must be protected with least privilege implemented.
- Patching of software must follow the enterprise patch management process and all necessary approvals should be acquired before applying the patch file
- Discovered vulnerabilities in the software must be addressed and fixed AS SOON AS POSSIBLE, after being tested in a simulated environment.
- Incident management process should be followed to handle security incidents.
- Software and its Environment must be Continuously Monitored
## Deployment Environment Requirement
Ensuring That our system is deployed in a safe Environment so we must answer some questions like :
1. Will the software be deployed in an Internet, Extranet or Intranet environment?
2. Will the software be hosted in Demilitarized Zone?
3. What ports and protocols are available for use?
4. Will the software be transmitting sensitive or confidential data?
5. Will the software need a load balancer?
6. Will the software need to support single sign-on (SSO) authentication?
## Archiving Requirements
Storing data especially Sensitive data is important
### Archiving Requirements Questions
1. Where will the data be stored (cloud or offline)
2. How do we ensure that the media is not edited
3. How fast will we need to be able to retrieve from archives when needed?
4. how long will we need to store the archives for?
5. is there a regulatory requirements to store the data for a set period of time?
## Anti-piracy Requirements
if your software is a commercial for example (Video games) you need to protect its source code so it didnt get leaked or exposed to the public and you can do that by using one of the Code Protection Mechanisms
- Code Obfuscation
- Code Signing
- Anti-tampering
- Licensing
### Examples on Anti Piracy Requirements
-  The Software must be digitally signed to protect against tampering and reverse engineering
- The code must be obfuscated to prevent the duplication of code
- License keys must Not be hard coded as they can be disclosed by debugging and reverse engineering.
- License key verification must be dynamic and not be dependent on factors that the end user can change.
## Sequencing & Timing Requirements
one of design problems, where Timing could cause (Race conditions attacks, Time of check attacks, Time of use attacks)
### Examples 
- How does the software handle transactions?
- The login page should be protected to stop race conditions
- Setting a limit for invalid password attempts
## International & Procurement Requirements
When we made a software we need to put into considerations if we are gonna make it national or international so we need to check (Legal international requirements, Technological International requirements)