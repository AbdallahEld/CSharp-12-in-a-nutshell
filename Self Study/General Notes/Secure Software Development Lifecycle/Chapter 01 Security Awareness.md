## SDLF
The steps we follow to output a Software or an application
Steps:
- Requirements
- Design
- Development
- Integration & Testing
- Maintenance

We have 2 Models 
### Waterfall Model
this was the old way, you have to finish phase to start another
### Agile Model
more elastic than the waterfall model you can work on phases concurrently
## Secure SDLC
Securing the software should be part of every phase not bonus at the end, cause if it was left out to the end of the life cycle it can cost the company too much money so for each phase we had to implement some security considerations

```
Requirements -> Risk Assessment
Design -> Threat Modeling
Development -> static Analysis
Testing -> security Testing
Deployment -> Secure Configuration
```
## C.I.A Triad
To be able to build secure software we have to understand the **Core** Pillars of security
- Confidentiality (assurance that sensitive data can only be accessed by Authorized User)
- Integrity (assurance that only Authorized Users can change data)
- Availability (data always avialable for Authorized Users To Access 24/7)

## A.A.A Concept
- Authorization (process of giving someone the ability to access some Thing (**What is your job**))
- Authentication (No one can access my system unless he is known (**Who you are**))
- Accountability (people will be held responsible for their actions on the system)
## Threat , Risk and Vulnerabilities
First we need to know what is **==Assets==**
### Assets:
is Simply each thing in my system that has value and need to be protected:
- Code
- Server
- Network
- Data Centers
- Hardware

### Simply
**Vulnerabilities** is a Weakness in my assets that can cause a  **Threat** of being attacked and **Risk** is the middle man between these two concepts

### Risk Assessment
Risk Can be :
- Low
- Medium
- High
- Critical

and its specified on :
- How Important is the Asset
- Strength of the Threat
- Degree of Vulnerability
### Risk Categories
- Fraud (Some one inside or outside the company causing problems to the company)
- Stealing (Stealing sensitive information)
- Breach of Privacy (Stealing private information)
- Damage (Acts of destructing sensitive data)
- Denial of Service (Compromising availability of company services)

## OWASP Security Design Principles
**OWASP stand for => Open Web Application Security Project**
OWASP is a company that provide Security Projects for developers
- OWASP TOP 10
- Secure Coding Best Practices (Documentation to help developers build secure Code)
- ==OWASP Security Design Principles==

### OWASP Principles
To Make security designs we need to put into Considerations
#### Asset Classification
**For Example**: How Important Is The Data and How its accessibility
~={red}**Restricted**=~ => Financial Applications
~={green}**Public**=~ => Web Blog
#### Understanding Attackers
Trying To Think Like The Attacker how he can Exploit The System, What is his motivates, and why he is doing that
#### Core Pillars of information security
Make sure to follow the core pillars of information security we talked about previously
- [[#C.I.A Triad]]
- [[#A.A.A Concept]]
## Software Security Standard, Regulations & Compliances
There is some **Standards** we have to follow when we are trying to implement secure model for our software
### Security Standards
Can be:
- Methods
- Guidelines
- Reference frameworks
one of the most famous Security Standards **ISO 27000** 

### Regulations & Compliances
Rules an Organization should follow to either protect it self or protect its Customers
**for Example** : the Legal Regulations that established by the Central Bank  you have to follow while making a system for Bank

## Secure SDLC Frameworks
Companies and Corporations started establishing Frameworks and Standards you can follow for Secure SDLC **For Example**:
**NIST** Which has documentation That any member in the SDLC Can follow for Secure System and its called ~={purple}**SP 800-64**=~ But this one have been archived and replaced by ~={purple}**SP 800-160**=~ 
Other Frameworks in the Market is **BSIMM**
## Data Classification
Data is the most crucial Asset in my system that needs to Protected so we had to understand what data classification I had
- Structured Data (Data in database)
- Unstructured Data (Images , videos , ETC)
So we had to **Label** Data based on how important they are **~={red}Sensitive=~**, **~={yellow}Confidential=~**, **~={green}Public=~** and These Labels **Based on** [[#C.I.A Triad]] or Special Publication Like NIST Does (**~={purple}SP 800-18=~**)

### Who Classify Data
#### Business Owner
- Data Classified in a right way
- Security controls applied based on data classification
- put authorization list and access criteria
- Backup and recovery mechanisms appropriate to be implemented
#### Data Custodian
- Information Classification Exercise
- Backup to recovery process
- Records retentions implemented based on regulatory requirements.
## CVSS
Stand for `Common Vulnerability Scoring System`, when a security engineer report about a specific Vulnerability, he specify its level or danger based on **CVSS Calculator**
it ask for some parameters and based on these parameters the Calculator tell how bad or danger its