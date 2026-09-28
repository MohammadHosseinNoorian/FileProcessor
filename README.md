# Orders CSV Processor

A simple C# console application that processes a CSV file of orders and separates them into **succeeded** and **failed** orders.

## Features

- 📥 Read orders from a CSV input file
- ⚙️ Process each order (validate, transform, etc.)
- 📊 Display results in the console:
  - List of succeeded orders and failed orders
  - **Max order** and **total orders** (using LINQ)
- 💾 Export results to two separate CSV files:
  - `succeedorders.csv`
  - `failedorders.csv`
- 🔄 Option to change the input file from the menu

## Input File Format

The input CSV file should have the following columns:

```csv
OrderId,CustomerName,Product,Quantity
**orderId starts from 1000**
```
