## Quality Assurance
Even if we follow the SSDLC Security Requirements, made Secure Design and Secure Coding it does not assure code is finally secure it has to be **~={green}Tested=~** (also called Quality Assurance), we can achieve it by testing
- Reliability (Software Function as expected)
- Resiliency (The measure of how strong the software is to be able to withstand attacks and errors)
- Recoverability (Can app recover to operational state after downtime)
- Interoperability (can it work in diff environments)
- Privacy
### Functional Testing
Where we test reliability of system and its type is
- Unit Testing (Happen in SDLC, Look for (Build errors, Compilation errors, Bugs))
- Logic Testing (Testing Business Logic)
- Integration Testing (Make sure where the units we test function together as whole)
- Regression Testing (When we add some modifications we need to make sure it does not break the app)
---
### Non Functional Testing
Where we test Resiliency, Recoverability and Interoperability of application and it involve
- Performance Testing (Load, Stress)
- Scalability Testing (Environment, Disaster Recovery Testing)
- Simulation Testing (Production Environment, Deployment Environment)
---
### Other Testing
#### Privacy Testing
Making sure Personal Data is secured by making 
- Policy Control
- Monitoring of network traffic
- Communication between end-points
- Personal information is not disclosed
#### User Acceptance Testing
Making sure the application meet the user need
## Security Scanning
We Scan components in our system such as
- Network
- Access points
- Infrastructure
- Servers
- Application
**Why** => To determine the devices in the network, have a finger print of OS in the Servers, Identify active services and ETC
We have 2 Types of scanning
- Active 
- Passive
## Defect Reporting
Defects can vary  between Coding bugs, Design flaws, Logic flaws, Errors and Vulnerabilities so we need to Make Defect Reporting so the people who are suppose to solve the defect to read the report and solve it so it should contain

| ID          | HCC_000456                                                                                                                                                     |
| ----------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Title       | "Improper Error Handling" / "SQL Injection in Search Function"                                                                                                 |
| Defect Type | Coding issue, Injection flaw, Design flaw, Information disclosure                                                                                              |
| Description | When attempting to insert an image into a new blog, the software allowed the upload of a PHP file instead of the image which resulted in remote code execution |
| Impact      | (Mention the impact of the vulnerability on the business)                                                                                                      |
| Severity    | (After identify the impact we can use tool like CVSS to calculate the severity of the vulnerability )                                                          |
| Priority    | (The team prioritize their efforts to fix the vulnerabilities based on their impact)                                                                           |
| Status      | (New/ Confirmed/ Assigned/ In-progress/ Resolved/ Fix Verified/ Closed/ Reopened)                                                                              |
