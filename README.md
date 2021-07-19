
# MesaSuite

## Server-side Information
Most of MesaSuite's data is kept in a central Microsoft SQL database, with the exception of a couple databases that other applications use such as the email server and the main website web server. Data is accessed using a scratch-made ORM called Object Based Framework.  Each API uses the ORM with a commonly shared representations of database objects. APIs are accessed by applications on the internet that need to work with the data. This workflow represents most of the APIs used in the system.  APIs that do additional, special types of data access are covered in their respective sections below.

Not all database resources are available for anonymous access. In fact, most are not setup this way.  To provide a security layer when accessing data, users authenticate through the OAuth server.  The OAuth server forwards the credentials to be checked against an Active Directory server using the LDAP protocol.  If the credentials are correct, the OAuth server will check for the user record in the database, or creates one if it does not exist.  Further, it will load all permissions for the user. Once this occurs successfully, the OAuth server notifies all APIs that need this information.  If a user logs out successfully or otherwise has their access token revoked, the OAuth server also notifies all APIs that need this information.  The OAuth server also can send grant/revoke notifications when the user's permissions have been updated, or if the user is deleted.

## Client-side Information
MesaSuite makes exclusive use of gathering and modifying data through web API calls.  To make this easier, a common project has been introduced for use of HTTP get, post, delete, etc. calls.

To manage a user's current authentication status, the common project also includes a class that handles all of the Authentication logic for MesaSuite.  The above described classes for HTTP calls make use of this Authentication class when calls are made to web APIs, automatically including the current user's access token.

## Configuring The Solution
If you do not plan on making any changes and want to run MesaSuite against the live APIs, then no changes to any config files need to be made; simply run the MesaSuite project.  If you're planning on making development changes to any of the APIs or the OAuth project, then special considerations will need to be made. The config files you will need to consider changing depend on the capabilities of the API you're choosing to run.  See below for additional information.
### Projects With AllowedIPsOnly Attribute
APIs that make use of the AllowedIPsOnly attribute on their actions/controllers check in the Web.config file for an `appSettings` key of `AllowedIPsOnly.AllowedIPs`.  Only requests that come from an IP Address specified in this semi-colon delimited list will be allowed through, otherwise a 401 Unauthorized result will be returned.
### Projects With PresharedAuth Attribute
APIs that make use of the PresharedAuth attribute on their actions/controllers check in the Web.config file for `appSettings` keys of `PresharedAuth.Username` and `PresharedAuth.Password`.  The value of these keys can be whatever you wish, but requests made to these actions with this attribute must have `Basic` authorization with these values being the username and password.
### Projects With MesabrookAuthorization Attribute
Use of the `MesabrookAuthorization` attribute is the preferred method for securing controllers and actions.  There is an optional property that is a `string[]` that defines which Permissions it requires a User to possess in order to grant access to the controller/action.  If none are specified, then a User simply needs to be logged in in order to access it.  This attribute requires clients to pass along an access token that they received from the OAuth server via the Authorization header.  This access token is compared to a cache of `SecurityProfile`s kept in memory during the course of the API being online.  If an access token does not exist in the cache, or if it is expired, then the cache will automatically request an update for that access token from the OAuth server.   If no `SecurityProfile` is found for the supplied access token, the request is denied with a 401 Unauthorized.  If a `SecurityProfile` is found, but at least one of the required Permissions are not assigned to the User, then a 403 Forbidden result is returned.

To prevent any unauthorized clients from brute forcing validation of access tokens directly against the OAuth server, the action on the OAuth server responsible for checking access tokens is protected by both the `AllowedIPs` attribute and the `PresharedAuth` attribute.  To enter the preshared credentials to be used against the OAuth server, the system looks in the Web.config file for `appSettings` keys of `OAuthUser` and `OAuthPass`.

Additionally, since it is possible to need to test against a locally-running OAuth server, the `appSettings` key of `OAuthHost` is required that defines what the host URL is for the OAuth server (example, "http://localhost:10709").

### Projects using Object Based Framework
Object Based Framework is capable of using several database engines - it is not restricted to Microsoft SQL Server.  As a result, you will need to specify which adapter it should use. This solution is packaged with the Microsoft SQL Server adapter.  To specify the adapter, add a key under `appSettings` in your Web.config file called `Base.SQLProvider`.  The value should be a path to where the .dll file is located for the adapter.

Every adapter requires different information in the `appSettings` area of the Web.config. In the case of the Microsoft SQL Server adapter, a key is required called `MSSQLProvider.ConnectionString` and the value is the connection string to the database.

### Special Configurations
#### API-User
Since the User Management API requires direct access to the Active Directory server, three additional keys are required in the Web.config file under `appSettings`, those being `LDAPAddress`, `LDAPContainer`, and `LDAPGroupName`.

| Key | Description |
| ------------ | ------------ |
| LDAPAddress | This is the host of the Active Directory server.  Example: `LDAP://192.168.1.10` |
| LDAPContainer | This is where the Groups and Users live in your Active Directory server.  Example: `CN=Users,DC=local,DC=mesasuite` |
| LDAPGroupName | This is the common name (CN) of the group Users are required to be in to be able to authenticate  |

#### OAuth
Because the OAuth server also requires direct access, it will need the `LDAPAddress`, `LDAPContainer`, and `LDAPGroupName` keys in the `appSettings` area of the Web.config as outline in the above API-User section.

The OAuth server also notifies every API when a user is either successfully granted an access token or revokes an access token.  The URLs the server needs to call is defined by the `TokenGrantNotifications` and `TokenRevokeNotifications` keys in the `appSettings` area of the Web.config.  You can enter multiple URLs by separating them with a semi-colon.  Since most APIs can (and should) use the `PresharedAuth` attribute on the actions that would be called, it is necessary to specify the `NotificationUsername` and `NotificationPassword` in the `appSettings` are of the Web.config.  *Note that all APIs should use these credentials as the OAuth server only specifies this single set.*

### MesaSuite Application Configuration
#### Resource Writers
Depending on your development needs, you may need to switch which host API calls are made to.  This is done through setting the `MesaSuite.Common.ResourceWriter` value in the `appSettings` are of the App.config file.  This is a fully qualified classname of the class that implements `IResourceWriter`.  `IResourceWriter` is located in the MesaSuite.Common project.  The table below indicates what each of the Resource Writers do.

| Resource Writer | Description |
| --- | --- |
| DebugResourceWriter.cs | Locates a key of `MeaSuite.Common.DebugResourceWriter.Host` in the `appSettings` are of the App.config.  Uses it as the host of the API request.  Example: `http://localhost:51725` |
| ReleaseResourceWriter.cs | Uses `http://{api}.api.mesabrook.com` as the host for API requests.  `{api}` is determined by the enum `APIs` you pick when creating the API request. |

Using the above will configure all API requests to use the selected Resource Writer. You may override the resource writer you want to use by appending the `APIs` enum name to the end of the config key.  Example:

| Key | Value |
| --- | --- |
| MesaSuite.Common.ResourceWriter.MCSync | MesaSuite.Common.Data.DebugResourceWriter |
| MesaSuite.Common.DebugResourceWriter.Host.MCSync | http://localhost:51725 |
#### Version Endpoint
An additional `appSetting` key that is required for MesaSuite is `MesaSuite.VersionURL`.  This setting points to the API end point that serves MesaSuite version information.  Example: `http://mcsync.api.mesabrook.com/version`.
#### Authentication Endpoint
The last required `appSetting` key is `MesaSuite.Common.AuthHost`.  This is the host name that all of the OAuth authentication will point to (sign-in page, access code, access token, revoke, etc).  Example: `https://auth.mesabrook.com`.
## Project Descriptions

| Project Name | Description |
| --- | --- |
| API.Common | This is a shared code project for use with all APIs.  It handles things like extensions for DataObject and, most importantly, the DataObjectController.cs base controller.  DataObjectController automatically handles GET, POST, PUT, PATCH, and DELETE methods for you, with an option to opt-in to a default GetAll action which returns all data objects of the specified generic type. |
| API-MCSync | This is a WebAPI project that serves MC Sync file information |
| API-User | This is a WebAPI project that manages Active Directory Users and Groups, MesaSuite Users, and Permissions |
| Base | This is the Object Based Framework's Base folder and holds things common between it and database adapters. |
| Database Migration | This project contains code that modifies database schema and data to keep consistent with the models in code |
| MCSync | This is a MesaSuite module that syncs files on the file system for use on the Mesabrook server |
| MesaSuite | This is the primary project that serves as a "launcher" for all of the modules and a mechanism in which users are able to authenticate |
| MesaSuite.Common | This project contains shared MesaSuite functionality that is shared amongst all of MesaSuite's modules.  It contains classes used for Web API access and everything required for Authentication. |
| MesaSuite.Tests | This is a test project used to ensure standards within the MesaSuite project are followed |
| OAuth | This project is responsible for authenticating users through the web form by checking the information against Active Directory and issuing OAuth codes and tokens appropriately. |
| OAuth.Common | This project is shared amongst all WebAPIs and contains mechanisms in which APIs can use to secure their actions in conjunction with the OAuth server |
| ObjectBasedFramework | This project is the custom, scratch-made ORM that converts representational database objects to scripts and vice versa.  |
| ReleaseUtility | This projects aids in the quick release of MesaSuite APIs and desktop applications. |
| RunUnitTests | This project automatically discovers any unit test dll and runs them as a console application.  It's purpose is to be ran automatically during GitHub check-ins. |
| Sandbox | This project allows you to experiment around with all the projects for the purposes of testing or deploying the Schema to your database. |
| Updater | This project is responsible for updating the MesaSuite software |
| UserManagement | This is a MesaSuite module that provides the front end for users to be able to manage Active Directory User and Groups, MesaSuite Users, and Permissions |
| WebModels | This project uses the Object Based Framework and has representations of all the database objects in the primary MesaSuite database. It is common to most of the APIs. |

Depending on your development needs, it may be necessary to run multiple projects at the same time.  Be sure to use a smart startup order to prevent runtime errors.  This is the preferred startup order:
1. OAuth
1. Anonymous Access Web APIs
1. Secured Access Web APIs
1. MesaSuite

## Project Reference Flowchart
[Click to view on diagrams.net][referenceflow]
[referenceflow]: https://app.diagrams.net/#Uhttps%3A%2F%2Fraw.githubusercontent.com%2FCSX8600%2FMCSync%2FMakeAPIsGreatAgain%2FUntitled%2520Diagram.drawio