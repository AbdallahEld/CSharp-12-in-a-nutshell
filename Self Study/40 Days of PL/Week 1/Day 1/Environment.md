Environment is a space to store , manage and share your company business data, apps, chatbots and flows . it also serve as container for separate apps that might have different roles , security requirements or target audiences.

# Scope of environments
Each Environment is created under a Microsoft Entra Tenant, and its resources can only be accessed by users within that tenant. An environment is also bound to a geographic location, like the United States. When you create an app in an environment , that app is routed only to datacenters in that region geography

Every environment you create can have zero or more Dataverse database which provides storage for your apps. Whether you can create a database for your environment depends on the license you purchase

apps in your environment can only access database that exist in the same environment so if you have 2 environments "Test", "Dev" and both have thier own dedicated Dataverse you cannot access database in "Test" with apps in "Dev"

# Environment roles
The Environment have two built in roles that provide access to permissions within it
- The Environment That perform all administrative actions like:
	- Add or remove a user or group from either the Environment Admin or Environment Maker role
	- Provision a Dataverse database for the environment
	- View and manage all resources created within the environment.
	- Set data loss prevention polices.
- The Environment Maker role can create resources within an environment including apps, connections, custom connectors, and flows using Power Automate.

Environment makers can also build in environment to other users in your org by sharing the app with individual user

Users or group assigned to these roles are do not have access to environment database and needed to be granted access separately
# Environment types
each environment type indicate the purpose of this environment and determines its characteristics.
1. Production
	This intended for deploying apps and it provide you with 1GB of database storage,
	Security full control
2. Default 
	Predefined and intended for experimentation, exploration and lightweight, app trial development. and it should not be used for deploying or production purposes, security limited control (all licensed users have the environment maker role.)
3. Sandbox
	These are nonproduction environments, which is perfect for development and testing, security is full control 
4. Trial
	Trial are intended to support short term testing needs and are automatically cleaned up after a short period of time, security is full control