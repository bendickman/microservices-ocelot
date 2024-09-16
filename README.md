# Microservices with Ocelot

## Development Environment

The project was built using Visual Studio 2022 targeting .NET 8

### Customer Api

Web API targeting .NET 8 that provides an endpoint to return Customer data

### Product Api

Web API targeting .NET 8 that provides an endpoint to return Product data

### Authentication Api

Web API targeting .NET 8 that provides an endpoint to return JWT's (json web tokens) for known users

### Api Gateway

Ocelot Api Gateway to provide a single point of entry to the Customer & Product Api's

The Gateway has been configured to use `Bearer token authentication` to provide access to the Customer Api

The Gateway also uses `Rate Limiting` to ensure only a set number of requests can be made to the Product API during a given time period

## Technologies

* [.NET 8 Web Api](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-8.0)
* [Ocelot .NET Api Gateway](https://github.com/ThreeMammals/Ocelot)
* [JWT Authentication & Authorization](https://jwt.io/)

## API Endpoints

### Product - https://localhost:7258

- List all Products

*Http Get* `/api/product`

### Customer - https://localhost:7196

- List all Customers

*Http Get* `/api/customer`

### Authentication - https://localhost:7123

- Get JWT

*Http Post* `/api/auth`

### Ocelot Api Gateway - https://localhost:7155


- List all Products

*Http Get* `/api/product`

- List all Customers

*Http Get* `/api/customer`

The Swagger definition for each API is located at `/swagger/index.html`
