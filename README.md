
#Inventory Manager Code Challenge

## Overview

This project contains a basic implementation of an inventory manager.
This has been a time boxed project, trying to fulfill as many points of the 
code challenge as possible during the weekend.

## Business requisites

The starting point of any project are (or should be) the business requisites. I have 
guessed that, after several talks with the business guys, we have agreed
the following requisites:

- Item's name must be unique (there are not 2 items with the same name in the inventory)
- Any of the item's fields are never modified
- All of the item's fields are required

## Domain Model

A good model will boost our development and save a lot of effort during the lifetime of our application.

For simplicity sake I have decided to stick to one unique bounded context (the inventory manager),
even though I could have also easily defined 2 bounded contexts: one for the inventory manager and one for the expiration controller.  

We should keep our aggregates as small as possible. Even though the minimal aggregate would be the Item, the agreed business rules 
(no duplicates for item names) took me to define the Inventory as the aggregate. This means higher contention
and we could also rely on the database to fulfill that business requisite but well, this is just a code challenge ;)

Therefore, we have 1 unique bounded context with 1 unique aggregate which contains 2 entities: the Inventory (root) and the Item.

As per definition we can only access the items through the aggregate (the inventory) which verifies that those business rules are 
always valid.

## Project structure

I have splitted the project in 2 sides: Back and Front.

The Back side exposes a Rest API and has been developed with .Net, and has 4 projects:

- Application
- Domain
- Infrastructure
- Tests

The projects follow the typical domain-centered architecture, where the Domain
is the core component.

The Front side contains a UI and has been developed using Vue 3 and typescript.

## Run it

To run the Back side, just issue:

`docker run -p 7098:80 miguelperezcolom/inventory-back:v1`

you can check the api is running by navigating to http://localhost:7098/swagger/index.html

<img src="https://raw.githubusercontent.com/miguelperezcolom/inventory-manager/master/docs/s01.png" width="600">

user: `admin`
password: `admin`

To run the Front side, just move to the `ui` directory and issue:

`docker run -p 8080:80 miguelperezcolom/inventory-front:v1`

You will then be able to navigate to http://localhost:8080 and see the UI.

<img src="https://raw.githubusercontent.com/miguelperezcolom/inventory-manager/master/docs/s02.png" width="600">

## Leftovers

As said, this has been timeboxed, and some leftovers are pending. As far as I remember, they are:

- some tests. Even though I have included some, there are some tests left
- this solution is not designed to allow concurrency
- this solution is not scalable
- there is no client side validation
- comments on many classes
- technical documentation, from /// comments
- e2e tests
- the UI is quite simple (e.g. I'm not using vuex, nor I have developed any test)
- create helm chart, so the solution can be easily run in a kubernetes cluster

Also, there are some things which I would change:

- there is some logic in the code related to items expiration which should be splitted
- I would take the authentication code out of the project, and move that responsibility to an api gateway
- I would also take the job triggers out of the project, and use the kubernetes jobs for that


## Conclusion

Even though this is just a first iteration, the project fulfills almost all the code challenge requirements.

## References

- The code challenge document is not public, so I can not include it
