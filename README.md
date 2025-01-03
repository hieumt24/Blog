# Blog CMS

This is a Content Management System (CMS) blog for technical articles. The backend is built using ASP.NET Core WEB API and MVC, and the frontend is developed with Angular.

## Technology Stack

- **Backend**: ASP.NET Core WEB API, MVC, C#
- **Frontend**: Angular, TypeScript, SCSS, HTML
- **Database**: SQL Server

## Installation

### Prerequisites

- .NET SDK
- Node.js
- SQL Server

### Steps

1. **Clone the repository**:

    ```bash
    git clone https://github.com/hieumt24/Blog.git
    cd Blog
    ```

2. **Backend Setup**:

    ```bash
    cd backend
    dotnet restore
    dotnet build
    dotnet run
    ```

3. **Frontend Setup**:

    ```bash
    cd frontend
    npm install
    npm start
    ```

4. **Database Setup**:
   
   - Configure the connection string in `appsettings.Development.json`.
   - Run the database migrations.

5. **Running the Application**:

   - Access the application at `http://localhost:4200`.

## Project Structure

```plaintext
Blog/
├── backend/                   # Backend code
│   ├── src/                   # Source files for the backend
│   └── tests/                 # Backend tests
├── frontend/                  # Frontend code
│   ├── src/                   # Source files for the frontend
│   └── tests/                 # Frontend tests
├── database/                  # Database scripts and migrations
└── README.md                  # Project documentation

