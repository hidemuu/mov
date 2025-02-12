# mov

# Money Tracker App Documentation

## Overview

Money Tracker App is a Blazor WebAssembly application that allows users to import financial transactions from CSV files, store them in an SQLite database, and visualize financial trends using charts.

## Features

- CSV Import: Users can upload transaction CSV files.
- Data Storage: Transactions are stored in an SQLite database.
- Data Display: Displays transactions in a paginated table.
- Charts: Monthly and yearly financial trends are visualized using bar charts.
- Responsive Design: Optimized for both desktop and tablet (iPad) usage.

## Installation

### Prerequisites

- .NET 8.0 SDK
- Node.js (for MkDocs installation)
- MkDocs Material Theme (Optional but recommended)

### Setup

1. Clone the repository:
   ```sh
   git clone https://github.com/your-repo/money-tracker-app.git
   cd money-tracker-app
   ```
2. Restore dependencies:
   ```sh
   dotnet restore
   ```
3. Build the application:
   ```sh
   dotnet build
   ```
4. Run the application locally:
   ```sh
   dotnet run
   ```

## CSV Import Functionality

### Expected CSV Format

The application expects the CSV file to be in the following format (Shift-JIS encoded):

```
"Date","Description","Withdrawal (Yen)","Deposit (Yen)","Balance (Yen)","Memo"
"2024/12/27","Debit 848859","801",,"183,256","-"
```

### CSV Parsing and Database Insertion

1. The CSV file is read using `CsvHelper`.
2. Data is parsed into the `TransactionRecord` model.
3. Records are inserted into an SQLite database.

```csharp
private async Task OnFileSelected(InputFileChangeEventArgs e)
{
    var file = e.File;
    using var stream = file.OpenReadStream();
    using var reader = new StreamReader(stream, Encoding.GetEncoding("shift_jis"));
    var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
    var records = csvReader.GetRecords<TransactionRecord>().ToList();
    await SaveCsvDataToDatabase(records);
}
```

## Database Schema

### Transaction Table

```sql
CREATE TABLE Transactions (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Date TEXT,
    Description TEXT,
    Withdrawal INTEGER,
    Deposit INTEGER,
    Balance INTEGER,
    Memo TEXT
);
```

## Data Visualization

### Monthly & Yearly Charts

The application generates bar charts using Chart.js.

```javascript
window.createBarChart = (chartId, labels, dataSets) => {
  const ctx = document.getElementById(chartId).getContext("2d");
  if (window[chartId]) {
    window[chartId].destroy();
  }
  window[chartId] = new Chart(ctx, {
    type: "bar",
    data: {
      labels: labels,
      datasets: dataSets.map((data, index) => ({
        label: `Data Set ${index + 1}`,
        data: data,
        backgroundColor: "rgba(75, 192, 192, 0.2)",
        borderColor: "rgba(75, 192, 192, 1)",
        borderWidth: 1,
      })),
    },
    options: {
      responsive: true,
      scales: {
        y: { beginAtZero: true },
      },
    },
  });
};
```

## Deployment

### Local Deployment for iPad Usage

1. Publish the application:
   ```sh
   dotnet publish -c Release -o ./publish
   ```
2. Use a local web server to serve the app:
   ```sh
   cd publish/wwwroot
   python -m http.server 5000
   ```
3. Access from iPad:
   - Ensure the PC and iPad are on the same network.
   - Open Safari and navigate to `http://<PC_IP>:5000/`.

### Docker Deployment

1. Build a Docker image:
   ```sh
   docker build -t money-tracker-app .
   ```
2. Run the container:
   ```sh
   docker run -p 8080:80 money-tracker-app
   ```
3. Access from the browser: `http://localhost:8080`

## MkDocs Documentation

### Installation

```sh
pip install mkdocs mkdocs-material
```

### Running the Docs

```sh
mkdocs serve
```

### Building Static Site

```sh
mkdocs build
```
