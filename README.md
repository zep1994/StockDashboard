# StockDashboard

**StockDashboard** is a web-based application designed to provide users with real-time stock market data, interactive charts, and personalized watchlists. Built with a robust backend API and a dynamic frontend interface, it aims to deliver a seamless experience for tracking and analyzing stock performance.

## 🚀 Features

- **Real-Time Data**: Fetches up-to-date stock prices and market information.
- **Interactive Charts**: Visualize stock trends with customizable charts.
- **Personalized Watchlists**: Create and manage lists of favorite stocks.
- **Responsive Design**: Optimized for various devices, including desktops and tablets.

## 🛠 Technologies Used

### Backend

- **C#**: Primary programming language for backend development.
- **ASP.NET Core**: Framework for building the API.
- **Entity Framework Core**: ORM for database interactions.

### Frontend

- **HTML5 & CSS3**: Markup and styling.
- **JavaScript**: Client-side scripting.
- **Razor Pages**: Dynamic page generation.

## 📦 Installation & Setup

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Steps

1. **Clone the Repository**:
   ```sh
   git clone https://github.com/zep1994/StockDashboard.git
   cd StockDashboard
   ```

2. **Setup the Backend**:
   - Navigate to the API project directory:
     ```sh
     cd StockDashboardAPI
     ```
   - Restore dependencies and build the project:
     ```sh
     dotnet restore
     dotnet build
     ```
   - Update the `appsettings.json` file with your SQL Server connection string.
   - Apply database migrations:
     ```sh
     dotnet ef database update
     ```
   - Run the API:
     ```sh
     dotnet run
     ```

3. **Setup the Frontend**:
   - Navigate to the Web project directory:
     ```sh
     cd ../StockDashboardWeb
     ```
   - Restore dependencies:
     ```sh
     dotnet restore
     ```
   - Run the application:
     ```sh
     dotnet run
     ```

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new branch:
   ```sh
   git checkout -b feature-branch
   ```
3. Commit your changes:
   ```sh
   git commit -m "Description of changes"
   ```
4. Push to the branch:
   ```sh
   git push origin feature-branch
   ```
5. Open a Pull Request detailing your changes.

## 📄 License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

## 📞 Contact

**Thomas Matlock**  
📧 Email: [thomasmatlockbba@gmail.com](mailto:thomasmatlockbba@gmail.com)  
🔗 LinkedIn: [linkedin.com/in/tmatlockCISA](https://linkedin.com/in/tmatlockCISA)  
📂 Portfolio: [thomas-matlock.onrender.com](https://thomas-matlock.onrender.com)
