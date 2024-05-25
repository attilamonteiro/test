# LogAnalyzer

## Description

LogAnalyzer is a C# application designed to process log files, identify error blocks, group hashes by realm, and write the results to an output file. It provides a high-level API for extracting log blocks, identifying error blocks, and grouping hashes.

## Features

- Extract log blocks from log lines.
- Identify error blocks containing specific error messages.
- Group hashes by realm within identified error blocks.
- Read log data from files and write results to output files.

## Project Structure

LogAnalyzer/
│
├── Entities/
│ └── LogBlock.cs
│
├── Interfaces/
│ └── ILoggerRepository.cs
│
├── LogIO/
│ └── FileLoggerRepository.cs
│
├── UseCases/
│ ├── ErrorBlockFinder.cs
│ ├── HashGrouper.cs
│ ├── LogBlockExtractor.cs
│ └── LogProcessor.cs
│
└── Program.cs

## Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/attilamonteiro/LogAnalyzer.git
    ```

2. Open the project in your preferred C# IDE (e.g., Visual Studio).

3. Build the project to restore dependencies and compile the application.

## Usage

1. Prepare a log file named `processamento.log` and place it in the root directory of the project or update the file path in `Program.cs`.

2. Run the application:

    - Using the IDE: Press `F5` or click on the "Start" button in your IDE.
    - Using the command line:

        ```bash
        dotnet run
        ```

3. The application will read the log file, process the log data, and write the results to `result.txt`.

## Code Documentation

### Program.cs

The entry point of the application. It orchestrates the log analysis process by reading the log file, processing it, and writing the results to an output file.

### Entities/LogBlock.cs

Represents a block of log lines.

### Interfaces/ILoggerRepository.cs

Defines methods for reading log files and writing results to a file.

### LogIO/FileLoggerRepository.cs

Implements the `ILoggerRepository` interface to handle file I/O operations.

### UseCases/ErrorBlockFinder.cs

Identifies error blocks within a list of log blocks based on specific error messages.

### UseCases/HashGrouper.cs

Groups hashes by realm within identified error blocks.

### UseCases/LogBlockExtractor.cs

Extracts log blocks from an array of log lines.

### UseCases/LogProcessor.cs

Provides high-level functionality to process log data by extracting log blocks, identifying error blocks, and grouping hashes by realm.

## Contributing

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature`).
3. Commit your changes (`git commit -am 'Add some feature'`).
4. Push to the branch (`git push origin feature/your-feature`).
5. Create a new Pull Request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Acknowledgements

- [Attila](https://github.com/attilamonteiro)

Feel free to contribute to this project by opening issues or submitting pull requests. For any questions or feedback, please contact [Your Email].
