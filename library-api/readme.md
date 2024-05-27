# Library API

A Simple API for managing a collection of books.

## Installation

Clone the project  
 `bash
    git clone https://github.com/JokisAtte/library-api.git
    `

Run the project
`bash
    cd library-api
    dotnet run
    `

Now project should be running in localhost:9000

## Usage

The API has the following endpoints:

- GET /api/books
  Returns all books in the database
  Use query parameters to filter the results by:

      - title

      - author

      - year

      You can use any combination of parameters, for example

      ``GET /api/books?title=The%20Hobbit&author=J.R.R.%20Tolkien``
      returns all books that match title "The Hobbit" and author "J.R.R. Tolkien"

- GET /api/books/{id}
  Get single book by ID

- POST /api/books
  Post a new book

- DELETE /api/books/{id}
  Delete a book by ID

OpenAPI documentation can be found from
`/swagger/index.html`
